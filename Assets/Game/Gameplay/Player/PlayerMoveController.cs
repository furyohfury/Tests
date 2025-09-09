using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Gameplay
{
	public class PlayerMoveController : MonoBehaviour
	{
		[Header("Movement Settings")]
		public float SideSpeed = 10f;
		public float MaxStepPerSecond = 5f; // опционально — лимит скорости по локальной оси
		[SerializeField]
		private float _forwardSpeed = 6f;

		private MoveComponent _moveComponent;
		private bool _isLBMHeld;
		private Camera _camera;

		[Inject]
		private void Construct(Camera camera)
		{
			_camera = camera;
		}

		private void Awake()
		{
			_moveComponent = GetComponent<MoveComponent>();
		}

		public void OnTouch(InputAction.CallbackContext context)
		{
			float sideMovement = 0f;
			if (context.started ||
			    context.performed)
			{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
				if (_isLBMHeld == false)
				{
					return;
				}
#endif
				var delta = context.ReadValue<Vector2>();
				var deltaX = delta.x;
				sideMovement = deltaX * SideSpeed;
				sideMovement = Mathf.Clamp(sideMovement, -MaxStepPerSecond, MaxStepPerSecond);
			}

			_moveComponent.MoveDirection = new Vector3(sideMovement, 0, _forwardSpeed);
		}

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		public void OnMouseClick(InputAction.CallbackContext context)
		{
			if (context.started ||
			    context.performed)
			{
				_isLBMHeld = true;
			}
			else if (context.canceled)
			{
				_isLBMHeld = false;
			}
		}
#endif

		private void OnDisable()
		{
			_moveComponent.MoveDirection = Vector3.zero;
		}
	}
}