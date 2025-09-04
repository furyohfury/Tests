using UnityEngine;

public sealed class GameOverObserver : MonoBehaviour
{
	[SerializeField]
	private SpawnManager _spawnManager;
	[SerializeField]
	private GameObject _gameOverMessage;

	private void Start()
	{
		_spawnManager.Base.health.OnDie += OnBaseDie;
	}

	private void OnBaseDie()
	{
		Time.timeScale = 0;
		_gameOverMessage.SetActive(true);
	}

	private void OnDestroy()
	{
		_spawnManager.Base.health.OnDie -= OnBaseDie;
	}
}