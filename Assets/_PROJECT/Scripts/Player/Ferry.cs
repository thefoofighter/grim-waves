using UnityEngine;
using System;

namespace GrimWaves.Player
{
	/// <summary>
	/// Represents the ferry that is the main character.
	/// </summary>
	public class Ferry : MonoBehaviour
	{
		#region EVENTS
		public static Action<Vector3> onObstacleCollision = delegate { };
		#endregion


		#region PROPERTIES
		public static Ferry instance { get; private set; }

		public Vector3 position { get { return m_Body.position; } }
		#endregion


		#region CONSTANTS
		public const float VELOCITY_DRAG_RATIO = 37.5f;
		#endregion


		#region VARIABLES
		public Rigidbody m_Body;

		public float m_RippleMovementScaler = 5f;
		public float m_MaximumVelocity = 5f;
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			instance = this;
		}

		void FixedUpdate()
		{
			// Increase drag proportional to velocity. This results in a max velocity instead of infinitely increasing.
			m_Body.drag = m_Body.velocity.magnitude / VELOCITY_DRAG_RATIO;
		}
		#endregion


		#region PUBLIC API
		public void HandleRipple(Vector3 worldSpacePosition)
		{
			// Push boat in direction of wave.
			var dir = position - worldSpacePosition;
			m_Body.AddForce(dir.normalized * m_RippleMovementScaler, ForceMode.Impulse);

			var angle = Vector3.Angle(transform.forward, dir);

			// If wave is from behind the boat, rotate the nose toward the
			if (angle <= 90)
			{
				//TODO Apply torque
			}
		}

		public void SacrificeSoul(Vector3 inputPosition)
		{
			Debug.Log("The ferryman sacrifices a soul to recharge his mana reserves.");
		}

		public void CollidedWithObstacle(Vector3 collisionPosition)
		{
			onObstacleCollision(collisionPosition);
			Debug.Log("The ferryman crashes into an obstacle in his path!");
		}
		#endregion
	}
}

