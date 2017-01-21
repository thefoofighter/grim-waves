using UnityEngine;

namespace GrimWaves.UI
{
	public class InGameOverlayUIManager : MonoBehaviour 
	{
		#region UNITY EVENTS
		void Update()
		{
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				PauseGame();
			}
		}
		#endregion


		#region PUBLIC API
		public void PauseGame()
		{
			GameManager.instance.PauseGame();
		}
		#endregion
	}
}
