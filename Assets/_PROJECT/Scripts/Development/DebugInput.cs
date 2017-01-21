using UnityEngine;

using GrimWaves.Controls;
using GrimWaves.Player;

namespace GrimWaves.Development
{
	/// <summary>
	/// Spawns indicators to show the position of specific inputs.
	/// </summary>
	public class DebugInput : MonoBehaviour
	{
		#region VARIABLES
		public bool m_EnableDebug;
		public GameObject m_RippleIndicatorPrefab;
		public GameObject m_SoulSacrificeIndicatorPrefab;
		public GameObject m_CollisionIndicatorPrefab;
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			InputHandler.onPrimaryInput += SpawnRippleIndicator;
			InputHandler.onSecondaryInput += SpawnSoulSacrificeIndicator;
			Ferry.onObstacleCollision += SpawnCollisionIndicator;
		}

		void Destroy()
		{
			InputHandler.onPrimaryInput -= SpawnRippleIndicator;
			InputHandler.onSecondaryInput -= SpawnSoulSacrificeIndicator;
			Ferry.onObstacleCollision -= SpawnCollisionIndicator;
		}
		#endregion


		#region HELPERS
		void SpawnRippleIndicator(Vector3 position)
		{
			if (m_EnableDebug)
			{
				Instantiate(m_RippleIndicatorPrefab, position, m_RippleIndicatorPrefab.transform.rotation, transform);
			}
		}

		void SpawnSoulSacrificeIndicator(Vector3 position)
		{
			if (m_EnableDebug)
			{
				Instantiate(m_SoulSacrificeIndicatorPrefab, position, m_SoulSacrificeIndicatorPrefab.transform.rotation, transform);
			}
		}

		void SpawnCollisionIndicator(Vector3 position)
		{
			if (m_EnableDebug)
			{
				Instantiate(m_CollisionIndicatorPrefab, position, m_CollisionIndicatorPrefab.transform.rotation, transform);
			}
		}
		#endregion
	}

}