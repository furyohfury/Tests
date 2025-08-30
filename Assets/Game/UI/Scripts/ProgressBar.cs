using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	public sealed class ProgressBar : MonoBehaviour
	{
		[SerializeField]
		private Image _bar;

		public void SetBar(float ratio)
		{
			_bar.fillAmount = Mathf.Clamp01(ratio);
		}
	}
}