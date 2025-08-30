using UnityEngine;

namespace Game.UI
{
	public sealed class FlyingMoneyViewFactory
	{
		private readonly MoneyFlyText _positiveViewPrefab;
		private readonly MoneyFlyText _negativeViewPrefab;
		private readonly Transform _container;

		public FlyingMoneyViewFactory(MoneyFlyText positiveViewPrefab, MoneyFlyText negativeViewPrefab, Transform container)
		{
			_positiveViewPrefab = positiveViewPrefab;
			_negativeViewPrefab = negativeViewPrefab;
			_container = container;
		}

		public void SpawnPositive(int difference)
		{
			var moneyFlyText = Object.Instantiate(_positiveViewPrefab, _container);
			moneyFlyText.SetText("+" + difference);
		}

		public void SpawnNegative(int difference)
		{
			var moneyFlyText = Object.Instantiate(_negativeViewPrefab, _container);
			moneyFlyText.SetText("+" + difference);
		}
	}
}