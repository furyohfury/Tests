using UnityEngine;

namespace Shaders
{
	public class ControlColor : MonoBehaviour
	{
		private Material _material;

		private void Start()
		{
			_material = GetComponent<Renderer>().material;
		}

		private void Update()
		{
			var color = _material.GetColor("_BaseColor");
// Remaining code will go here.

			float hue, sat, val;
			Color.RGBToHSV(color, out hue, out sat, out val);
			hue = Time.time * 0.25f % 1.0f;
			color = Color.HSVToRGB(hue, sat, val);
			_material.SetColor("_BaseColor", color);
		}
	}
}
