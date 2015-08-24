using UnityEngine;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

	private Player player;
	private void SetPlayer()
	{
		if (player == null || player.gameObject == null) {
			player = GameObject.FindObjectOfType<Player> ();
		}
	}
	private void RemoveFocus()
	{
		UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (player.gameObject);
	}
	
	public void OptionsMenu()
	{
		SetPlayer ();

		Game.TogglePausedGame();

		GameObject optionsMenu = Game.GetOptionsMenu ();
		optionsMenu.SetActive (!optionsMenu.activeSelf);

		RemoveFocus ();
	}

	public void CharacterStatsMenu()
	{
		SetPlayer ();

		GameObject statsMenu = Game.GetStatsMenu ();
		statsMenu.SetActive (!statsMenu.activeSelf);

		RemoveFocus ();
	}

	public void CharacterWeaponPressed()
	{
		SetPlayer ();

		if (!Game.GamePaused && player.skills.mainSkill != null) {
			player.skills.mainSkill.UseSkill ();
		}

		RemoveFocus ();
	}

	public void CharacterSkill1Pressed()
	{
		SetPlayer ();

		if (!Game.GamePaused && player.skills.CheckSkill(0) != null) {
			player.skills.CheckSkill (0).UseSkill ();
		}

		RemoveFocus ();
	}

	public void CharacterSkill2Pressed()
	{
		SetPlayer ();

		if (!Game.GamePaused && player.skills.CheckSkill(1) != null) {
			player.skills.CheckSkill (1).UseSkill ();
		}

		RemoveFocus ();
	}

	public void CharacterSkill3Pressed()
	{
		SetPlayer ();

		if (!Game.GamePaused && player.skills.CheckSkill(2) != null) {
			player.skills.CheckSkill (2).UseSkill ();
		}

		RemoveFocus ();
	}



}
