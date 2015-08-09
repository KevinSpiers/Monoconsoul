using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class Attack2 : ICommand {
	Player player;
	public Attack2(Player _player)
	{
		player = _player;
	}

	public void KeyDown()
	{
		//Do Nothing
	}

	public void KeyPressed()
	{
		if (!Game.GamePaused && !EventSystem.current.IsPointerOverGameObject()) {
			if (player.skills.selectedSkill != null) {
				player.skills.selectedSkill.UseSkill ();
			}
		}
	}

}