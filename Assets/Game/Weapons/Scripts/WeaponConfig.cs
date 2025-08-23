using UnityEngine;

namespace Game
{
	public abstract class WeaponConfig : ScriptableObject
	{
		public float ReloadDelay => _reloadDelay;

		[SerializeField]
		protected GameObject _weaponPrefab;
		[SerializeField]
		protected GameObject _projectilePrefab;
		[SerializeField]
		protected float _reloadDelay = 1f;
		protected GameObject Weapon;

		public GameObject Equip(Transform container)
		{
			return Weapon = Instantiate(_weaponPrefab, container);
		}

		public abstract void Shoot();
	}
}