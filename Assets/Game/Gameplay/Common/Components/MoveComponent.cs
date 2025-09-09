using UnityEngine;

namespace Game.Gameplay
{
	public sealed class MoveComponent : MonoBehaviour
	{
		[field: SerializeField]
		public Vector3 MoveDirection { get; set; }

		[SerializeField]
		private Rigidbody _rigidbody;

		public void FixedUpdate()
		{
			_rigidbody.MovePosition(_rigidbody.position + transform.TransformDirection(MoveDirection) * Time.fixedDeltaTime);
		}
	}
}