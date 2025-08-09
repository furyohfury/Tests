using System;
using UnityEngine.UI;
using Zenject;

namespace Game
{
	public sealed class ResetButtonController : IInitializable, IDisposable
	{
		private readonly Button _resetButton;
		private readonly RaceStateManager _raceStateManager;

		public ResetButtonController(Button resetButton, RaceStateManager raceStateManager)
		{
			_resetButton = resetButton;
			_raceStateManager = raceStateManager;
		}

		public void Initialize()
		{
			_raceStateManager.OnStateChanged += OnStateChanged;
		}

		private void OnStateChanged(RaceState raceState)
		{
			if (raceState is not RaceState.Finish)
			{
				return;
			}

			_resetButton.gameObject.SetActive(true);
			_resetButton.onClick.AddListener(OnResetButtonClicked);
		}

		private void OnResetButtonClicked()
		{
			_resetButton.onClick.RemoveListener(OnResetButtonClicked);
			_resetButton.gameObject.SetActive(false);
			_raceStateManager.SetState(RaceState.Reset);
		}

		public void Dispose()
		{
			_raceStateManager.OnStateChanged -= OnStateChanged;
		}
	}
}