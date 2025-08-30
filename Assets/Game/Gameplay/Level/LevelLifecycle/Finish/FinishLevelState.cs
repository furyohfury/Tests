namespace Game.Gameplay
{
	public class FinishLevelState : ILevelState
	{
		private readonly ILevelFinishable[] _finishables;

		public FinishLevelState(ILevelFinishable[] finishables)
		{
			_finishables = finishables;
		}

		public void Enter()
		{
			for (int i = 0, count = _finishables.Length; i < count; i++)
			{
				_finishables[i].Execute();
			}
		}
	}
}