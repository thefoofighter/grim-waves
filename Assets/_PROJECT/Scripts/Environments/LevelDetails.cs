using UnityEngine;

namespace GrimWaves.Environments
{
	public sealed class LevelDetails : MonoBehaviour
	{
		#region PUBLIC VARIABLES
		public Level m_LevelType;

		public Obstacle[] m_AvailableObstacles = new Obstacle[0];
		public Soul[] m_AvailableSouls = new Soul[0];
		#endregion


		#region PROPERTIES
		public static LevelDetails instance { get; private set; }
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Debug.LogError("There are multiple instances of the LevelDetails object present in the scene!");
			}
		}

		void OnDestroy()
		{
			if (instance == this)
			{
				instance = null;
			}
		}
		#endregion


		#region PUBLIC API
		public Obstacle GetRandomObstacle()
		{
			return GetRandomObject(ref m_AvailableObstacles);
		}

		public Soul GetRandomSoul()
		{
			return GetRandomObject(ref m_AvailableSouls);
		}
		#endregion


		#region HELPER FUNCTIONS
		T GetRandomObject<T>(ref T[] objects) where T : Object
		{
			T result = null;

			if (objects.Length > 0)
			{
				result = objects[Random.Range(0, objects.Length)];
			}

			return result;
		}
		#endregion
	}
}