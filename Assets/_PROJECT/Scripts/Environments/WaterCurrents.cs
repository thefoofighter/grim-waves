using UnityEngine;

namespace GrimWaves.Environments
{
	/// <summary>
	/// Applies forces to the <see cref="Player.Ferry"/> object to simulate water currents.
	/// </summary>
	public class WaterCurrents : MonoBehaviour
	{
		#region VARIABLES
		public float m_Strength = 10f;
		#endregion


		#region UNITY EVENTS
		void OnTriggerStay(Collider other)
		{
			other.attachedRigidbody.AddForce(transform.forward * m_Strength, ForceMode.Acceleration);
		}
		#endregion
	}
}

