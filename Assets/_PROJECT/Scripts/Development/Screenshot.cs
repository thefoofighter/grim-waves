using UnityEngine;

using System;
using System.IO;

namespace GrimWaves.Development
{
	/// <summary>
	/// This script provides functionality for quickly taking a screenshot with the Shift + S keys.
	/// </summary>
	public class Screenshot : MonoBehaviour
	{
		#region PUBLIC VARIABLES
		/// The amount by which the resolution of the screenshot will be scaled.
		[Tooltip("The amount by which the resolution of the screenshot will be scaled.")]
		public int m_ScaleFactor = 2;
		#endregion


		#region UNITY EVENTS
		void Update()
		{
			if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyUp(KeyCode.S))
			{
				string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), string.Format("Screenshot_{0}.png", DateTime.Now.ToString("yyyyMMdd-HHmmss")));

				Debug.LogFormat("Saving screenshot to {0}...", filepath);
				Application.CaptureScreenshot(filepath, m_ScaleFactor);
			}
		}
		#endregion
	}
}