using UnityEngine;
using System.Collections;

public class Game {
	
	private static bool isFullScreen = false;
	public static void ToggleFullScreen()
	{
		isFullScreen = !isFullScreen;
		if (isFullScreen) {
			Screen.fullScreen = true;
		} else {
			Screen.fullScreen = false;
		}

		if (Screen.fullScreen == false) {
			ChangeResolution();
		}
	}

	private static int width = 1920;
	private static int height = 1080;
	public static void ChangeResolution()
	{
		Screen.SetResolution (width, height, isFullScreen);
	}
	public static void ChangeResolution(int _width, int _height)
	{
		width = _width;
		height = _height;
		Screen.SetResolution (_width, _height, isFullScreen);
	}

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
