using UnityEngine;

[RequireComponent(typeof(Collider))]
public sealed class BulletItem : MonoBehaviour
{
	[SerializeField]
	private float _speed = 10f;
	private int _damage;

	private bool _initialized;

	public void Init(int damage)
	{
		_damage = damage;
		_initialized = true;
	}

	private void FixedUpdate()
	{
		transform.position += transform.right * (_speed * Time.fixedDeltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (_initialized && other.TryGetComponent(out Health health))
		{
			health.DoDamage(_damage);
			Destroy(gameObject);
		}
	}
}