using UnityEngine;

namespace GrimWaves.UI
{
	public class GameOverUIManager : MonoBehaviour 
	{
		#region PUBLIC API
		public void ReturnToMenu()
		{
			GameManager.instance.QuitLevel();
		}
		#endregion
	}
}
