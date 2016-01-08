using UnityEngine;
using System.Collections;

public class MoveUp : ICommand {
	Player player;
	Rigidbody2D rigidbody;
    Animator anim;
    public MoveUp(Player _player)
	{
		player = _player;
		rigidbody = player.GetComponent<Rigidbody2D> ();
        anim = player.GetComponentInChildren<Animator>();
	}

	public void KeyDown()
	{
        if (!Game.GamePaused)
        {
            anim.SetBool("Up", true);
        }
    }

	public void KeyHeld()
	{
		if (!Game.GamePaused) {
			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, Time.fixedDeltaTime * 100.0f *player.stats.MoveSpeed);
            anim.SetBool("Up", true);
        }
	}

    public void KeyUp()
    {
        anim.SetBool("Up", false);
    }
}
