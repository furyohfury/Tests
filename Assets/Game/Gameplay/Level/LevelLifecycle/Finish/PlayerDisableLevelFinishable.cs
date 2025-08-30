namespace Game.Gameplay
{
	public class PlayerDisableLevelFinishable : ILevelFinishable
	{
		private readonly PlayerDisabler _playerDisabler;

		public PlayerDisableLevelFinishable(PlayerDisabler playerDisabler)
		{
			_playerDisabler = playerDisabler;
		}

		public void Execute()
		{
			_playerDisabler.Disable();
		}
	}
}