using UnityEngine;
using System.Collections;

public class StatsMenu : ICommand {
	private Player player;
	public StatsMenu(Player _player)
	{
		player = _player;
	}
	
	public void KeyPressed()
	{
		
	}
	
	public void KeyDown()
	{
		//Game.TogglePausedGame();
		
		GameObject statsMenu = Game.GetStatsMenu ();
		statsMenu.SetActive (!statsMenu.activeSelf);
	}
}
