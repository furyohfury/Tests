using UnityEngine;

namespace Game.Gameplay
{
	public sealed class PlayerAnimatorComponent : MonoBehaviour
	{
		[SerializeField]
		private SwitchModelsComponent _switchModelsComponent;

		private readonly int _isMovingState = Animator.StringToHash("IsMoving");
		private readonly int _direction = Animator.StringToHash("Direction");
		private readonly int _lose = Animator.StringToHash("Lose");
		private readonly int _win = Animator.StringToHash("Win");

		public void SetIsMoving(bool isMoving)
		{
			_switchModelsComponent.ActiveVariant.Animator.SetBool(_isMovingState, isMoving);
		}

		public void SetDirection(float direction)
		{
			_switchModelsComponent.ActiveVariant.Animator.SetFloat(_direction, direction);
		}

		public void SetLoseTrigger()
		{
			_switchModelsComponent.ActiveVariant.Animator.SetTrigger(_lose);
		}

		public void SetWinTrigger()
		{
			_switchModelsComponent.ActiveVariant.Animator.SetTrigger(_win);
		}
	}
}