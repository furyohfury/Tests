using Zenject;

namespace Game.Gameplay
{
	public class LevelStateFactory
	{
		private readonly DiContainer _diContainer;

		public LevelStateFactory(DiContainer diContainer)
		{
			_diContainer = diContainer;
		}

		public T Spawn<T>() where T : ILevelState
		{
			return _diContainer.Instantiate<T>();
		}
	}
}