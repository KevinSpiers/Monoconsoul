using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Defend : ICommand {

	Player player;
	public Defend(Player _player)
	{
		player = _player;
	}
	
	public void KeyDown()
	{
		if (!Game.GamePaused && !EventSystem.current.IsPointerOverGameObject()) {
			if (player.items.Armor != null) {
				player.items.Armor.UseArmor ();
			}
		}
	}
	
	public void KeyHeld()
	{
		//Do Nothing
	}
}
