using UnityEngine;
using System.Collections;

public class OptionsMenu : ICommand {

	private Player player;
	public OptionsMenu(Player _player)
	{
		player = _player;
	}
	
	public void KeyHeld()
	{
		
	}
	
	public void KeyDown()
	{
		Game.TogglePausedGame();

		GameObject optionsMenu = Game.GetOptionsMenu ();
		optionsMenu.SetActive (!optionsMenu.activeSelf);
	}

    public void KeyUp()
    {

    }
}
