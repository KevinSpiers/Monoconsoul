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
}
