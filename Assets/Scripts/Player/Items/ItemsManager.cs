using UnityEngine;
using System.Collections;

public class ItemsManager {

	public static int itemLength = 4;
	private Iitem[] item = new Iitem[itemLength];

	private Iarmor armor = null;
	public Iarmor Armor
	{ 
		get
		{
			return armor;
		}
	}
	private Iweapon weapon = null;
	public Iweapon Weapon
	{ 
		get
		{
			return weapon;
		}
	}

	public Iarmor SetArmor(Iarmor _armor)
	{
		Iarmor oldArmor = armor;
		armor = _armor;
		return oldArmor;
	}

	public Iweapon SetWeapon(Iweapon _weapon)
	{
		Iweapon oldWeapon = weapon;
		weapon = _weapon;
		return oldWeapon;
	}

	//Used for checking the Items at a given position
	public Iitem CheckItem(int _position)
	{
		if (_position >= 0 && _position < itemLength) {
			return item[_position];
		} else {
			return null;
		}
	}
	
	//Sets the Items. Useful for when picking up or moving Items.
	public Iitem SetItem(Iitem _item, int _position)
	{
		if (_position >= 0 && _position < itemLength) {
			Iitem oldItem = item[_position];
			item[_position] = _item;

			return oldItem;
		} else {
			return null;
		}
	}
	
	//Always checks to see if any of the Items need to be put on cooldown
	public void CoolDown()
	{
		for(int i = 0; i < itemLength; i++){
			if(item[i] != null){
				item[i].itemCoolDown.CoolDown();
			}
		}
	}
}
