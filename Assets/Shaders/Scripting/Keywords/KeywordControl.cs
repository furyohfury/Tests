using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Shaders.Keywords
{
	public class KeywordControl : MonoBehaviour
	{
		[SerializeField]
		private Renderer _renderer;
		private Material _rendererMaterial;
		[SerializeField]
		private bool overrideRed;

		private void Awake()
		{
			_rendererMaterial = _renderer.material;
		}

		private void Update()
		{
			// _rendererMaterial.SetKeyword(new LocalKeyword(_rendererMaterial.shader, "OVERRIDE_RED_ON"), overrideRed);
			if (overrideRed)
			{
				_rendererMaterial.EnableKeyword("OVERRIDE_RED_ON");
			}
			else
			{
				_rendererMaterial.DisableKeyword("OVERRIDE_RED_ON");
			}
		}
	}
}
