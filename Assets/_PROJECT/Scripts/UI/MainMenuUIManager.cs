using UnityEngine;

namespace GrimWaves.UI
{
	public class MainMenuUIManager : MonoBehaviour
	{
		#region PUBLIC VARIABLES
		public string m_LevelName = "Styx";
		#endregion


		#region PUBLIC API
		public void StartNewGame()
		{
			// TODO fade out UI should be triggered here and then load the level
			GameManager.instance.StartLevel(m_LevelName);
		}

		public void QuitGame()
		{
			Application.Quit();
		}
		#endregion
	}
}
