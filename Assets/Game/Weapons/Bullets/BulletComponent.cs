using UnityEngine;

namespace Game
{
	public class BulletComponent : MonoBehaviour
	{
		[SerializeField]
		private MoveComponent _moveComponent;
		[SerializeField]
		private int _damage;

		private void FixedUpdate()
		{
			_moveComponent.Move(transform.forward);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out LifeComponent lifeComponent))
			{
				lifeComponent.TakeDamage(_damage);
				Destroy(gameObject);
			}
		}
	}
}