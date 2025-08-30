using R3;

namespace Game.Gameplay
{
	public sealed class MoneyStorage
	{
		public readonly ReactiveProperty<int> Money = new();
	}
}