using System;
using System.Linq;
using R3;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
	public sealed class SwitchModelsController : IInitializable, IDisposable
	{
		private readonly PlayerService _playerService;
		private readonly SwitchModelsThresholdsConfig _thresholds;
		private readonly MoneyStorage _moneyStorage;
		private IDisposable _disposable;

		public SwitchModelsController(SwitchModelsThresholdsConfig thresholds, PlayerService playerService, MoneyStorage moneyStorage)
		{
			_thresholds = thresholds;
			_playerService = playerService;
			_moneyStorage = moneyStorage;
		}

		public void Initialize()
		{
			_disposable = _moneyStorage.Money
			                           .Subscribe(OnMoneyChanged);
		}

		private void OnMoneyChanged(int money)
		{
			// 1. Находим последний Tier, у которого MinMoney <= текущие деньги
			var tier = _thresholds.Tiers.LastOrDefault(t => money >= t.MinMoney);
			if (tier == default)
				return;

			// 2. Ищем Variant с таким же ID
			var switcher = _playerService.Player.GetComponent<SwitchModelsComponent>();
			var targetVariant = switcher.Variants.FirstOrDefault(v => v.ID == tier.VariantId);
			if (targetVariant == null)
			{
				Debug.LogWarning($"[SwitchModelsSystem] Variant with ID={tier.VariantId} not found!");
				return;
			}

			// 3. Переключаем модель
			switcher.SetModel(targetVariant);
		}

		public void Dispose()
		{
			_disposable.Dispose();
		}
	}
}