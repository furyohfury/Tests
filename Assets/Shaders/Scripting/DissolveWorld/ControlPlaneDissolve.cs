using UnityEngine;

namespace Shaders.DissolveWorld
{
	public class ControlPlaneDissolve : MonoBehaviour
	{
		[SerializeField]
		private Renderer _renderer;
		[SerializeField]
		private Transform _planeTransform;
		private Material _rendererMaterial;

		private void Start()
		{
			_rendererMaterial = _renderer.material;
		}

		private void Update()
		{
			_rendererMaterial.SetVector("_PlaneOrigin", _planeTransform.position);
			_rendererMaterial.SetVector("_PlaneNormal", _planeTransform.up);
		}
	}
}
