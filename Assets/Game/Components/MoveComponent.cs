using UnityEngine;

namespace Game
{
	public sealed class MoveComponent : MonoBehaviour
	{
		[SerializeField]
		private float _speed;
		[SerializeField]
		private Rigidbody _rigidbody;
		[SerializeField]
		private Transform _transform;

		public void Move(Vector3 direction)
		{
			_rigidbody.MovePosition(_rigidbody.position + direction.normalized * (_speed * Time.deltaTime));
		}
	}
}