using System;
using UnityEngine;

namespace Game
{
	public sealed class ShootComponent : MonoBehaviour
	{
		[SerializeField]
		private Transform _weaponContainer;
		[SerializeField]
		private WeaponConfig _weaponConfig;
		private GameObject _weaponModel;
		[SerializeField]
		private float _reloadTime;

		private void Awake()
		{
			if (_weaponConfig != null)
			{
				EquipWeapon(_weaponConfig);
			}
		}

		private void Update()
		{
			_reloadTime = MathF.Max(0, _reloadTime - Time.deltaTime);
		}

		public void EquipWeapon(WeaponConfig config)
		{
			if (_weaponModel != null)
			{
				Destroy(_weaponModel);
			}

			_weaponConfig = config;
			_weaponModel = _weaponConfig.Equip(_weaponContainer);
		}

		public void Shoot()
		{
			if (_weaponConfig != null)
			{
				if (_reloadTime <= 0)
				{
					_weaponConfig.Shoot();
					_reloadTime = _weaponConfig.ReloadDelay;
				}
			}
		}
	}
}