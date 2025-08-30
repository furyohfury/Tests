using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.UI
{
	public class GameOverPopup : MonoBehaviour
	{
		[SerializeField]
		private Button _restartButton;

		private void OnEnable()
		{
			_restartButton.onClick.AddListener(OnClicked);
		}

		private void OnClicked()
		{
			SceneManager.LoadScene("SampleScene");
		}

		private void OnDisable()
		{
			_restartButton.onClick.RemoveListener(OnClicked);
		}
	}
}