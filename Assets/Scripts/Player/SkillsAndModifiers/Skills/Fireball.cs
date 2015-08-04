using UnityEngine;
using System.Collections;

public class Fireball : ISkill {
	private Player player;
	private SkillCoolDown skd;
	public SkillCoolDown skillCoolDown
	{ 
		get
		{
			return skd;
		} 
	}
	private ModifiersManager mm;
	public ModifiersManager modifierManager
	{ 
		get
		{
			return mm;
		}
	}
	public Fireball(Player _player)
	{
		player = _player;
		mm = new ModifiersManager ();
		skd = new SkillCoolDown (player.stats.AttackFrequency);
	}


	//TODO: Find better way to set values to initialized object
	private void CreateAttack()
	{
		//Initialize bullet
		GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet")) as GameObject;
		FireballObj bulletScript = bullet.GetComponent<FireballObj>();

		//Set initilization values
		Vector2 mouseScreenDif = (Input.mousePosition - Camera.main.WorldToScreenPoint(player.gameObject.transform.position));
		mouseScreenDif.Normalize();
		if(mouseScreenDif.x == 0 && mouseScreenDif.y == 0){
			mouseScreenDif = Vector2.up;
		}
		bulletScript.StartLocation = player.gameObject.transform.position + (Vector3)mouseScreenDif*.5f;
		bulletScript.Direction = mouseScreenDif;
		bulletScript.Speed = player.stats.AttackSpeed;
		bulletScript.MaxDistanceCovered = player.stats.AttackRange;
		bulletScript.Damage = player.stats.AttackDamage;
	}


	public void UseSkill()
	{
		if (skd.CanUseSkill) {
			CreateAttack();
			skd.StartCoolDown();
		}
	}
	
}
