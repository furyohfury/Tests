using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Gameplay
{
	public sealed class PlayerSideMoveController : MonoBehaviour
	{
		[SerializeField]
		private MoveComponent _moveComponent;
		[SerializeField]
		private float _sideSpeed;
		private Vector3 _direction;

		private void FixedUpdate()
		{
			_moveComponent.Move(_direction * Time.fixedDeltaTime);
		}

		public void Move(InputAction.CallbackContext callbackContext)
		{
			var inputValue = callbackContext.ReadValue<Vector2>();
			_direction = inputValue.x * _sideSpeed * transform.right;
		}
	}
}