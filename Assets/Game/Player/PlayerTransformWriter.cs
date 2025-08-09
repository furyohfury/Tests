using System;
using UnityEngine;
using Zenject;

namespace Game
{
	public sealed class PlayerTransformWriter : IInitializable, IDisposable
	{
		private readonly RaceStateManager _raceStateManager;
		private readonly Transform _playerTransform;
		private readonly RecordedRaceData _recordedRaceData;
		private readonly PositionRecorder _positionRecorder = new();

		public PlayerTransformWriter(
			RecordedRaceData recordedRaceData,
			Transform playerTransform,
			RaceStateManager raceStateManager
		)
		{
			_recordedRaceData = recordedRaceData;
			_playerTransform = playerTransform;
			_raceStateManager = raceStateManager;
		}

		public void Initialize()
		{
			_raceStateManager.OnStateChanged += OnStateChanged;
		}

		private void OnStateChanged(RaceState raceState)
		{
			if (raceState is RaceState.Start)
			{
				_positionRecorder.StartWrite(_playerTransform);
			}
			else if (raceState is RaceState.Finish)
			{
				var recordedTransformDatas = _positionRecorder.StopWriting();
				_recordedRaceData.RecordedData = recordedTransformDatas;
			}
		}

		public void Dispose()
		{
			_raceStateManager.OnStateChanged -= OnStateChanged;
		}
	}
}