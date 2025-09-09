using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
	public sealed class SwitchModelsComponent : MonoBehaviour
	{
		public IReadOnlyList<ModelVariant> Variants => _variants;
		public ModelVariant ActiveVariant => _activeVariant;

		[SerializeField]
		private ModelVariant[] _variants;
		private ModelVariant _activeVariant;

		private void Awake()
		{
			_activeVariant = Variants.Single(variant => variant.gameObject.activeSelf);
		}

		[Button]
		public void SetModel(ModelVariant variant)
		{
			if (variant == ActiveVariant)
			{
				return;
			}

			var animatorState = ActiveVariant.GetAnimatorStateSnapshot();
			ActiveVariant.SetActive(false);
			variant.SetActive(true);
			variant.SyncAnimator(animatorState);
			_activeVariant = variant;
		}
	}
}