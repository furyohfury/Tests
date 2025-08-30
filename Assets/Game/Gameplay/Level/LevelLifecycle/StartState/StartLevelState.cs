namespace Game.Gameplay
{
	public class StartLevelState : ILevelState
	{
		private readonly ILevelStartable[] _startables;

		public StartLevelState(ILevelStartable[] startables)
		{
			_startables = startables;
		}

		public void Enter()
		{
			for (int i = 0, count = _startables.Length; i < count; i++)
			{
				_startables[i].Execute();
			}
		}
	}
}