using System;
using UnityEngine;

namespace Game.Gameplay
{
	[CreateAssetMenu(
		fileName = nameof(SwitchModelsThresholdsConfig),
		menuName = "Player" + "/" + nameof(SwitchModelsThresholdsConfig))]
	public sealed class SwitchModelsThresholdsConfig : ScriptableObject
	{
		public RichStatusTier[] Tiers => _tiers;
		[SerializeField]
		private RichStatusTier[] _tiers;

		private void OnValidate()
		{
			Array.Sort(Tiers, (a, b) => a.MinMoney.CompareTo(b.MinMoney));
		}
	}
}