using UnityEngine;

namespace GrimWaves.Effects
{
	public class EffectsSpawner : MonoBehaviour
	{
		#region PROPERTIES
		public static EffectsSpawner instance { get; private set; }
		#endregion


		#region VARIABLES
		public GameObject[] m_WaveEffect;
		public GameObject[] m_SoulCollect;
		public GameObject[] m_SoulDie;
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			instance = this;
		}
		#endregion


		#region PUBLIC API
		public void SpawnWaveEffect(Vector3 position)
		{
			if (m_WaveEffect.Length > 0)
			{
				var effect = GetEffect(m_WaveEffect);
				Instantiate(effect, position, effect.transform.rotation);
			}
		}

		public void SpawnSoulCollectEffect(Vector3 position)
		{
			if (m_SoulCollect.Length > 0)
			{
				var effect = GetEffect(m_SoulCollect);
				Instantiate(effect, position, effect.transform.rotation);
			}
		}

		public void SpawnSoulDieEffect(Vector3 position)
		{
			if (m_SoulDie.Length > 0)
			{
				var effect = GetEffect(m_SoulDie);
				Instantiate(effect, position, effect.transform.rotation);
			}
		}
		#endregion


		#region HELPER
		GameObject GetEffect(GameObject[] effects)
		{
			var idx = Random.Range(0, effects.Length);
			return effects[idx];
		}
		#endregion
	}
}