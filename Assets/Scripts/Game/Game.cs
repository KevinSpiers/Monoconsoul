using UnityEngine;
using System.Collections;

public class Game {

	public static bool GamePaused = false;

	public static void TogglePausedGame()
	{
		GamePaused = !GamePaused;
		if (GamePaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	private static GameObject optionsMenu;
	public static GameObject GetOptionsMenu()
	{
		if (optionsMenu == null) {
			optionsMenu = GameObject.Instantiate<GameObject>(Resources.Load("Prefabs/OptionsMenu") as GameObject);
		}
		return optionsMenu;
	}

	private static GameObject statsMenu;
	public static GameObject GetStatsMenu()
	{
		if (statsMenu == null) {
			statsMenu = GameObject.Instantiate<GameObject>(Resources.Load("Prefabs/StatsMenu") as GameObject);
		}
		return statsMenu;
	}
}
