using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
	public sealed class MoneyFlyText : MonoBehaviour
	{
		[SerializeField]
		private Image _icon;
		[SerializeField]
		private TMP_Text _tmpText;
		[SerializeField]
		private float _animationTime = 1f;
		[SerializeField]
		private float _verticalAnimationMovement = 70f;

		public void SetText(string text)
		{
			_tmpText.SetText(text);
		}

		private void Start()
		{
			PlayAnimation();
		}

		[Button]
		private void PlayAnimation()
		{
			DOTween.Sequence()
			       .Append(transform.DOMoveY(transform.position.y + _verticalAnimationMovement, _animationTime))
			       .Join(_icon.DOFade(0, _animationTime))
			       .Join(_tmpText.DOFade(0, _animationTime))
			       .AppendCallback(() => Destroy(gameObject));
		}
	}
}