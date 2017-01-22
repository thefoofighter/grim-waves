using UnityEngine;
using UnityEngine.UI;

using GrimWaves.Player;

namespace GrimWaves.UI
{
	public class InGameOverlayUIManager : MonoBehaviour 
	{
		#region PUBLIC VARIABLES
		public Text m_SoulsDisplay;
		public Slider m_ManaDisplay;
		#endregion


		#region UNITY EVENTS
		void OnEnable()
		{
			SetSoulsDisplay(Ferry.instance.souls);
			SetManaDisplay(Ferry.instance.mana);

			Ferry.onSoulsChanged += UpdateSouls;
			Ferry.onManaChanged += UpdateMana;
		}

		void OnDisable()
		{
			Ferry.onSoulsChanged -= UpdateSouls;
			Ferry.onManaChanged -= UpdateMana;
		}

		void Update()
		{
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				PauseGame();
			}
		}
		#endregion


		#region EVENT HANDLERS
		void UpdateSouls(int newSouls)
		{
			SetSoulsDisplay(newSouls);
		}

		void UpdateMana(int newMana)
		{
			SetManaDisplay(newMana);
		}
		#endregion


		#region PUBLIC API
		public void PauseGame()
		{
			GameManager.instance.PauseGame();
		}
		#endregion


		#region HELPER FUNCTIONS
		void SetSoulsDisplay(int newSouls)
		{
			m_SoulsDisplay.text = string.Format("{0}", newSouls);
		}

		void SetManaDisplay(int newMana)
		{
			m_ManaDisplay.value = newMana;
		}
		#endregion
	}
}
