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
			var sideMoveController = _playerService.Player.GetComponent<PlayerMoveController>();
			sideMoveController.enabled = true;
			var moveComponent = _playerService.Player.GetComponent<MoveComponent>();
			moveComponent.enabled = true;
		}

		public void Disable()
		{
			var sideMoveController = _playerService.Player.GetComponent<PlayerMoveController>();
			sideMoveController.enabled = false;
			var moveComponent = _playerService.Player.GetComponent<MoveComponent>();
			moveComponent.enabled = false;
		}
	}
}