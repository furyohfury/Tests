using UnityEngine;

[RequireComponent(typeof(UnitItem))]
[RequireComponent(typeof(TargetDetector))]
public class PlayerAi : MonoBehaviour
{
	private UnitItem unit;
	private TargetDetector detector;
	private Transform currentTarget;
	private UnitConfig unitConfig;

	private void Start()
	{
		unit = GetComponent<UnitItem>();
		detector = GetComponent<TargetDetector>();
		unit.teamType = TeamType.Player;
		unit.moveDirection = Vector2.zero; // игроки стоят на месте
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
			if (distance <= unitConfig.range)
				unit.Shoot();
		}
	}
}