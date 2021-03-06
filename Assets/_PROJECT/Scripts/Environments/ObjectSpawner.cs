﻿using UnityEngine;

using System.Collections;
using System.Collections.Generic;

namespace GrimWaves.Environments
{
	public class ObjectSpawner : MonoBehaviour
	{
		#region PUBLIC VARIABLES
		public Transform[] m_AvailableSpawnPoints = new Transform[0];

		public float m_ObstacleSpawnChance = 0.1f;
		public float m_SoulSpawnChance = 0.05f;
		#endregion


		#region PRIVATE VARIABLES
		List<Transform> m_OccupiedSpawnPoints;
		#endregion


		#region UNITY EVENTS
		IEnumerator Start()
		{
			yield return new WaitWhile(() => LevelDetails.instance == null);

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
			SpawnObject(LevelDetails.instance.GetRandomObstacle(), spawnPoint);
		}

		void SpawnSoul(Transform spawnPoint)
		{
			SpawnObject(LevelDetails.instance.GetRandomSoul(), spawnPoint);
		}

		void SpawnObject<T>(T prefab, Transform spawnPoint) where T : MonoBehaviour
		{
			if (prefab != null)
			{
				var go = Instantiate(prefab, spawnPoint, false);
				m_OccupiedSpawnPoints.Add(spawnPoint);
			}
		}
		#endregion
	}
}