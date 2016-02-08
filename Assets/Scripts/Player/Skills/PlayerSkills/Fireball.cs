using UnityEngine;
using System.Collections;

public class Fireball : ISkill {
	private Player player;
	private CoolDownTimer skd;
    private Animator anim;
	public CoolDownTimer skillCoolDown
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
		skd = new CoolDownTimer (player.stats.AttackFrequency);
        anim = player.GetComponentInChildren<Animator>();
    }
	
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
        Rigidbody2D player_rigidbody = player.GetComponent<Rigidbody2D>();
        Vector2 player_velocity = player_rigidbody.velocity.normalized/10;
		Vector2 startLocation = player.gameObject.transform.position + Vector3.up*4 + (Vector3)mouseScreenDif * 13;
		bulletScript.Make(startLocation,mouseScreenDif + player_velocity,100,150,player.stats.AttackDamage);
	}


	public void UseSkill()
	{
		if (skd.CanUse) {
			CreateAttack();
            anim.SetTrigger("Cast");
            skd.StartCoolDown();
		}
	}
	
}
