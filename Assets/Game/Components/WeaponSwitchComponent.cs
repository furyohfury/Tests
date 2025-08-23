using UnityEngine;

namespace Game
{
	public sealed class WeaponSwitchComponent : MonoBehaviour
	{
		[SerializeField]
		private ShootComponent _shootComponent;
		[SerializeField]
		private WeaponConfig[] _weapons;
		private int _currentIndex;

		public void Switch()
		{
			var index = _currentIndex++ % _weapons.Length;
			_shootComponent.EquipWeapon(_weapons[index]);
		}
	}
}