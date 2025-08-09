using System;
using System.Collections.Generic;
using R3;
using UnityEngine;

namespace Game
{
	public sealed class PositionRecorder : IDisposable
	{
		private List<RecordedTransformData> _positionAtTimes;

		private readonly CompositeDisposable _disposable = new();

		public void StartWrite(Transform target)
		{
			_positionAtTimes = new List<RecordedTransformData>();
			Observable.EveryUpdate(UnityFrameProvider.FixedUpdate)
			          .Subscribe(_ => WritePosition(target))
			          .AddTo(_disposable);
		}

		private void WritePosition(Transform target)
		{
			var posAtTime = new RecordedTransformData(target.position, target.rotation);
			_positionAtTimes.Add(posAtTime);
		}

		public List<RecordedTransformData> StopWriting()
		{
			_disposable.Clear();
			return _positionAtTimes;
		}

		public void Dispose()
		{
			_disposable.Dispose();
		}
	}
}