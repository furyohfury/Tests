using System;
using UnityEngine;

public class UnitItem : MonoBehaviour
{
	public Action<UnitItem> OnUnitDie = delegate { };
	public UnitConfig UnitConfig => unitConfig;

	[Header("Unit Personal Ref")]
	public GameObject visualGO;
	public AudioSource unitAudioSource;
	public SpriteRenderer spriteRenderer;
	public Collider2D collider;
	public Rigidbody2D rb;
	public Health health;
	public ParticleSystem hitEffect;
	public ShootComponent shootComponent;
	public TeamType teamType;
	public Vector2 moveDirection;
	private UnitConfig unitConfig;

	public void Init(UnitConfig unitConfig)
	{
		this.unitConfig = unitConfig;
		health.Init(unitConfig.hp);
		shootComponent.Init(
			unitConfig.ammoCount,
			unitConfig.rateFire,
			unitConfig.reload,
			unitConfig.damage,
			teamType
			);
	}

	public void Shoot()
	{
		shootComponent.Shoot();
	}

	private void OnEnable()
	{
		health.OnHPChange += OnHPChanged;
		health.OnDie += OnDie;
	}

	private void Start()
	{
		OnUnitSpawned();
	}

	private void OnUnitSpawned()
	{
		if (unitConfig != null)
		{
			unitAudioSource.PlayOneShot(unitConfig.soundSpawn);
			Debug.Log(unitConfig.spawnMessageUnit);
		}
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		rb.MovePosition(rb.position + moveDirection * (unitConfig.moveSpeed * Time.fixedDeltaTime));
	}

	private void OnHPChanged(float hp)
	{
		PlayHitEffect();
	}

	private void PlayHitEffect()
	{
		hitEffect.Play();
	}

	private void OnDie()
	{
		Debug.Log($"Unit {gameObject.name} died");
		AudioSource.PlayClipAtPoint(unitConfig.soundDeath, transform.position);
		Destroy(gameObject);
	}

	private void OnDisable()
	{
		health.OnHPChange -= OnHPChanged;
		health.OnDie -= OnDie;
	}
}