using UnityEngine;

namespace Game.Gameplay
{
	public sealed class ModelVariant : MonoBehaviour
	{
		public string ID => _id;
		public Animator Animator => _animator;
		[SerializeField]
		private string _id;
		[SerializeField]
		private Animator _animator;

		public void SetActive(bool active)
		{
			gameObject.SetActive(active);
		}

		public void SyncAnimator(AnimatorState state)
		{
			Animator.Play(state.Hash, 0, state.Time);
		}

		public AnimatorState GetAnimatorStateSnapshot()
		{
			return new AnimatorState()
			       {
				       Hash = Animator.GetCurrentAnimatorStateInfo(0).shortNameHash, Time = Animator.GetCurrentAnimatorStateInfo(0).normalizedTime
			       };
		}
	}
}