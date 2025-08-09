using System.Collections.Generic;
using Game;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDebug
{
	public class PositionPlayerDebugHelper : MonoBehaviour
	{
		[SerializeField]
		private GameObject _writeTarget;
		[SerializeField]
		private GameObject _playTarget;
		private readonly PositionRecorder _positionRecorder = new();
		private readonly PositionReplayer _positionReplayer = new();
		private List<RecordedTransformData> _positionAtTimes;

		[Button]
		private void StartWriting()
		{
			_positionRecorder.StartWrite(_writeTarget.transform);
		}

		[Button]
		private void StopWriting()
		{
			_positionAtTimes = _positionRecorder.StopWriting();
		}

		[Button]
		private void Replay()
		{
			if (_positionAtTimes != null)
			{
				_positionReplayer.Play(_playTarget.transform, _positionAtTimes);
			}
		}

		private void OnDisable()
		{
			DisposePosServices();
		}

		[Button]
		private void DisposePosServices()
		{
			_positionRecorder.Dispose();
			_positionReplayer.Dispose();
		}
	}
}