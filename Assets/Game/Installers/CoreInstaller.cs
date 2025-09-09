using Game.Gameplay;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
	public sealed class CoreInstaller : MonoInstaller
	{
		[SerializeField]
		private Player _player;
		[SerializeField]
		private SwitchModelsThresholdsConfig _switchModelsThresholdsConfig;

		public override void InstallBindings()
		{
			Container.BindInstance(new PlayerService() { Player = _player })
			         .AsSingle();

			Container.Bind<MoneyStorage>()
			         .AsSingle();

			Container.Bind<PlayerDisabler>()
			         .AsSingle();

			Container.BindInterfacesTo<SwitchModelsController>()
			         .AsSingle();

			Container.Bind<SwitchModelsThresholdsConfig>()
			         .FromInstance(_switchModelsThresholdsConfig)
			         .AsSingle();

			Container.Bind<Camera>()
			         .FromInstance(Camera.main)
			         .AsSingle();
		}
	}
}