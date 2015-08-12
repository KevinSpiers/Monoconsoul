using UnityEngine;
using System.Collections;

public class FireballPickUp : MonoBehaviour,ISkillPickUp {

	Player player;

	void OnTriggerStay2D(Collider2D other)
	{
		if (player != null && other.CompareTag ("Player")) {
			player.skills.canPickUpSkill = true;
			if (player.skills.isPickingUpSkill) {

				//TODO: Add functionality to check open spot starting with the current selected skill position

				//player.skills.SetSkill (new Fireball (player), player.skills.selectedSkillPos);
				player.skills.SetSkill(new Fireball(player),0);
				player.skills.isPickingUpSkill = false;
				player.skills.canPickUpSkill = false;
				Destroy (this.gameObject);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (player != null && other.CompareTag ("Player")) {
			player.skills.canPickUpSkill = false;
			player.skills.isPickingUpSkill = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			if (player == null) {
				player = other.GetComponent<Player> ();
			}
			player.skills.canPickUpSkill = true;
		}
	}
}
