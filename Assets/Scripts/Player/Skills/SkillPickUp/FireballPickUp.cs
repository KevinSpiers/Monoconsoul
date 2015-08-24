using UnityEngine;
using System.Collections;

public class FireballPickUp : MonoBehaviour,ISkillPickUp {

	Player player;

	void OnTriggerStay2D(Collider2D other)
	{
		if (player != null && other.CompareTag ("Player")) {
			player.canPickUp = true;
			if (player.isPickingUp) {

				//TODO: Add functionality to check open spot starting with the current selected skill position

				//player.skills.SetSkill (new Fireball (player), player.skills.selectedSkillPos);
				player.skills.SetSkill(new Fireball(player),0);
				player.isPickingUp = false;
				player.canPickUp = false;
				Destroy (this.gameObject);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (player != null && other.CompareTag ("Player")) {
			player.canPickUp = false;
			player.isPickingUp = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			if (player == null) {
				player = other.GetComponent<Player> ();
			}
			player.canPickUp = true;
		}
	}
}
