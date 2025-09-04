using System;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
	[SerializeField]
	private float range = 10f;

	/// <summary>
	/// Возвращает Transform ближайшей цели (юнит или база) в указанном направлении.
	/// </summary>
	public Transform FindTarget(Vector2 direction, TeamType myTeam, float range)
	{
		RaycastHit2D[] hits = Physics2D.RaycastAll(
			transform.position,
			direction,
			range
			);

		Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));

		foreach (var hit in hits)
		{
			if (hit.collider == null) continue;

			// Проверка юнита
			var targetUnit = hit.collider.GetComponent<UnitItem>();
			if (targetUnit != null)
			{
				if (targetUnit.teamType != myTeam)
				{
					return targetUnit.transform; // враг
				}
				else
				{
					continue; // свой, пропускаем
				}
			}

			// Проверка базы
			var building = hit.collider.GetComponent<BuildingItem>();
			if (building != null)
			{
				if (myTeam == TeamType.Enemy) // только враги могут стрелять в базу
				{
					return building.transform;
				}
			}
		}

		return null;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, transform.position + transform.right * range);
	}
}