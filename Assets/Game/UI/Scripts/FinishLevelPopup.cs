using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
	public class FinishLevelPopup : MonoBehaviour
	{
		[SerializeField]
		private Button _nextLevelButton;

		private void OnEnable()
		{
			_nextLevelButton.onClick.AddListener(OnClicked);
		}

		private void OnClicked()
		{
			SceneManager.LoadScene("SampleScene");
		}

		private void OnDisable()
		{
			_nextLevelButton.onClick.RemoveListener(OnClicked);
		}
	}
}