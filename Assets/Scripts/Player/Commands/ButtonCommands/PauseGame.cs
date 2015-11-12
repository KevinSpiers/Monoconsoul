using UnityEngine;
using System.Collections;

public class PauseGame : ICommand {

	private Player player;
	public PauseGame(Player _player)
	{
		player = _player;
	}

	public void KeyHeld()
	{

	}

	public void KeyDown()
	{
		Game.TogglePausedGame ();
	}

    public void KeyUp()
    {

    }
}
