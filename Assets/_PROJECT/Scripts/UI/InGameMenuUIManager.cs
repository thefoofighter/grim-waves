using UnityEngine;

namespace GrimWaves.UI
{
	public class InGameMenuUIManager : MonoBehaviour 
	{
		#region UNITY EVENTS
		void Update()
		{
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				ResumeGame();
			}
		}
		#endregion


		#region PUBLIC API
		public void ResumeGame()
		{
			GameManager.instance.ResumeGame();
		}

		public void QuitLevel()
		{
			GameManager.instance.QuitLevel();
		}
		#endregion
	}
}
