using UnityEngine;

namespace Game
{
	public struct RecordedTransformData
	{
		public Vector3 Position;
		public Quaternion Rotation;

		public RecordedTransformData(Vector3 position, Quaternion rotation)
		{
			Position = position;
			Rotation = rotation;
		}
	}
}