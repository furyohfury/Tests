using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
	public sealed class PlayerControllerComponent : MonoBehaviour
	{
		[SerializeField]
		private MoveComponent _moveComponent;
		[SerializeField]
		private ShootComponent _shootComponent;
		[SerializeField]
		private RotationComponent _rotationComponent;
		[SerializeField]
		private WeaponSwitchComponent _weaponSwitchComponent;
		[SerializeField]
		private Camera _camera;
		[SerializeField]
		private LayerMask _floorMask;
		private Vector3 _direction;

		private void FixedUpdate()
		{
			_moveComponent.Move(_direction);
		}

		private void Update()
		{
			Rotate();
		}

		private void Rotate()
		{
			var ray = _camera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out RaycastHit hit, 1000f, _floorMask))
			{
				var target = hit.point;
				var direction = target - transform.position;
				direction.y = 0f;

				if (direction.sqrMagnitude > 0.001f)
				{
					_rotationComponent.Rotate(direction);
				}
			}
		}

		public void Move(InputAction.CallbackContext callbackContext)
		{
			var inputValue = callbackContext.ReadValue<Vector2>();
			_direction = new Vector3(inputValue.x, 0, inputValue.y);
		}

		public void Shoot(InputAction.CallbackContext callbackContext)
		{
			if (callbackContext.phase == InputActionPhase.Performed)
			{
				_shootComponent.Shoot();
			}
		}

		public void SwitchWeapon(InputAction.CallbackContext callbackContext)
		{
			if (callbackContext.phase == InputActionPhase.Performed)
			{
				_weaponSwitchComponent.Switch();
			}
		}
	}
}