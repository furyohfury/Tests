using UnityEngine;

namespace Game
{
	public sealed class RotationComponent : MonoBehaviour
	{
		[SerializeField]
		private Transform _transform;

		public void Rotate(Vector3 direction)
		{
			_transform.rotation = Quaternion.LookRotation(direction);
		}
	}
}