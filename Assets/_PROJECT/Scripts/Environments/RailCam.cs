using UnityEngine;

namespace GrimWaves.Environments
{
	public class RailCam : MonoBehaviour
	{
		#region ENUMS
		public enum UpdateType
		{
			FixedUpdate,
			LateUpdate,
			ManualUpdate
		}
		#endregion


		#region PUBLIC VARIABLES
		public Transform m_Target;
		#endregion


		#region PRIVATE VARIABLES
		[SerializeField]
		private float m_MoveSpeed = 3;

		[SerializeField]
		private UpdateType m_UpdateType;
		#endregion


		#region UNITY EVENTS
		void Start()
		{

		}

		void FixedUpdate()
		{
			if (m_UpdateType == UpdateType.FixedUpdate)
			{
				FollowTarget(Time.deltaTime);
			}
		}

		void LateUpdate()
		{
			if (m_UpdateType == UpdateType.LateUpdate)
			{
				FollowTarget(Time.deltaTime);
			}
		}
		#endregion


		#region PUBLIC API
		public void ManualUpdate()
		{
			if (m_UpdateType == UpdateType.ManualUpdate)
			{
				FollowTarget(Time.deltaTime);
			}
		}
		#endregion


		#region HELPER FUNCTIONS
		void FollowTarget(float deltaTime)
		{
			// If no target, or no time passed then we quit early, as there is nothing to do
			if (!(deltaTime > 0) || m_Target == null)
			{
				return;
			}

			transform.position = new Vector3(0f, 0f, Mathf.Lerp(transform.position.z, m_Target.position.z, deltaTime * m_MoveSpeed));
		}
		#endregion
	}
}