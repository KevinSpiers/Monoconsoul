using UnityEngine;
using System.Collections;

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
		if (!Game.GamePaused) {
			//TODO: Add Skills attack
		}
	}

}