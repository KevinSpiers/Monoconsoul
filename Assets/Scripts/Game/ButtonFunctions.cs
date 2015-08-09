using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

	private Player player;
	private void RemoveFocus()
	{
		//Removes focus from the button to prevent unwanted behaviour
		if (player == null) {
			player = GameObject.FindObjectOfType<Player> ();
		}
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (player.gameObject);
	}
	
	public void OptionsMenu()
	{
		Game.TogglePausedGame();

		GameObject optionsMenu = Game.GetOptionsMenu ();
		optionsMenu.SetActive (!optionsMenu.activeSelf);

		RemoveFocus ();
	}

	public void CharacterStatsMenu()
	{
		//Game.TogglePausedGame ();

		GameObject statsMenu = Game.GetStatsMenu ();
		statsMenu.SetActive (!statsMenu.activeSelf);

		RemoveFocus ();
	}


}
