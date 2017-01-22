using UnityEngine;

using GrimWaves.Player;

namespace GrimWaves.Environments
{
	public class Soul : MonoBehaviour
	{
		#region UNITY EVENTS
		void OnTriggerEnter(Collider col)
		{
			if (col.gameObject.layer == Layers.FERRY)
			{
				Ferry.instance.PickUpSoul();
				Destroy(gameObject);
			}
		}
		#endregion
	}
}