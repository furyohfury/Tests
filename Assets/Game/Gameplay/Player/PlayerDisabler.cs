namespace Game.Gameplay
{
	public sealed class PlayerDisabler
	{
		private readonly PlayerService _playerService;

		public PlayerDisabler(PlayerService playerService)
		{
			_playerService = playerService;
		}

		public void Enable()
		{
			var autoMoveComponent = _playerService.Player.GetComponent<AutoMoveComponent>();
			var sideMoveController = _playerService.Player.GetComponent<RunnerSwipeController>();
			autoMoveComponent.enabled = true;
			sideMoveController.enabled = true;
		}

		public void Disable()
		{
			var autoMoveComponent = _playerService.Player.GetComponent<AutoMoveComponent>();
			var sideMoveController = _playerService.Player.GetComponent<RunnerSwipeController>();
			autoMoveComponent.enabled = false;
			sideMoveController.enabled = false;
		}
	}
}