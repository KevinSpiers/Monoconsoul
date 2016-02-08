using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.stats.LoseHealth(5);
        }
    }
}
