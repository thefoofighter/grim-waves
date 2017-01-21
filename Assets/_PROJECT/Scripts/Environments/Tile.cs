using UnityEngine;

using System;

namespace GrimWaves.Environments
{
	public class Tile : MonoBehaviour
	{
		#region EVENTS
		public static event Action onTilePassed = delegate {};
		#endregion


		#region PUBLIC VARIABLES
		public int m_Length = 20;
		#endregion


		#region UNITY EVENTS
		void OnTriggerEnter(Collider col)
		{
			onTilePassed();
		}
		#endregion
	}
}