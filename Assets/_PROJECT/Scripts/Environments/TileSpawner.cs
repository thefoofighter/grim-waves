using UnityEngine;

using System.Collections.Generic;

namespace GrimWaves.Environments
{
	/// <summary>
	/// Spawns <see cref="Tile"/> environment pieces in sequence.
	/// </summary>
	public class TileSpawner : MonoBehaviour
	{
		#region PROPERTIES
		public static TileSpawner instance { get; private set; }

		public int totalSpawnedTiles { get; private set; }
		public int totalTilesPassed { get; private set; }

		public bool hasEndTileSpawned { get; private set; }
		#endregion


		#region PUBLIC VARIABLES
		public Transform m_TileParent;

		public Tile m_StartTile;
		public Tile m_EndTile;
		public Tile[] m_Tiles;

		public int m_NumberTilesAhead = 5;
		public int m_TileCountBeforeDeletion = 2;
		public int m_EndTileNumber = 10;
		#endregion


		#region PRIVATE VARIABLES
		private readonly LinkedList<Tile> m_SpawnedTiles = new LinkedList<Tile>();
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			if (instance == null)
			{
				instance = this;

				if (m_TileParent == null)
				{
					m_TileParent = transform;
				}

				for (int i = m_TileParent.childCount - 1; i >= 0; --i)
				{
					DestroyImmediate(m_TileParent.GetChild(0).gameObject);
				}

				SpawnStart();
				for (int i = 0; i < m_NumberTilesAhead; ++i)
				{
					SpawnNext();
				}

				Tile.onTilePassed += HandleTilePassed;
			}
			else
			{
				Debug.LogError("More than one TileSpawner has been detected in the scene!");
			}
		}

		void OnDestroy()
		{
			if (instance == this)
			{
				instance = null;
				Tile.onTilePassed -= HandleTilePassed;
			}
		}
		#endregion


		#region EVENT HANDLERS
		void HandleTilePassed()
		{
			++totalTilesPassed;
			if (totalTilesPassed > m_TileCountBeforeDeletion)
			{
				Despawn();
			}

			SpawnNext();
		}
		#endregion


		#region PUBLIC API
		/// <summary>
		/// Spawns the next tile, either randomly or the end tile if the conditions to spawn it have been met.
		/// </summary>
		public void SpawnNext()
		{
			if (totalSpawnedTiles < m_EndTileNumber)
			{
				SpawnRandom();
			}
			else if (!hasEndTileSpawned)
			{
				SpawnEnd();
			}
		}
		#endregion


		#region HELPER FUNCTIONS
		Vector3 GetNextPosition()
		{
			Tile lastTile = m_SpawnedTiles.Last.Value;
			return lastTile.transform.position + (Vector3.forward * lastTile.m_Length);
		}

		void SpawnStart()
		{
			SpawnTile(m_StartTile, transform.position);
		}

		void SpawnEnd()
		{
			SpawnTile(m_EndTile, GetNextPosition());
			hasEndTileSpawned = true;
		}

		void SpawnRandom()
		{
			SpawnTile(m_Tiles[Random.Range(0, m_Tiles.Length)], GetNextPosition());
		}

		void SpawnTile(Tile tile, Vector3 position)
		{
			m_SpawnedTiles.AddLast(Instantiate(tile, position, Quaternion.identity, m_TileParent));
			++totalSpawnedTiles;
		}

		void Despawn()
		{
			Destroy(m_SpawnedTiles.First.Value.gameObject);
			m_SpawnedTiles.RemoveFirst();
		}
		#endregion
	}
}