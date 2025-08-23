using UnityEngine;

namespace Game
{
	public class EnemySimpleChaseAI : MonoBehaviour
	{
		[SerializeField]
		private MoveComponent _moveComponent;
		[SerializeField]
		private float _detectRange;
		[SerializeField]
		private LayerMask _targetLayerMask;
		private bool _detected;
		private GameObject _target;
		private readonly Collider[] _colliders = new Collider[1];

		private void Update()
		{
			DetectTarget();
		}

		private void DetectTarget()
		{
			if (_detected)
			{
				return;
			}

			var size = Physics.OverlapSphereNonAlloc(transform.position, _detectRange, _colliders, _targetLayerMask);
			if (size > 0)
			{
				_target = _colliders[0].gameObject;
				_detected = true;
			}
		}

		private void FixedUpdate()
		{
			ChaseTarget();
		}

		private void ChaseTarget()
		{
			if (_detected == false)
			{
				return;
			}

			_moveComponent.Move(_target.transform.position - transform.position);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, _detectRange);
		}
	}
}