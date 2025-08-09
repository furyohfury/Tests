using System;
using UnityEngine.UI;
using Zenject;

namespace Game
{
	public sealed class StartButtonController : IInitializable, IDisposable
	{
		private readonly Button _startButton;
		private readonly RaceStateManager _raceStateManager;

		public StartButtonController(Button startButton, RaceStateManager raceStateManager)
		{
			_startButton = startButton;
			_raceStateManager = raceStateManager;
		}

		public void Initialize()
		{
			_startButton.onClick.AddListener(OnButtonPressed);
			_raceStateManager.OnStateChanged += OnStateChanged;
		}

		private void OnStateChanged(RaceState state)
		{
			if (state is RaceState.Reset)
			{
				_startButton.gameObject.SetActive(true);
			}
		}

		private void OnButtonPressed()
		{
			_raceStateManager.SetState(RaceState.Start);
			_startButton.gameObject.SetActive(false);
		}

		public void Dispose()
		{
			_startButton.onClick.RemoveListener(OnButtonPressed);
			_raceStateManager.OnStateChanged -= OnStateChanged;
		}
	}
}