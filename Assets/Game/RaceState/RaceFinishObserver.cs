using System;
using R3;
using R3.Triggers;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class RaceFinishObserver : IInitializable, IDisposable
	{
		private readonly RaceStateManager _raceStateManager;
		private readonly Collider _finishCollider;
		private readonly SerialDisposable _serialDisposable = new();
		private const string PLAYER = "Player";

		public RaceFinishObserver(Collider finishCollider, RaceStateManager raceStateManager)
		{
			_finishCollider = finishCollider;
			_raceStateManager = raceStateManager;
		}

		public void Initialize()
		{
			_serialDisposable.Disposable = _finishCollider.OnTriggerEnterAsObservable()
			                                              .Subscribe(OnCrossedFinish);
		}

		private void OnCrossedFinish(Collider other)
		{
			if (other.CompareTag(PLAYER))
			{
				_raceStateManager.SetState(RaceState.Finish);
			}
		}

		public void Dispose()
		{
			_serialDisposable.Dispose();
		}
	}
}