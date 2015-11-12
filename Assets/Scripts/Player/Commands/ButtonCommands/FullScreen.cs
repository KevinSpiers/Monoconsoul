using UnityEngine;
using System.Collections;

public class FullScreen : ICommand {

	Player player;
	public FullScreen(Player _player)
	{
		player = _player;
	}
	
	public void KeyDown()
	{
		Game.ToggleFullScreen ();
	}
	
	public void KeyHeld()
	{
		//Do Nothing
	}

    public void KeyUp()
    {

    }
}
