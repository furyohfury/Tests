using Game.Gameplay;
using Game.UI;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
	public sealed class UIInstaller : MonoInstaller
	{
		[SerializeField] [Required]
		private MoneyProgressView _moneyProgressView;
		[SerializeField] [Required]
		private MoneyFlyText _positiveMoneyViewPrefab;
		[SerializeField] [Required]
		private MoneyFlyText _negativeMoneyViewPrefab;
		[SerializeField] [Required]
		private Transform _popupsContainer;
		[SerializeField] [Required]
		private TMP_Text _moneyCountText;
		[SerializeField] [Required]
		private FinishLevelPopup _finishLevelPopupPrefab;
		[SerializeField] [Required]
		private GameOverPopup _gameOverPopupPrefab;
		[SerializeField] [Required]
		private GameObject _swipeMessageUI;

		public override void InstallBindings()
		{
			Container.Bind<MoneyProgressView>()
			         .FromInstance(_moneyProgressView)
			         .AsSingle();

			Container.BindInterfacesTo<MoneyProgressPresenter>()
			         .AsSingle();

			Container.Bind<FlyingMoneyViewFactory>()
			         .AsSingle()
			         .WithArguments(_positiveMoneyViewPrefab, _negativeMoneyViewPrefab, _popupsContainer);

			Container.BindInterfacesTo<FlyingMoneyController>()
			         .AsSingle();

			Container.BindInterfacesTo<MoneyCounterPresenter>()
			         .AsSingle()
			         .WithArguments(_moneyCountText);

			Container.Bind<FinishLevelPopup>()
			         .FromInstance(_finishLevelPopupPrefab)
			         .AsSingle();

			Container.Bind<GameOverPopup>()
			         .FromInstance(_gameOverPopupPrefab)
			         .AsSingle();

			Container.Bind<ILevelFinishable>()
			         .To<LevelFinishablePopupSpawner>()
			         .AsCached()
			         .WithArguments(_popupsContainer);

			Container.Bind<ILevelStartable>()
			         .To<RemoveSwipeMessageLevelStartable>()
			         .AsCached()
			         .WithArguments(_swipeMessageUI);

			Container.Bind<IGameOverHandler>()
			         .To<SpawnPopupGameOverHandler>()
			         .AsCached()
			         .WithArguments(_popupsContainer);
		}
	}
}