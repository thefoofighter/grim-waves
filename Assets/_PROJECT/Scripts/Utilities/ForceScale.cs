using UnityEngine;

namespace GrimWaves.Utilities
{
	public class ForceScale : MonoBehaviour
	{
		#region PUBLIC VARIABLES
		public Vector3 m_ForcedPosition = Vector3.zero;
		public Vector3 m_ForcedScale = Vector3.one;
		#endregion


		#region PRIVATE VARIABLES
		private Transform m_Transform;
		#endregion


		#region UNITY EVENTS
		void Start()
		{
			m_Transform = transform;
		}

		void LateUpdate()
		{
			m_Transform.localPosition = m_ForcedPosition;
			m_Transform.localScale = m_ForcedScale;
		}
		#endregion
	}
}