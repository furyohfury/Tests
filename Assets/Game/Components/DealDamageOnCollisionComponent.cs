using System;
using UnityEngine;

namespace Game
{
	[RequireComponent(typeof(Collider))]
	public sealed class DealDamageOnCollisionComponent : MonoBehaviour
	{
		[SerializeField]
		private int _damage;

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent(out LifeComponent lifeComponent))
			{
				lifeComponent.TakeDamage(_damage);
			}
		}
	}
}