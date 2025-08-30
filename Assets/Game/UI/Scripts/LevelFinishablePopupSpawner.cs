using Game.Gameplay;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.UI
{
	public sealed class LevelFinishablePopupSpawner : ILevelFinishable
	{
		private readonly FinishLevelPopup _finishLevelPopup;
		private readonly Transform _container;

		public LevelFinishablePopupSpawner(FinishLevelPopup finishLevelPopup, Transform container)
		{
			_finishLevelPopup = finishLevelPopup;
			_container = container;
		}

		public void Execute()
		{
			Object.Instantiate(_finishLevelPopup, _container);
		}
	}
}