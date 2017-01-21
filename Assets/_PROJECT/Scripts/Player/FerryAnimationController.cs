using UnityEngine;

namespace GrimWaves.Player
{
	public class FerryAnimationController : MonoBehaviour
	{
		#region INTERNAL TYPES
		public enum AnimationType
		{
			HitLeft = 0,
			HitRight = 1,
			HitFront = 2,
			HitBack = 3
		}
		#endregion


		#region VARIABLES
		public Animator m_Animator;
		#endregion


		#region PUBLIC API
		public void TriggerAnimation(AnimationType type)
		{
			m_Animator.SetTrigger(type.ToString());
		}
		#endregion
	}
}

