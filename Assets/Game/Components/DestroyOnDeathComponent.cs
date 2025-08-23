using UnityEngine;

namespace Game
{
	public sealed class DestroyOnDeathComponent : MonoBehaviour
	{
		[SerializeField]
		private LifeComponent _lifeComponent;

		private void OnEnable()
		{
			_lifeComponent.OnHealthChanged += OnHealthChanged;
		}

		private void OnHealthChanged(int hp)
		{
			if (hp <= 0)
			{
				Destroy(gameObject);
			}
		}

		private void OnDisable()
		{
			_lifeComponent.OnHealthChanged += OnHealthChanged;
		}
	}
}