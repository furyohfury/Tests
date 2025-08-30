using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay
{
	public sealed class SwitchModelsComponent : MonoBehaviour
	{
		public IReadOnlyList<ModelVariant> Variants => _variants;

		[SerializeField]
		private ModelVariant[] _variants;
		private ModelVariant _initialModel;

		private void Awake()
		{
			_initialModel = Variants.Single(variant => variant.gameObject.activeSelf);
		}

		[Button]
		public void SetModel(ModelVariant variant)
		{
			if (variant == _initialModel)
			{
				return;
			}
			
			_initialModel.SetActive(false);
			variant.SetActive(true);
			_initialModel = variant;
		}
	}
}