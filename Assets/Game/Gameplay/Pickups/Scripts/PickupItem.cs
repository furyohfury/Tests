using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
	[RequireComponent(typeof(Collider))]
	[SelectionBase]
	public sealed class PickupItem : MonoBehaviour
	{
		[SerializeField]
		private int _cost;
		private MoneyStorage _moneyStorage;

		[Inject]
		private void Construct(MoneyStorage moneyStorage)
		{
			_moneyStorage = moneyStorage;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Player _))
			{
				_moneyStorage.Money.Value += _cost;
				Destroy(gameObject);
			}
		}
	}
}