using UnityEngine;

namespace GrimWaves.UI
{
	public sealed class UIManager : MonoBehaviour
	{
		#region PROPERTIES
		public static UIManager instance { get; private set; }

		public static MainMenuUIManager mainMenu
		{
			get { return instance.m_MainMenu; }
		}

		public static InGameMenuUIManager inGameMenu
		{
			get { return instance.m_InGameMenu; }
		}

		public static InGameOverlayUIManager inGameOverlay
		{
			get { return instance.m_InGameOverlay; }
		}

		public static GameOverUIManager gameOverMenu
		{
			get { return instance.m_GameOverMenu; }
		}
		#endregion


		#region PRIVATE VARIABLES
		[SerializeField]
		private MainMenuUIManager m_MainMenu;

		[SerializeField]
		private InGameMenuUIManager m_InGameMenu;

		[SerializeField]
		private InGameOverlayUIManager m_InGameOverlay;

		[SerializeField]
		private GameOverUIManager m_GameOverMenu;
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			if (instance == null)
			{
				instance = this;

				GameManager.onLevelQuit += ShowMainMenu;
				GameManager.onGamePaused += ShowInGameMenu;
				GameManager.onGameResumed += ShowInGameOverlay;
				GameManager.onLevelStarted += ShowInGameOverlay;
				GameManager.onLevelEnded += ShowGameOver;
			}
			else
			{
				Debug.LogError("There are multiple instances of the UIManager present in the scene!");
			}
		}

		void OnDestroy()
		{
			if (instance == this)
			{
				instance = null;

				GameManager.onLevelQuit -= ShowMainMenu;
				GameManager.onGamePaused -= ShowInGameMenu;
				GameManager.onGameResumed -= ShowInGameOverlay;
				GameManager.onLevelStarted -= ShowInGameOverlay;
				GameManager.onLevelEnded += ShowGameOver;
			}
		}
		#endregion


		#region PUBLIC API
		public void ShowMainMenu()
		{
			HideUI();
			mainMenu.gameObject.SetActive(true);
		}

		public void ShowInGameMenu()
		{
			HideUI();
			inGameMenu.gameObject.SetActive(true);
		}

		public void ShowInGameOverlay()
		{
			HideUI();
			inGameOverlay.gameObject.SetActive(true);
		}

		public void ShowGameOver(bool reachedEnd)
		{
			HideUI();
			gameOverMenu.gameObject.SetActive(true);
		}

		public void HideUI()
		{
			mainMenu.gameObject.SetActive(false);
			inGameMenu.gameObject.SetActive(false);
			inGameOverlay.gameObject.SetActive(false);
		}
		#endregion
	}
}