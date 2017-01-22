using UnityEngine;

using System.Collections.Generic;

namespace GrimWaves.Environments
{
	public class ObjectSpawner : MonoBehaviour
	{
		#region PUBLIC VARIABLES
		public Transform[] m_AvailableSpawnPoints = new Transform[0];

		public float m_ObstacleSpawnChance;
		public float m_SoulSpawnChance;
		#endregion


		#region PRIVATE VARIABLES
		public List<Transform> m_OccupiedSpawnPoints;
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			m_OccupiedSpawnPoints = new List<Transform>(m_AvailableSpawnPoints.Length);
			SpawnEnvironmentObjects();
		}
		#endregion


		#region HELPER FUNCTIONS
		void SpawnEnvironmentObjects()
		{
			foreach (var spawnPoint in m_AvailableSpawnPoints)
			{
				var chance = Random.value;
				if (chance <= m_ObstacleSpawnChance)
				{
					SpawnObstacle(spawnPoint);
				}
				else if (chance <= m_ObstacleSpawnChance + m_SoulSpawnChance)
				{
					SpawnSoul(spawnPoint);
				}
			}
		}

		void SpawnObstacle(Transform spawnPoint)
		{
			// TODO spawn obstacle

			m_OccupiedSpawnPoints.Add(spawnPoint);
		}

		void SpawnSoul(Transform spawnPoint)
		{
			// TODO spawn soul

			m_OccupiedSpawnPoints.Add(spawnPoint);
		}
		#endregion
	}
}