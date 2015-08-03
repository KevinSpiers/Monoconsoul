using UnityEngine;
using System.Collections;

public class MoveRight : ICommand {
	Player player;
	Rigidbody2D rigidbody;
	public MoveRight(Player _player)
	{
		player = _player;
		rigidbody = player.GetComponent<Rigidbody2D> ();
	}

	public void KeyDown()
	{
		//Do Nothing
	}

	public void KeyPressed()
	{
		rigidbody.velocity = new Vector2(Time.fixedDeltaTime * player.stats.MoveSpeed,rigidbody.velocity.y);
	}
}
