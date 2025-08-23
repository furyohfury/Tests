using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "PistolConfig", menuName = "PistolConfig")]
	public sealed class PistolConfig : WeaponConfig
	{
		public override void Shoot()
		{
			var firePoint = Weapon.GetComponent<FirePointComponent>().FirePoint;
			Instantiate(_projectilePrefab, firePoint.position, firePoint.rotation);
		}
	}
}