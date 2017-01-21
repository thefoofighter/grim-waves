using UnityEngine;

namespace GrimWaves.UI
{
	public sealed class UIManager : MonoBehaviour
	{
		#region PROPERTIES
		public static UIManager instance { get; private set; }
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