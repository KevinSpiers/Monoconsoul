using UnityEngine;
using System.Collections;

public class FireballPickUp : MonoBehaviour, IPickUp {
	public void AssignPickUp(Player _player)
	{
		_player.skills.SetSkill (new Fireball (_player), _player.skills.NextOpenSkillSlotPos ());
		Destroy (this.gameObject);
	}
}
