using config;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : GenericSingletonClass<SpawnManager>
{
	public BuildingItem Base => _base;
	private BuildingItem _base;

	[Header("Base")]
	[SerializeField]
	private Transform _baseSpawnContainer;
	[SerializeField]
	private BuildingItem _basePrefab;
	[SerializeField]
	private BuildingConfig _buildingConfig;
	[Header("Units")]
	[SerializeField]
	private Transform _playerLeftSpawnPoint;
	[SerializeField]
	private Transform _playerRightSpawnPoint;
	[SerializeField]
	private Transform _enemyLeftSpawnPoint;
	[SerializeField]
	private Transform _enemyRightSpawnPoint;
	[SerializeField]
	private Transform _playerUnitsContainer;
	[SerializeField]
	private Transform _enemyUnitsContainer;
	[SerializeField]
	private UnitItem _unitPrefab;
	[SerializeField]
	private UnitConfig _unitConfig;
	[SerializeField]
	private int _playerLayer = 7;
	[SerializeField]
	private int _enemyLayer = 8;
	[Header("Enemy")]
	[SerializeField]
	private Color _enemyColor = Color.red;

	protected override void Awake()
	{
		base.Awake();
		_base = SpawnBuilding();
		InitBuilding(_base, _buildingConfig);
	}

	public void SpawnPlayerUnitLeft()
	{
		var unit = SpawnUnit(_playerLeftSpawnPoint.position, GetMirrorRotation(), _playerUnitsContainer);
		unit.teamType = TeamType.Player;
		unit.gameObject.layer = _playerLayer;
		InitUnit(unit, _unitConfig);
		var playerAi = unit.AddComponent<PlayerAi>();
		playerAi.Init(_unitConfig);
	}

	public void SpawnPlayerUnitRight()
	{
		var unit = SpawnUnit(_playerRightSpawnPoint.position, Quaternion.identity, _playerUnitsContainer);
		unit.teamType = TeamType.Player;
		unit.gameObject.layer = _playerLayer;
		InitUnit(unit, _unitConfig);
		var playerAi = unit.AddComponent<PlayerAi>();
		playerAi.Init(_unitConfig);
	}

	public void SpawnEnemyUnitLeft()
	{
		UnitItem unit = SpawnUnit(_enemyLeftSpawnPoint.position, Quaternion.identity, _enemyUnitsContainer);
		unit.teamType = TeamType.Enemy;
		unit.gameObject.layer = _enemyLayer;
		InitUnit(unit, _unitConfig);
		PaintUnit(unit, _enemyColor);
		var enemyAI = unit.AddComponent<EnemyAI>();
		enemyAI.Init(_unitConfig);
	}

	public void SpawnEnemyUnitRight()
	{
		UnitItem unit = SpawnUnit(_enemyRightSpawnPoint.position, GetMirrorRotation(), _enemyUnitsContainer);
		unit.teamType = TeamType.Enemy;
		unit.gameObject.layer = _enemyLayer;
		InitUnit(unit, _unitConfig);
		PaintUnit(unit, _enemyColor);
		var enemyAI = unit.AddComponent<EnemyAI>();
		enemyAI.Init(_unitConfig);
	}

	private UnitItem SpawnUnit(Vector3 position, Quaternion rotation, Transform container)
	{
		return Instantiate(_unitPrefab, position, rotation, container);
	}

	private void InitUnit(UnitItem unit, UnitConfig unitConfig)
	{
		unit.Init(unitConfig);
	}

	private Quaternion GetMirrorRotation()
	{
		return Quaternion.Euler(new Vector3(0, -180, 0));
	}

	private void PaintUnit(UnitItem unit, Color color)
	{
		unit.spriteRenderer.color = color;
	}

	private BuildingItem SpawnBuilding()
	{
		BuildingItem baseItem = Instantiate(_basePrefab, _baseSpawnContainer);
		return baseItem;
	}

	private void InitBuilding(BuildingItem baseItem, BuildingConfig config)
	{
		baseItem.Init(config);
	}
}