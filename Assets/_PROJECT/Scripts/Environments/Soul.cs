using UnityEngine;

using GrimWaves.Effects;
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
				EffectsSpawner.instance.SpawnSoulCollectEffect(transform.position);
				Destroy(gameObject);
			}
		}
		#endregion
	}
}