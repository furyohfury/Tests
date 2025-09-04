using UnityEngine;

[RequireComponent(typeof(UnitItem))]
[RequireComponent(typeof(TargetDetector))]
public class EnemyAI : MonoBehaviour
{
	private UnitItem unit;
	private TargetDetector detector;
	private Transform currentTarget;
	private UnitConfig unitConfig;

	private void Start()
	{
		unit = GetComponent<UnitItem>();
		detector = GetComponent<TargetDetector>();
		unit.teamType = TeamType.Enemy;
	}

	public void Init(UnitConfig config)
	{
		unitConfig = config;
	}

	private void Update()
	{
		currentTarget = detector.FindTarget(unit.transform.right, unit.teamType, unitConfig.range);

		if (currentTarget != null)
		{
			float distance = Vector2.Distance(transform.position, currentTarget.position);

			if (distance > unitConfig.stopDistance)
				unit.moveDirection = unit.transform.right; // двигаемся к базе или врагу
			else
				unit.moveDirection = Vector2.zero; // остановились

			if (distance <= unitConfig.range)
				unit.Shoot();
		}
		else
		{
			// если никого не видим — идем в сторону базы
			unit.moveDirection = unit.transform.right;
		}
	}
}