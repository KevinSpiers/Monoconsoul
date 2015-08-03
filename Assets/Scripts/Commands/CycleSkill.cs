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
		player.skills.selectSkill ();
	}

	public void KeyPressed()
	{
		//Do Nothing
	}
}
