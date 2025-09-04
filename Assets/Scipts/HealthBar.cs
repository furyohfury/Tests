using UnityEngine;

public sealed class HealthBar : MonoBehaviour
{
	[SerializeField]
	private Health _health;
	[SerializeField]
	private Transform _barTransform;

	private void OnEnable()
	{
		_health.OnHPChange += OnHPChanged;
	}

	private void OnHPChanged(float hp)
	{
		SetViewRatio(hp / _health.MaxHP);
	}

	private void SetViewRatio(float ratio)
	{
		var scale = _barTransform.localScale;
		scale.x = ratio;
		_barTransform.localScale = scale;
	}

	private void OnDisable()
	{
		_health.OnHPChange -= OnHPChanged;
	}
}