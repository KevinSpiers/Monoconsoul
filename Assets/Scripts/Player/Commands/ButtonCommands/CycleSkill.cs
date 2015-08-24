using UnityEngine;
using System.Collections;

public class CycleSkill : ICommand {

	Player player;
	public CycleSkill(Player _player)
	{
		player = _player;
	}

	public void KeyDown()
	{
		if (!Game.GamePaused) {
			player.skills.SelectSkill ();
		}
	}

	public void KeyHeld()
	{
		//Do Nothing
	}
}
