using UnityEngine;
using UnityEngine.UI;

using GrimWaves.Environments;
using GrimWaves.Player;

namespace GrimWaves.UI
{
	public class InGameOverlayUIManager : MonoBehaviour 
	{
		#region PUBLIC VARIABLES
		public Text m_ScoreDisplay;
		public Text m_SoulsDisplay;
		public Slider m_ManaDisplay;
		#endregion


		#region UNITY EVENTS
		void OnEnable()
		{
			SetScoreDisplay(TileSpawner.instance.totalTilesPassed);
			SetSoulsDisplay(Ferry.instance.souls);
			SetManaDisplay(Ferry.instance.mana);

			Tile.onTilePassed += UpdateScore;
			Ferry.onSoulsChanged += UpdateSouls;
			Ferry.onManaChanged += UpdateMana;
		}

		void OnDisable()
		{
			Tile.onTilePassed -= UpdateScore;
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
		void UpdateScore()
		{
			SetScoreDisplay(TileSpawner.instance.totalTilesPassed);
		}

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
		void SetScoreDisplay(int newScore)
		{
			m_ScoreDisplay.text = string.Format("Distance: {0}", newScore);
		}

		void SetSoulsDisplay(int newSouls)
		{
			m_SoulsDisplay.text = string.Format("Souls: {0}", newSouls);
		}

		void SetManaDisplay(int newMana)
		{
			m_ManaDisplay.value = newMana;
		}
		#endregion
	}
}
