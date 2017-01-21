using UnityEngine;

namespace GrimWaves.Environments
{
	/// <summary>
	/// Applies forces to the <see cref="Player.Ferry"/> object to simulate water currents.
	/// </summary>
	public class WaterBoyancy : MonoBehaviour
	{
		#region VARIABLES
		public float m_Strength = 10f;
		#endregion


		#region UNITY EVENTS
		void OnTriggerStay(Collider other)
		{
			if ((1 << other.gameObject.layer & Layers.WATER_AFFECTED_MASK) != 0)
			{
				// Apply a force in the forward direction of this game object.
				other.attachedRigidbody.AddForce(transform.up * m_Strength, ForceMode.Acceleration);
			}
		}
		#endregion
	}
}

