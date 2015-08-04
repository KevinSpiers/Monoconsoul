using UnityEngine;
using System.Collections;

public class PickupItem : ICommand {

	Player player;
	public PickupItem(Player _player)
	{
		player = _player;
	}
	
	public void KeyDown()
	{
		if (player.skills.canPickUpSkill) {
			player.skills.isPickingUpSkill = true;
		}
	}
	
	public void KeyPressed()
	{
		//Do Nothing
	}
}
