using Game.Gameplay;
using UnityEngine;

namespace Game.UI
{
	public sealed class SpawnPopupGameOverHandler : IGameOverHandler
	{
		private readonly GameOverPopup _gameOverPopup;
		private readonly Transform _container;

		public SpawnPopupGameOverHandler(GameOverPopup gameOverPopup, Transform container)
		{
			_gameOverPopup = gameOverPopup;
			_container = container;
		}

		public void Execute()
		{
			Object.Instantiate(_gameOverPopup, _container);
		}
	}
}