namespace Game.Gameplay
{
	public class PlayerLevelStartable : ILevelStartable
	{
		private readonly PlayerDisabler _playerDisabler;

		public PlayerLevelStartable(PlayerDisabler playerDisabler)
		{
			_playerDisabler = playerDisabler;
		}

		public void Execute()
		{
			_playerDisabler.Enable();
		}
	}
}