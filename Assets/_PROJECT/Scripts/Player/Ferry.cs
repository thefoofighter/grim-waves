using UnityEngine;
using System;
using System.Collections;

namespace GrimWaves.Player
{
	/// <summary>
	/// Represents the ferry that is the main character.
	/// </summary>
	public class Ferry : MonoBehaviour
	{
		#region CONSTANTS
		public const float VELOCITY_DRAG_RATIO = 37.5f;
		public const float WAVE_ROTATE_TIME = 0.5f;

		public const int SOUL_MANA_EXCHANGE_RATE = 10;
		public const int STARTING_SOUL_COUNT = 10;
		public const int STARTING_MANA_COUNT = 10;
		#endregion


		#region EVENTS
		public static Action<Vector3> onObstacleCollision = delegate {};

		public static Action onManaDepleted = delegate {};
		public static Action onSoulsDepleted = delegate {};

		public static Action<int> onManaChanged = delegate {};
		public static Action<int> onSoulsChanged = delegate {};
		#endregion


		#region PROPERTIES
		public static Ferry instance { get; private set; }

		public Vector3 position { get { return m_Body.position; } }

		public int souls
		{
			get { return m_Souls; }
			private set
			{
				if (m_Souls != value)
				{
					m_Souls = value;
					onSoulsChanged(m_Souls);
					
					if (m_Souls <= 0)
					{
						onSoulsDepleted();
					}
				}
			}
		}

		public int mana 
		{ 			
			get { return m_Mana; }
			private set
			{
				if (m_Mana != value)
				{
					m_Mana = value;
					onManaChanged(m_Mana);
					
					if (m_Mana <= 0)
					{
						onManaDepleted();
					}
				}
			}
		}
		#endregion


		#region PUBLIC VARIABLES
		public Rigidbody m_Body;

		public float m_RippleMovementScaler = 5f;
		public float m_MaximumVelocity = 5f;
		#endregion


		#region PRIVATE VARIABLES
		private int m_Souls;
		private int m_Mana;
		#endregion


		#region UNITY EVENTS
		void Awake()
		{
			instance = this;
			Reset();
		}

		void FixedUpdate()
		{
			// Increase drag proportional to velocity. This results in a max velocity instead of infinitely increasing.
			m_Body.drag = m_Body.velocity.magnitude / VELOCITY_DRAG_RATIO;
		}
		#endregion


		#region PUBLIC API
		/// <summary>
		/// Resets the internal members to a newly intialised state.
		/// </summary>
		public void Reset()
		{
			souls = STARTING_SOUL_COUNT;
			mana = STARTING_MANA_COUNT;
		}

		/// <summary>
		/// Consumes mana to create a wave that pushes the ferry away from the wave spawn point.
		/// </summary>
		/// <param name="worldSpacePosition">World space position of the wave spawn point.</param>
		public bool HandleRipple(Vector3 worldSpacePosition)
		{
			if (mana > 0)
			{
				--mana;

				// Push boat in direction of wave.
				var dir = position - worldSpacePosition;
				ApplyForce(dir.normalized * m_RippleMovementScaler);

				var angle = Vector3.Angle(transform.forward, dir);

				StopAllCoroutines();
				StartCoroutine(RippleTurn(dir));

				// If wave is from behind the boat, rotate the nose toward the
				if (angle <= 90)
				{
					//TODO Apply torque
				}

				return true;
			}

			return false;
		}

		/// <summary>
		/// Consumes a soul on-board the ferry in order to replenish mana reserves.
		/// </summary>
		/// <param name="inputPosition">Input position.</param>
		public bool SacrificeSoul(Vector3 inputPosition)
		{
			if (souls > 0)
			{
				--souls;
				mana += SOUL_MANA_EXCHANGE_RATE;

				return true;
			}

			return false;

		}

		/// <summary>
		/// Causes souls to fall overboard and be lost to the depths of the mighty river.
		/// </summary>
		/// <param name="collisionPosition">Collision position.</param>
		public void CollidedWithObstacle(Vector3 collisionPosition)
		{
			onObstacleCollision(collisionPosition);
			--souls;
		}

		/// <summary>
		/// Applies a small nudging (impulse) force to the ferry's rigid body in the direction specified.
		/// </summary>
		public void ApplyForce(Vector3 directionalForce)
		{
			m_Body.AddForce(directionalForce, ForceMode.Impulse);
		}
		#endregion


		#region HELPERS
		IEnumerator RippleTurn(Vector3 direction)
		{
			float timer = WAVE_ROTATE_TIME;
			while (timer > 0f)
			{
				var angle = Vector3.Angle(direction, transform.forward);
				var cross = Vector3.Cross(direction, transform.forward);
				if (!(cross.y < 0))
				{
					angle = -angle;
				}
				transform.Rotate(transform.up, angle * (Time.deltaTime * (timer/WAVE_ROTATE_TIME)));

				timer -= Time.deltaTime;
				yield return null;
			}
		}
		#endregion
	}
}

