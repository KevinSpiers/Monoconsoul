using UnityEngine;
using System.Collections;

public class MoveLeft : ICommand {
	Player player;
	Rigidbody2D rigidbody;
    Animator anim;
    public MoveLeft(Player _player)
	{
		player = _player;
		rigidbody = player.GetComponent<Rigidbody2D> ();
        anim = player.GetComponentInChildren<Animator>();
    }

	public void KeyDown()
	{
        if (!Game.GamePaused)
        {
            anim.SetBool("Left", true);
        }
	}

	public void KeyHeld()
	{
		if (!Game.GamePaused) {
			rigidbody.velocity = new Vector2 (-Time.fixedDeltaTime * 100.0f * player.stats.MoveSpeed, rigidbody.velocity.y);
            anim.SetBool("Left", true);
        }
	}

    public void KeyUp()
    {
        anim.SetBool("Left", false);
    }
}