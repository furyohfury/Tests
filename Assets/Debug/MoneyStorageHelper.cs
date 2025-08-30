using Game.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameDebug
{
	public class MoneyStorageHelper : MonoBehaviour
	{
		[ShowInInspector]
		public int Money => _moneyStorage.Money.CurrentValue;

		[Inject]
		private MoneyStorage _moneyStorage;
	}
}