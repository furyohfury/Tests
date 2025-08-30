using DG.Tweening;
using UnityEngine;

namespace Game.Gameplay
{
	[RequireComponent(typeof(Collider))]
	[SelectionBase]
	public sealed class Gates : MonoBehaviour
	{
		[SerializeField]
		private GameObject _leftSide;
		[SerializeField]
		private GameObject _rightSide;
		[SerializeField]
		private float _openingAnimationDuration = 1f;

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Player _))
			{
				Open();
			}
		}

		private void Open()
		{
			var leftSideEndRotation = new Vector3(_leftSide.transform.rotation.x, 90, _leftSide.transform.rotation.z);
			_leftSide.transform.DORotate(
				leftSideEndRotation,
				_openingAnimationDuration
				);

			var rightSideEndRotation = new Vector3(_rightSide.transform.rotation.x, -90, _rightSide.transform.rotation.z);
			_rightSide.transform.DORotate(
				rightSideEndRotation,
				_openingAnimationDuration
				);
		}
	}
}