using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	public event Action<float> OnHPChange;
	public event Action OnDie;

	[field: SerializeField]
	public float HP { get; private set; }

	public int MaxHP { get; private set; }

	public void Init(int maxHP)
	{
		MaxHP = maxHP;
		HP = MaxHP;
		OnHPChange?.Invoke(HP);
	}

	public void DoDamage(int damage)
	{
		HP = Mathf.Max(0, HP - damage);
		OnHPChange?.Invoke(HP);
		if (HP <= 0)
		{
			OnDie?.Invoke();
		}
	}
}