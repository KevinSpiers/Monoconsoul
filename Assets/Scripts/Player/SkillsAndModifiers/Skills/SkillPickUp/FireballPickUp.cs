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

				player.skills.SetSkill (new Fireball (player), player.skills.selectedSkillPos);
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
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			player = other.GetComponent<Player> ();
		}
	}
}
