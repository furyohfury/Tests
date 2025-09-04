using UnityEngine;
using UnityEngine.UI;

public class SpawnManagerUi : MonoBehaviour
{
	[SerializeField]
	private SpawnManager _spawnManager;
	[Header("Buttons")]
	[SerializeField]
	private Button _spawnPlayerUnitLeftButton;
	[SerializeField]
	private Button _spawnPlayerUnitRightButton;
	[SerializeField]
	private Button _spawnEnemyUnitLeftButton;
	[SerializeField]
	private Button _spawnEnemyUnitRightButton;

	private void OnEnable()
	{
		_spawnPlayerUnitLeftButton.onClick.AddListener(OnSpawnPlayerUnitLeftClicked);
		_spawnPlayerUnitRightButton.onClick.AddListener(OnSpawnPlayerUnitRightClicked);
		_spawnEnemyUnitLeftButton.onClick.AddListener(OnSpawnEnemyUnitLeftClicked);
		_spawnEnemyUnitRightButton.onClick.AddListener(OnSpawnEnemyUnitRightClicked);
	}

	private void OnSpawnPlayerUnitLeftClicked()
	{
		_spawnManager.SpawnPlayerUnitLeft();
	}

	private void OnSpawnPlayerUnitRightClicked()
	{
		_spawnManager.SpawnPlayerUnitRight();
	}

	private void OnSpawnEnemyUnitLeftClicked()
	{
		_spawnManager.SpawnEnemyUnitLeft();
	}

	private void OnSpawnEnemyUnitRightClicked()
	{
		_spawnManager.SpawnEnemyUnitRight();
	}

	private void OnDisable()
	{
		_spawnPlayerUnitLeftButton.onClick.RemoveListener(OnSpawnPlayerUnitLeftClicked);
		_spawnPlayerUnitRightButton.onClick.RemoveListener(OnSpawnPlayerUnitRightClicked);
		_spawnEnemyUnitLeftButton.onClick.RemoveListener(OnSpawnEnemyUnitLeftClicked);
		_spawnEnemyUnitRightButton.onClick.RemoveListener(OnSpawnEnemyUnitRightClicked);
	}
}