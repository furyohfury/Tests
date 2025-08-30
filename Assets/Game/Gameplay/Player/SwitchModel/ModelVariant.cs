using UnityEngine;

namespace Game.Gameplay
{
	public sealed class ModelVariant : MonoBehaviour
	{
		public string ID => _id;
		[SerializeField]
		private string _id;

		public void SetActive(bool active)
		{
			gameObject.SetActive(active);
		}
	}
}