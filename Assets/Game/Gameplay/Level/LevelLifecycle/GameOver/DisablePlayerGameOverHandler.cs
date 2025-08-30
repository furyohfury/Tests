namespace Game.Gameplay
{
	public class DisablePlayerGameOverHandler : IGameOverHandler
	{
		private readonly PlayerDisabler _playerDisabler;

		public DisablePlayerGameOverHandler(PlayerDisabler playerDisabler)
		{
			_playerDisabler = playerDisabler;
		}

		public void Execute()
		{
			_playerDisabler.Disable();
		}
	}
}