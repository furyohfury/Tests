namespace Game.Gameplay
{
	public class PlayerAnimatorLevelFinishable : ILevelFinishable
	{
		private readonly PlayerService _playerService;

		public PlayerAnimatorLevelFinishable(PlayerService playerService)
		{
			_playerService = playerService;
		}

		public void Execute()
		{
			var playerAnimatorComponent = _playerService.Player.GetComponent<PlayerAnimatorComponent>();
			playerAnimatorComponent.SetWinTrigger();
		}
	}
}