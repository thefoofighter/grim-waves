using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GrimWaves.Audio
{
	public class RandomAudioPlayer : MonoBehaviour
	{
		#region VARIABLES
		public AudioSource m_AudioSource;
		public float m_TimeFrequency;

		public AudioClip[] m_Clips;

		private float m_Timeout;
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			m_Timeout = m_TimeFrequency;
		}
		void Update()
		{
			m_Timeout -= Time.deltaTime;
			if (m_Timeout <= 0f)
			{
				m_Timeout = m_TimeFrequency;

				m_AudioSource.clip = m_Clips[Random.Range(0, m_Clips.Length)];
				m_AudioSource.Play();
			}
		}
		#endregion
	}
}

