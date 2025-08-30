using System;
using Game.Gameplay;
using R3;
using UnityEngine;
using Zenject;

namespace Game.UI
{
	public sealed class MoneyProgressPresenter : IInitializable, IDisposable
	{
		private readonly SwitchModelsThresholdsConfig _thresholds;
		private readonly MoneyStorage _moneyStorage;
		private readonly MoneyProgressView _moneyProgressView;
		private IDisposable _disposable;

		public MoneyProgressPresenter(SwitchModelsThresholdsConfig thresholds, MoneyStorage moneyStorage, MoneyProgressView moneyProgressView)
		{
			_thresholds = thresholds;
			_moneyStorage = moneyStorage;
			_moneyProgressView = moneyProgressView;
		}

		public void Initialize()
		{
			_disposable = _moneyStorage.Money
			                           .Subscribe(OnMoneyChanged);
		}

		private void OnMoneyChanged(int money)
		{
			RichStatusTier[] tiers = _thresholds.Tiers;
			RichStatusTier currentTier = null;
			RichStatusTier nextTier = null;

			for (var i = 0; i < tiers.Length; i++)
			{
				if (money >= tiers[i].MinMoney)
				{
					currentTier = tiers[i];

					// если это не последний — следующий сразу после
					if (i < tiers.Length - 1)
						nextTier = tiers[i + 1];
				}
			}

			if (currentTier != null)
			{
				_moneyProgressView.SetText(currentTier.Id);

				float ratio;
				if (nextTier == null)
				{
					ratio = 1f; // достигли последнего тира
				}
				else
				{
					int range = nextTier.MinMoney - currentTier.MinMoney;
					if (range <= 0)
					{
						ratio = 1f; // защита от деления на ноль
					}
					else
					{
						int progress = money - currentTier.MinMoney;
						ratio = Mathf.Clamp01((float)progress / range);
					}
				}

				_moneyProgressView.SetBar(ratio);
			}
		}

		public void Dispose()
		{
			_disposable.Dispose();
		}
	}
}