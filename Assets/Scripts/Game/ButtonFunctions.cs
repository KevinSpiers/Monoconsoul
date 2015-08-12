using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

	private Player player;

	public void Start()
	{
		player = GameObject.FindObjectOfType<Player> ();
	}

	private void RemoveFocus()
	{
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

	public void CharacterMainSkillPressed()
	{
		if (!Game.GamePaused && player.skills.mainSkill != null) {
			player.skills.mainSkill.UseSkill ();
		}
		RemoveFocus ();
	}

	public void CharacterSkill1Pressed()
	{
		if (!Game.GamePaused && player.skills.CheckSkill(0) != null) {
			player.skills.CheckSkill (0).UseSkill ();
		}
		RemoveFocus ();
	}

	public void CharacterSkill2Pressed()
	{
		if (!Game.GamePaused && player.skills.CheckSkill(1) != null) {
			player.skills.CheckSkill (1).UseSkill ();
		}
		RemoveFocus ();
	}

	public void CharacterSkill3Pressed()
	{
		if (!Game.GamePaused && player.skills.CheckSkill(2) != null) {
			player.skills.CheckSkill (2).UseSkill ();
		}
		RemoveFocus ();
	}



}
