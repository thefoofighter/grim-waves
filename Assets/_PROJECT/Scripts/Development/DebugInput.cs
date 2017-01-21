using UnityEngine;

using GrimWaves.Controls;

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
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			InputHandler.onRipple += SpawnRippleIndicator;
			InputHandler.onSoulSacrifice += SpawnSoulSacrificeIndicator;
		}

		void Destroy()
		{
			InputHandler.onRipple -= SpawnRippleIndicator;
			InputHandler.onSoulSacrifice -= SpawnSoulSacrificeIndicator;
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
		#endregion
	}

}