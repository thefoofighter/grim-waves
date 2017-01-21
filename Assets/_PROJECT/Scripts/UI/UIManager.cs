using UnityEngine;

namespace GrimWaves.UI
{
	public sealed class UIManager : MonoBehaviour
	{
		#region PROPERTIES
		public static UIManager instance { get; private set; }

		public static MainMenuUIManager mainMenuManager
		{
			get { return instance.m_MainMenuManager; }
		}

		public static InGameUIManager inGameManager
		{
			get { return instance.m_InGameManager; }
		}
		#endregion


		#region PRIVATE VARIABLES
		[SerializeField]
		private MainMenuUIManager m_MainMenuManager;

		[SerializeField]
		private InGameUIManager m_InGameManager;
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
				Debug.LogError("There are multiple instances of the UIManager present in the scene!");
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
	}
}