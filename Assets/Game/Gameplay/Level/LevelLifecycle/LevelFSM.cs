using R3;

namespace Game.Gameplay
{
	public sealed class LevelFSM
	{
		public readonly ReactiveProperty<ILevelState> State = new();

		private readonly LevelStateFactory _levelStateFactory;

		public LevelFSM(LevelStateFactory levelStateFactory)
		{
			_levelStateFactory = levelStateFactory;
		}

		public void SetState<T>() where T : ILevelState
		{
			State.Value = _levelStateFactory.Spawn<T>();
			State.CurrentValue.Enter();
		}
	}
}