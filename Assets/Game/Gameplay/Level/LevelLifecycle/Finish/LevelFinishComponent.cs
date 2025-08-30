using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
	[RequireComponent(typeof(Collider))]
	public sealed class LevelSetFinishComponent : MonoBehaviour
	{
		private LevelFSM _levelFsm;

		[Inject]
		public void Construct(LevelFSM levelFsm)
		{
			_levelFsm = levelFsm;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Player _))
			{
				_levelFsm.SetState<FinishLevelState>();
			}
		}
	}
}