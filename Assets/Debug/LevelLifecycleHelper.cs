using Game.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace GameDebug
{
	public class LevelLifecycleHelper : MonoBehaviour
	{
		[Inject]
		private LevelFSM _levelFsm;

		[Button]
		private void StartLevel()
		{
			_levelFsm.SetState<StartLevelState>();
		}

		[Button]
		private void FinishLevel()
		{
			_levelFsm.SetState<FinishLevelState>();
		}
	}
}