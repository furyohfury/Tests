using UnityEngine;

namespace Game.Gameplay
{
	public sealed class MoveComponent : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody _rigidbody;

		public void Move(Vector3 direction)
		{
			_rigidbody.MovePosition(_rigidbody.position + direction);
		}
	}
}