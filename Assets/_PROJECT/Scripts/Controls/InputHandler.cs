using UnityEngine;
using System;

namespace GrimWaves.Controls
{
	/// <summary>
	/// Handles all input logic.
	/// </summary>
	public class InputHandler : MonoBehaviour
	{
		#region EVENTS
		public static Action<Vector3> onRipple = delegate { };
		public static Action<Vector3> onSoulSacrifice = delegate { };
		#endregion


		#region PUBLIC-API
		public void HandleInput(InputController.InputType inputType, Vector3 inputPosition)
		{
			switch (inputType)
			{
				case InputController.InputType.Primary:
					HandlePrimaryInput(inputPosition);
					break;

				case InputController.InputType.Secondary:
					HandleSecondaryInput(inputPosition);
					break;
			}
		}
		#endregion


		#region INPUT HANDLERS
		void HandlePrimaryInput(Vector3 inputPosition)
		{
			onRipple(inputPosition);

			Ferry.instance.HandleRipple(inputPosition);

			// TODO Spawn ripple effects, particles, etc.
		}

		void HandleSecondaryInput(Vector3 inputPosition)
		{
			onSoulSacrifice(inputPosition);

			// TODO Spawn effects etc.
		}
		#endregion
	}
}