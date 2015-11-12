using UnityEngine;
using System.Collections;

public class MoveDown : ICommand {
	Player player;
	Rigidbody2D rigidbody;
    Animator anim;
    public MoveDown(Player _player)
	{
		player = _player;
		rigidbody = player.GetComponent<Rigidbody2D> ();
        anim = player.GetComponentInChildren<Animator>();
    }

	public void KeyDown()
	{
        anim.SetBool("Down", true);
    }

	public void KeyHeld()
	{
		if (!Game.GamePaused) {
			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, -Time.fixedDeltaTime * 100.0f * player.stats.MoveSpeed);
		}
	}

    public void KeyUp()
    {
        anim.SetBool("Down", false);
    }
}