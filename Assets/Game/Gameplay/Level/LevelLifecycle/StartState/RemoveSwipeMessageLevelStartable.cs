using UnityEngine;

namespace Game.Gameplay
{
	public class RemoveSwipeMessageLevelStartable : ILevelStartable
	{
		private readonly GameObject _messageView;

		public RemoveSwipeMessageLevelStartable(GameObject messageView)
		{
			_messageView = messageView;
		}

		public void Execute()
		{
			_messageView.SetActive(false);
		}
	}
}