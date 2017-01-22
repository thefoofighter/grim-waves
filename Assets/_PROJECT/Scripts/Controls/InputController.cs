using UnityEngine;

using GrimWaves.Player;

namespace GrimWaves.Controls
{
	/// <summary>
	/// Process all inputs and delivers them for a handler.
	/// </summary>
	public class InputController : MonoBehaviour
	{
		#region INTERNAL TYPES
		public enum InputType
		{
			Primary = 0,
			Secondary = 1
		}
		#endregion


		#region VARIABLES
		public InputHandler m_InputHandler;

		private int m_InputType;
		#endregion


		#region UNITY EVENTS
		void Update()
		{
			ProcessMouse();
			ProcessKeyboard();
		}
		#endregion


		#region INPUT LOGIC
		void ProcessMouse()
		{
			// Get the input type as an int that maps directly to InputType. -1 means we did not hit.
			m_InputType = Input.GetMouseButtonDown(0) ? 0 : Input.GetMouseButtonDown(1) ? 1 : -1;

			if (m_InputType != -1)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, 100f, 1 << Layers.WATER))
				{
					m_InputHandler.HandleInput((InputType)m_InputType, hit.point);
					Debug.DrawLine(ray.origin, hit.point, Color.green, 3f);
				}
				else
				{
					Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 3f);
				}

				// Reset input flag
				m_InputType = -1;
			}
		}

		void ProcessKeyboard()
		{
			Vector3 direction = Vector3.zero;

			if (Input.GetKeyDown(KeyCode.A))
			{
				direction = Vector3.left;
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				direction = Vector3.right;
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				direction = Vector3.back;
			}
			if (Input.GetKeyDown(KeyCode.W))
			{
				direction = Vector3.forward;
			}

			if (direction != Vector3.zero)
			{
				// Because this is for developer mode, get the relative position in world-space 
				// to the ferry to simulate clicking alongside it.
				var worldPosition = Ferry.instance.position - direction;
				m_InputHandler.HandleInput(InputType.Primary, worldPosition);
			}
		}
		#endregion
	}
}