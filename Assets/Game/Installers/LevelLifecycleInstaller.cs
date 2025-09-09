using Game.Gameplay;
using Zenject;

namespace Game.Installers
{
	public sealed class LevelLifecycleInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<ILevelStartable>()
			         .To<PlayerLevelStartable>()
			         .AsCached();

			Container.Bind<ILevelFinishable>()
			         .To<PlayerDisableLevelFinishable>()
			         .AsCached();

			Container.Bind<ILevelFinishable>()
			         .To<PlayerAnimatorLevelFinishable>()
			         .AsCached();

			Container.Bind<IGameOverHandler>()
			         .To<DisablePlayerGameOverHandler>()
			         .AsCached();

			Container.Bind<IGameOverHandler>()
			         .To<PlayerAnimationGameOverHandler>()
			         .AsCached();

			Container.BindInterfacesTo<GameOverObserver>()
			         .AsSingle();

			Container.Bind<LevelStateFactory>()
			         .AsSingle();

			Container.Bind<LevelFSM>()
			         .AsSingle();
		}
	}
}