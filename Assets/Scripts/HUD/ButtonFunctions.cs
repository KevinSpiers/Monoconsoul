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

		if (!Game.GamePaused && player.items.Weapon != null) {
			player.items.Weapon.UseWeapon ();
		}

		RemoveFocus ();
	}

	public void CharacterArmorPressed()
	{
		SetPlayer ();
		
		if (!Game.GamePaused && player.items.Armor != null) {
			player.items.Armor.UseArmor ();
		}
		
		RemoveFocus ();
	}

	/*Skills Start Here*/
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

	/*Items Start Here*/
	public void CharacterItem1Pressed()
	{
		SetPlayer ();
		
		if (!Game.GamePaused && player.items.CheckItem(0) != null) {
			player.items.CheckItem(0).UseItem();
		}
		
		RemoveFocus ();
	}

	public void CharacterItem2Pressed()
	{
		SetPlayer ();
		
		if (!Game.GamePaused && player.items.CheckItem(1) != null) {
			player.items.CheckItem(1).UseItem();
		}
		
		RemoveFocus ();
	}

	public void CharacterItem3Pressed()
	{
		SetPlayer ();
		
		if (!Game.GamePaused && player.items.CheckItem(3) != null) {
			player.items.CheckItem(3).UseItem();
		}
		
		RemoveFocus ();
	}

	public void CharacterItem4Pressed()
	{
		SetPlayer ();
		
		if (!Game.GamePaused && player.items.CheckItem(4) != null) {
			player.items.CheckItem(4).UseItem();
		}
		
		RemoveFocus ();
	}


}
