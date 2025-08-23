using UnityEngine;

namespace Game
{
	[CreateAssetMenu(fileName = "ShotgunConfig", menuName = "ShotgunConfig")]
	public sealed class ShotgunConfig : WeaponConfig
	{
		[SerializeField]
		private int _numberOfBullets = 3;
		[SerializeField]
		private int _spreadMaxAngLe = 8;

		public override void Shoot()
		{
			var firePoint = Weapon.GetComponent<FirePointComponent>().FirePoint;
			for (var i = 0; i < _numberOfBullets; i++)
			{
				var position = firePoint.position;
				var rotation = firePoint.rotation * Quaternion.Euler(new Vector3(0, Random.Range(0, _spreadMaxAngLe), 0));
				Instantiate(_projectilePrefab, position, rotation);
			}
		}
	}
}