using TMPro;
using UnityEngine;

namespace Game.UI
{
	public sealed class MoneyProgressView : MonoBehaviour
	{
		[SerializeField]
		private ProgressBar _progressBar;

		[SerializeField]
		private TMP_Text _tmpText;

		public void SetBar(float ratio)
		{
			_progressBar.SetBar(ratio);
		}

		public void SetText(string text)
		{
			_tmpText.SetText(text);
		}
	}
}