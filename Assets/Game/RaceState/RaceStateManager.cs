using System;

namespace Game
{
	public sealed class RaceStateManager
	{
		public event Action<RaceState> OnStateChanged;

		public void SetState(RaceState state)
		{
			OnStateChanged?.Invoke(state);
		}
	}
}