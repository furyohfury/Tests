using UnityEngine;

public sealed class ShootComponent : MonoBehaviour
{
	private const string PLAYER_BULLET_LAYER_NAME = "PlayerBullet";
	private const string ENEMY_BULLET_LAYER_NAME = "EnemyBullet";
	public BulletItem bulletPrefab;
	public Transform firePoint;

	private int ammoCount;
	private float rateFire;
	private float reload;
	private int damage;
	private float rateFireTimer;
	private int currentAmmo;
	private bool reloading;
	private TeamType team;

	public void Init(int ammoCount, float rateFire, float reload, int damage, TeamType team)
	{
		this.ammoCount = ammoCount;
		this.rateFire = rateFire;
		this.reload = reload;
		this.damage = damage;
		this.team = team;
		currentAmmo = this.ammoCount;
	}

	public void Shoot()
	{
		if (rateFireTimer > 0)
		{
			return;
		}

		if (currentAmmo > 0)
		{
			FireBullet();
			rateFireTimer = rateFire;
		}
		else if (reloading == false)
		{
			Invoke(nameof(Reload), reload);
			reloading = true;
		}
	}

	private void FireBullet()
	{
		var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, transform.root);
		bullet.Init(damage);
		if (team == TeamType.Player)
		{
			bullet.gameObject.layer = LayerMask.NameToLayer(PLAYER_BULLET_LAYER_NAME);
		}
		else
		{
			bullet.gameObject.layer = LayerMask.NameToLayer(ENEMY_BULLET_LAYER_NAME);
		}

		currentAmmo--;
	}

	public void Reload()
	{
		currentAmmo = ammoCount;
		reloading = false;
	}

	private void Update()
	{
		if (rateFireTimer > 0)
		{
			rateFireTimer -= Time.deltaTime;
		}
	}
}