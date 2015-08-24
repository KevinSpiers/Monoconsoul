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
		if (player.canPickUp) {
			player.isPickingUp = true;
		}
	}
	
	public void KeyHeld()
	{
		//Do Nothing
	}
}
