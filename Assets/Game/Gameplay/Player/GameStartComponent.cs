using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game.Gameplay
{
	public sealed class GameStartComponent : MonoBehaviour
	{
		private LevelFSM _levelFsm;
		private bool _activated;

		[Inject]
		public void Construct(LevelFSM levelFsm)
		{
			_levelFsm = levelFsm;
		}

		public void StartGame(InputAction.CallbackContext context)
		{
			if (_activated == false &&
			    Mouse.current.leftButton.wasPressedThisFrame &&
			    _levelFsm.State.CurrentValue is not StartLevelState)
			{
				_levelFsm.SetState<StartLevelState>();
				_activated = true;
			}
		}
	}
}