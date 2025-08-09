using System;
using System.Collections.Generic;
using R3;
using UnityEngine;

namespace Game
{
	public sealed class PositionReplayer : IDisposable
	{
		private readonly SerialDisposable _disposable = new();
		private int _index = 0;

		public void Play(Transform target, IList<RecordedTransformData> positionsAtTimes)
		{
			_index = 0;
			_disposable.Disposable = Observable.EveryUpdate(UnityFrameProvider.FixedUpdate)
			                                   .Subscribe(_ =>
			                                   {
				                                   if (_index >= positionsAtTimes.Count)
				                                   {
					                                   return;
				                                   }

				                                   var positionAtTime = positionsAtTimes[_index++];
				                                   var pos = positionAtTime.Position;
				                                   var rot = positionAtTime.Rotation;
				                                   target.SetPositionAndRotation(pos, rot);
			                                   });
		}

		public void Dispose()
		{
			_disposable.Dispose();
		}
	}
}