using UnityEngine;

namespace Game
{
	public sealed class PlayerDeadObserver : MonoBehaviour
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
				Time.timeScale = 0;
			}
		}

		private void OnDisable()
		{
			_lifeComponent.OnHealthChanged += OnHealthChanged;
		}
	}
}