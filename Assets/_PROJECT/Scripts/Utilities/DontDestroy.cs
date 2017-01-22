using UnityEngine;

namespace GrimWaves.Utilities
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