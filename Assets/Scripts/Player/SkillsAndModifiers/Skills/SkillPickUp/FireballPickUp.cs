using UnityEngine;
using System.Collections;

public class FireballPickUp : MonoBehaviour,ISkillPickUp {
	//TODO: Add more useful stuff here

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			Player player = other.GetComponent<Player>();
			//TODO: Add functionality to check open spot
			player.skills.SetSkill(new Fireball(player),0);
			Destroy(this.gameObject);
		}
	}
}
