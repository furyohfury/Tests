using UnityEngine;

namespace Game
{
	public sealed class GhostTransformPlayer
	{
		private readonly Transform _ghostTransform;
		private readonly RecordedRaceData _recordedRaceData;
		private readonly PositionReplayer _positionReplayer = new();

		public GhostTransformPlayer(RecordedRaceData recordedRaceData, Transform ghostTransform)
		{
			_recordedRaceData = recordedRaceData;
			_ghostTransform = ghostTransform;
		}

		public void Play()
		{
			var recordedTransformDatas = _recordedRaceData.RecordedData;
			if (recordedTransformDatas != null)
			{
				_ghostTransform.gameObject.SetActive(true);
				_positionReplayer.Play(_ghostTransform, recordedTransformDatas);
			}
		}
	}
}