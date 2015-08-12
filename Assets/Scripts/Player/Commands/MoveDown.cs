using UnityEngine;
using System.Collections;

public class MoveDown : ICommand {
	Player player;
	Rigidbody2D rigidbody;
	public MoveDown(Player _player)
	{
		player = _player;
		rigidbody = player.GetComponent<Rigidbody2D> ();
	}

	public void KeyDown()
	{
		//Do Nothing
	}

	public void KeyHeld()
	{
		if (!Game.GamePaused) {
			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, -Time.fixedDeltaTime * player.stats.MoveSpeed);
		}
	}
}