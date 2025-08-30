using System;
using Game.Gameplay;
using R3;
using Zenject;

namespace Game.UI
{
	public sealed class FlyingMoneyController : IInitializable, IDisposable
	{
		private readonly MoneyStorage _moneyStorage;
		private readonly FlyingMoneyViewFactory _viewFactory;
		private readonly CompositeDisposable _disposable = new();

		public FlyingMoneyController(MoneyStorage moneyStorage, FlyingMoneyViewFactory viewFactory)
		{
			_moneyStorage = moneyStorage;
			_viewFactory = viewFactory;
		}

		public void Initialize()
		{
			_moneyStorage.Money
			             .Skip(1)
			             .Pairwise()
			             .Where(tuple => tuple.Current > tuple.Previous)
			             .Subscribe(tuple => _viewFactory.SpawnPositive(tuple.Current - tuple.Previous))
			             .AddTo(_disposable);

			_moneyStorage.Money
			             .Skip(1)
			             .Pairwise()
			             .Where(tuple => tuple.Previous > tuple.Current)
			             .Subscribe(tuple => _viewFactory.SpawnNegative(tuple.Current - tuple.Previous))
			             .AddTo(_disposable);
		}

		public void Dispose()
		{
			_disposable.Dispose();
		}
	}
}