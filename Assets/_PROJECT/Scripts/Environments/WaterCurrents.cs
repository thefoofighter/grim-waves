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
			// Don't affect other 
			if ((1 << other.gameObject.layer & Layers.WATER_AFFECTED_MASK) != 0)
			{
				// Apply a force in the forward direction of this game object.
				other.attachedRigidbody.AddForce(transform.forward * m_Strength, ForceMode.Acceleration);

				// Rotate the objects forward axis toward the forward axis of this current.

				var angle = Vector3.Angle(transform.forward, other.attachedRigidbody.transform.forward);
				var cross = Vector3.Cross(transform.forward, other.attachedRigidbody.transform.forward);

				if (!(cross.y < 0))
				{
					angle = -angle;
				}

				other.attachedRigidbody.transform.Rotate(transform.up, angle * Time.deltaTime);
			}
		}
		#endregion
	}
}

