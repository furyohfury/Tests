using System;
using R3;
using Zenject;

namespace Game.Gameplay
{
	public sealed class GameOverObserver : IInitializable, IDisposable
	{
		private readonly MoneyStorage _moneyStorage;
		private readonly IGameOverHandler[] _gameOverHandlers;
		private IDisposable _disposable;

		public GameOverObserver(MoneyStorage moneyStorage, IGameOverHandler[] gameOverHandlers)
		{
			_moneyStorage = moneyStorage;
			_gameOverHandlers = gameOverHandlers;
		}

		public void Initialize()
		{
			_disposable = _moneyStorage.Money
			                           .Where(money => money <= 0)
			                           .Skip(1)
			                           .Subscribe(_ => OnGameOver());
		}

		private void OnGameOver()
		{
			for (int i = 0, count = _gameOverHandlers.Length; i < count; i++)
			{
				_gameOverHandlers[i].Execute();
			}
		}

		public void Dispose()
		{
			_disposable.Dispose();
		}
	}
}