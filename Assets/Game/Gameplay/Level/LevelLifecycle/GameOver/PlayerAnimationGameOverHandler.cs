namespace Game.Gameplay
{
	public class PlayerAnimationGameOverHandler : IGameOverHandler
	{
		private readonly PlayerService _playerService;

		public PlayerAnimationGameOverHandler(PlayerService playerService)
		{
			_playerService = playerService;
		}

		public void Execute()
		{
			var playerAnimatorComponent = _playerService.Player.GetComponent<PlayerAnimatorComponent>();
			playerAnimatorComponent.SetLoseTrigger();
		}
	}
}