using UnityEngine;
using System.Collections;

public class PickupItem : ICommand {

	Player player;
	public PickupItem(Player _player)
	{
		player = _player;
	}
	
	public void KeyDown()
	{
		Collider2D[] objects = Physics2D.OverlapCircleAll ((Vector2)player.gameObject.transform.position - new Vector2 (0, .5f), 1f);
		foreach (Collider2D obj in objects) {
			if(obj.CompareTag("Drop"))
			{
				IPickUp item = obj.GetComponent<IPickUp>();
				if(item != null)
				{
					item.AssignPickUp(player);
					break;
				}
			}
		}
	}
	
	public void KeyHeld()
	{
		//Do Nothing
	}
}
