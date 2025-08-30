using UnityEngine;

namespace Game.Gameplay.Level
{
	[RequireComponent(typeof(Collider))]
	[SelectionBase]
	public class CornerRotater : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _direction;

		private void OnTriggerEnter(Collider other)
		{
			other.transform.Rotate(_direction);
		}
	}
}