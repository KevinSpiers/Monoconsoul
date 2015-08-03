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
		//if (player.skills.selectedSkill != null) {
		//	player.skills.selectedSkill.UseSkill ();
		//}
	}

	public void KeyPressed()
	{
		if (player.skills.selectedSkill != null) {
			player.skills.selectedSkill.UseSkill ();
		}
	}

}