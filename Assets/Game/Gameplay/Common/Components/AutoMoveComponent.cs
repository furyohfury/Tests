using UnityEngine;

namespace Game.Gameplay
{
	public sealed class AutoMoveComponent : MonoBehaviour
	{
		[SerializeField]
		private float _speed;
		[SerializeField]
		private MoveComponent _moveComponent;
		[SerializeField]
		private Vector3 _direction = Vector3.forward;

		private void FixedUpdate()
		{
			_moveComponent.Move(transform.TransformDirection(_direction) * (_speed * Time.fixedDeltaTime));
		}
	}
}