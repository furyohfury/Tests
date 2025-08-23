using UnityEngine;

namespace Game
{
	public sealed class FirePointComponent : MonoBehaviour
	{
		public Transform FirePoint => _firePoint;
		[SerializeField]
		private Transform _firePoint;
	}
}