using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
	public sealed class CoreInstaller : MonoInstaller
	{
		[SerializeField]
		private Transform _ghostTransform;
		[SerializeField]
		private GameObject _playerGameObject;
		[SerializeField]
		private Collider _finishLineCollider;
		[SerializeField]
		private Button _startButton;
		[SerializeField]
		private Button _resetButton;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<RaceStateManager>()
			         .AsSingle();

			Container.BindInterfacesAndSelfTo<GhostTransformPlayer>()
			         .AsSingle()
			         .WithArguments(_ghostTransform);

			Container.BindInterfacesAndSelfTo<GhostController>()
			         .AsSingle()
			         .WithArguments(_ghostTransform);

			Container.BindInterfacesAndSelfTo<PlayerController>()
			         .AsSingle()
			         .WithArguments(_playerGameObject);

			Container.BindInterfacesAndSelfTo<PlayerTransformWriter>()
			         .AsSingle()
			         .WithArguments(_playerGameObject.transform);

			Container.BindInterfacesAndSelfTo<RaceFinishObserver>()
			         .AsSingle()
			         .WithArguments(_finishLineCollider);

			Container.BindInterfacesAndSelfTo<StartButtonController>()
			         .AsSingle()
			         .WithArguments(_startButton);

			Container.BindInterfacesAndSelfTo<ResetButtonController>()
			         .AsSingle()
			         .WithArguments(_resetButton);

			Container.Bind<RecordedRaceData>()
			         .AsSingle();
		}
	}
}