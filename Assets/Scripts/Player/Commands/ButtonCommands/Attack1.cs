using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

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

	public void KeyHeld()
	{
		if (!Game.GamePaused && !EventSystem.current.IsPointerOverGameObject()) {
			if (player.items.Weapon != null) {
				player.items.Weapon.UseWeapon ();
			}
		}
	}

    public void KeyUp()
    {

    }
}