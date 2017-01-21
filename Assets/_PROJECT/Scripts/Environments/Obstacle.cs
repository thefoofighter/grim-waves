using UnityEngine;
using System;
using GrimWaves.Player;

namespace GrimWaves.Environments
{
	/// <summary>
	/// Represents an obstacle that the ferry can crash into.
	/// </summary>
	public class Obstacle : MonoBehaviour
	{
		#region CONSTANTS
		public const float COLLISION_TIMEOUT = 1.5f;
		#endregion


		#region VARIABLES
		private float m_Timeout;
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			// Set so that we can collide immediately
			m_Timeout = COLLISION_TIMEOUT;
		}

		void Update()
		{
			m_Timeout += Time.deltaTime;
		}

		void OnCollisionEnter(Collision col)
		{
			if (col.collider.gameObject.layer == Layers.FERRY)
			{
				// Use a timeout to prevent multiple hits from one accident.
				if (m_Timeout > COLLISION_TIMEOUT)
				{
					Ferry.instance.CollidedWithObstacle(col.contacts[0].point);
				}

				m_Timeout = 0f;
			}
		}
		#endregion
	}
}

