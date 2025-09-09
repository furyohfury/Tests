using UnityEngine;

namespace Game.Gameplay
{
	public sealed class PlayerAnimatorMovement : MonoBehaviour
	{
		[SerializeField]
		private MoveComponent _moveComponent;
		[SerializeField]
		private PlayerAnimatorComponent _playerAnimatorComponent;

		private void Update()
		{
			var moveDirection = _moveComponent.MoveDirection;
			UpdateIsMoving(moveDirection);
			UpdateMoveDirection(moveDirection);
		}

		private void UpdateIsMoving(Vector3 moveDirection)
		{
			var forwardMovement = moveDirection.z;
			var isMoving = _moveComponent.enabled && forwardMovement > 0;
			_playerAnimatorComponent.SetIsMoving(isMoving);
		}

		private void UpdateMoveDirection(Vector3 moveDirection)
		{
			var sideMovement = moveDirection.x;
			var sideDirection = 0f;
			if (sideMovement != 0)
			{
				sideDirection = sideMovement > 0
					? 0.75f
					: -0.75f;
			}

			_playerAnimatorComponent.SetDirection(sideDirection);
		}
	}
}