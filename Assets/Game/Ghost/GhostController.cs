using System;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class GhostController : IInitializable, IDisposable
	{
		private readonly RaceStateManager _raceStateManager;
		private readonly GhostTransformPlayer _ghostTransformPlayer;
		private readonly Transform _ghostTransform;
		private Vector3 _initialPosition;
		private Quaternion _initialRotation;

		public GhostController(RaceStateManager raceStateManager, GhostTransformPlayer ghostTransformPlayer, Transform ghostTransform)
		{
			_raceStateManager = raceStateManager;
			_ghostTransformPlayer = ghostTransformPlayer;
			_ghostTransform = ghostTransform;
		}

		public void Initialize()
		{
			_initialPosition = _ghostTransform.transform.position;
			_initialRotation = _ghostTransform.transform.rotation;
			_raceStateManager.OnStateChanged += OnRaceStarted;
		}

		private void OnRaceStarted(RaceState raceState)
		{
			if (raceState is RaceState.Start)
			{
				_ghostTransformPlayer.Play();
			}
			else if (raceState is RaceState.Reset)
			{
				_ghostTransform.position = _initialPosition;
				_ghostTransform.rotation = _initialRotation;
			}
		}

		public void Dispose()
		{
			_raceStateManager.OnStateChanged -= OnRaceStarted;
		}
	}
}