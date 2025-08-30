using System;
using Game.Gameplay;
using R3;
using TMPro;
using Zenject;

namespace Game.UI
{
	public sealed class MoneyCounterPresenter : IInitializable, IDisposable
	{
		private readonly TMP_Text _moneyText;
		private readonly MoneyStorage _moneyStorage;
		private IDisposable _disposable;

		public MoneyCounterPresenter(TMP_Text moneyText, MoneyStorage moneyStorage)
		{
			_moneyText = moneyText;
			_moneyStorage = moneyStorage;
		}

		public void Initialize()
		{
			_disposable = _moneyStorage.Money
			                           .Subscribe(UpdateMoneyText);
		}

		private void UpdateMoneyText(int value)
		{
			_moneyText.text = value.ToString();
		}

		public void Dispose()
		{
			_disposable.Dispose();
		}
	}
}