using UnityEngine;

using System;

namespace GrimWaves
{
	public sealed class GameManager : MonoBehaviour
	{
		#region EVENTS
		public static event Action onGamePaused = delegate {};
		public static event Action onGameResumed = delegate {};

		public static event Action onLevelStarted = delegate {};
		public static event Action<bool> onLevelEnded = delegate {};
		public static event Action onLevelQuit = delegate {};
		#endregion


		#region PROPERTIES
		public static GameManager instance { get; private set; }
		#endregion


		#region PRIVATE VARIABLES
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
				Debug.LogError("There are multiple instances of the GameManager present in the scene!");
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
		public void PauseGame()
		{
			Time.timeScale = 1f;
			onGamePaused();
		}

		public void ResumeGame()
		{
			Time.timeScale = 0f;
			onGameResumed();
		}

		public void StartLevel()
		{
			onLevelStarted();
		}

		public void EndLevel(bool reachedEnd = false)
		{
			onLevelEnded(reachedEnd);
		}

		public void QuitLevel()
		{
			onLevelQuit();
		}
		#endregion


		#region HELPER FUNCTIONS
		#endregion
	}
}