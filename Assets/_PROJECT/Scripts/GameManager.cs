﻿using UnityEngine;
using UnityEngine.SceneManagement;

using System;

using GrimWaves.Player;

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

		public static Scene? loadedScene { get; private set; }
		#endregion


		#region PRIVATE VARIABLES
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			if (instance == null)
			{
				instance = this;

				Ferry.onSoulsDepleted += GameOver;
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

				Ferry.onSoulsDepleted -= GameOver;
			}
		}
		#endregion


		#region EVENT HANDLERS
		void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			SceneManager.sceneLoaded -= HandleSceneLoaded;

			loadedScene = scene;
			onLevelStarted();
		}
		#endregion


		#region PUBLIC API
		public void PauseGame()
		{
			Time.timeScale = 0f;
			onGamePaused();
		}

		public void ResumeGame()
		{
			Time.timeScale = 1f;
			onGameResumed();
		}

		public void StartLevel(string sceneName)
		{
			UnloadLevel();

			SceneManager.sceneLoaded += HandleSceneLoaded;
			SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		}

		public void EndLevel(bool reachedEnd = false)
		{
			onLevelEnded(reachedEnd);
		}

		public void QuitLevel()
		{
			Time.timeScale = 1f;
			UnloadLevel();

			onLevelQuit();
		}
		#endregion


		#region HELPER FUNCTIONS
		void UnloadLevel()
		{
			if (loadedScene != null)
			{
				SceneManager.UnloadSceneAsync(loadedScene.Value);
				loadedScene = null;
			}
		}

		void GameOver()
		{
			EndLevel();
		}
		#endregion
	}
}