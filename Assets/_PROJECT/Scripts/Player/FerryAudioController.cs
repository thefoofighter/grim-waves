using UnityEngine;

namespace GrimWaves.Player
{
	public class FerryAudioController : MonoBehaviour
	{
		#region VARIABLES
		public AudioSource m_AudioSource;

		public AudioClip m_RippleSound;
		public AudioClip m_SoulSacrificeSound;
		public AudioClip m_CollisionSound;
		#endregion


		#region PUBLIC API
		public void PlayRippleSound()
		{
			Play(m_RippleSound);
		}

		public void PlaySoulSacrificeSound()
		{
			Play(m_SoulSacrificeSound);
		}

		public void PlayCollisionSound()
		{
			Play(m_CollisionSound);
		}
		#endregion


		#region HELPERS
		void Play(AudioClip clip)
		{
			if (clip != null)
			{
				m_AudioSource.Stop();
				m_AudioSource.clip = clip;
				m_AudioSource.Play();
			}
		}
		#endregion
	}
}

