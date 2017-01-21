using UnityEngine;

namespace GrimWaves.Utilties
{
	public class DontDestroy : MonoBehaviour
	{
		#region UNITY EVENTS
		void Start()
		{
			DontDestroyOnLoad(gameObject);
		}
		#endregion
	}
}