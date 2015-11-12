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
		Collider2D[] objects = Physics2D.OverlapCircleAll ((Vector2)player.gameObject.transform.position, 6f);
        Collider2D closestObj = null;
        float shortestDist = 1000.0f;
        float distancePlayerToObj = shortestDist;

        foreach (Collider2D obj in objects) {
			if(obj.CompareTag("Drop"))
			{
                IPickUp item = obj.GetComponent<IPickUp>();
                if (item != null)
                {
                    distancePlayerToObj = Vector3.Distance(player.transform.position, obj.transform.position);
                    if (distancePlayerToObj <= shortestDist)
                    {
                       closestObj = obj;
                       shortestDist = distancePlayerToObj;
                    }
				}
			}
		}
        if (closestObj != null)
        {
            IPickUp item = closestObj.GetComponent<IPickUp>();
            item.AssignPickUp(player);
        }
    }
	
	public void KeyHeld()
	{
		//Do Nothing
	}

    public void KeyUp()
    {

    }
}
