using UnityEngine;

namespace GrimWaves.Controls
{
	/// <summary>
	/// Represents the ferry that is the main character.
	/// </summary>
	public class Ferry : MonoBehaviour
	{
		#region PROPERTIES
		public static Ferry instance { get; private set; }

		public Vector3 position { get { return m_Body.position; } }
		#endregion


		#region VARIABLES
		public Rigidbody m_Body;
		public float m_ForceScaler = 1f;
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			instance = this;
		}
		#endregion


		#region PUBLIC API
		public void HandleRipple(Vector3 worldSpacePosition)
		{
			var dir = position - worldSpacePosition;
			m_Body.AddForce(dir.normalized * m_ForceScaler, ForceMode.Impulse);
		}

		public void SacrificeSoul()
		{
			Debug.Log("The ferry-man sacrifices a soul to recharge his mana reserves.");
		}
		#endregion
	}
}

