using UnityEngine;
using UnityEngine.UI;

using GrimWaves.Player;

namespace GrimWaves.Development
{
	public class DebugPlayer : MonoBehaviour
	{
		#region VARIABLES
		public Text m_Text;
		#endregion


		#region UNITY EVENTS
		void Update()
		{
			m_Text.text = string.Format("Ferry:\nVelocity = {0}\nDrag = {1}\n\nMana = {2}\nSouls = {3}",
										Ferry.instance.m_Body.velocity.magnitude,
										Ferry.instance.m_Body.drag,
			                            Ferry.instance.mana,
			                            Ferry.instance.souls
			                           );
		}
		#endregion
	}

}
