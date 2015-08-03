using UnityEngine;
using System.Collections;

public class Attack1 : ICommand {
	Player player;
	public Attack1(Player _player)
	{
		player = _player;
	}

	public void KeyDown()
	{
		//Do Nothing
	}

	public void KeyPressed()
	{
		if (!Game.GamePaused) {
			if (player.skills.selectedSkill != null) {
				player.skills.selectedSkill.UseSkill ();
			}
		}
	}

}