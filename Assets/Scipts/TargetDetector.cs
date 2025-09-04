using System;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
	[SerializeField]
	private float detectRange = 50f;

	public Transform FindTarget(Vector2 direction, TeamType myTeam)
	{
		RaycastHit2D[] hits = Physics2D.RaycastAll(
			transform.position,
			direction,
			detectRange
			);

		Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

		foreach (var hit in hits)
		{
			if (hit.collider == null)
			{
				continue;
			}

			if (hit.collider.TryGetComponent(out UnitItem targetUnit))
			{
				if (IsEnemy(myTeam, targetUnit))
				{
					return targetUnit.transform;
				}

				continue;
			}

			if (hit.collider.TryGetComponent(out BuildingItem building))
			{
				if (myTeam == TeamType.Enemy)
				{
					return building.transform;
				}
			}
		}

		return null;
	}

	private static bool IsEnemy(TeamType myTeam, UnitItem targetUnit)
	{
		return targetUnit.teamType != myTeam;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, transform.position + transform.right * detectRange);
	}
}