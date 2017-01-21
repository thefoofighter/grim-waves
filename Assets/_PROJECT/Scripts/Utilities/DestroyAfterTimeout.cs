using UnityEngine;

namespace GrimWaves.Utilities
{
	/// <summary>
	/// Destroys the game object after a specified amount of time.
	/// </summary>
	public class DestroyAfterTimeout : MonoBehaviour
	{
		#region VARIABLES
		public float m_DestroyTimeout;
		private float m_TimeRemaining;
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			m_TimeRemaining = m_DestroyTimeout;
		}

		void Update()
		{
			m_TimeRemaining -= Time.deltaTime;

			if (m_TimeRemaining <= 0f)
			{
				Destroy(gameObject);
			}
		}
		#endregion
	}
}

