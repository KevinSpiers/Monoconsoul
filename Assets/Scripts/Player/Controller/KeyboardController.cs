using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyboardController : IController {
	private Dictionary<KeyCode,ICommand> controlList;
	private Player player;

	public KeyboardController(Player _player)
	{
		controlList = new Dictionary<KeyCode,ICommand> ();
		player = _player;

		controlList.Add (KeyCode.W, new MoveUp (_player));
		controlList.Add (KeyCode.A, new MoveLeft (_player));
		controlList.Add (KeyCode.S, new MoveDown (_player));
		controlList.Add (KeyCode.D, new MoveRight (_player));
		controlList.Add (KeyCode.Tab, new CycleSkill (_player));
		controlList.Add (KeyCode.Mouse0, new Attack1 (_player));
		controlList.Add (KeyCode.Mouse1, new Attack2 (_player));
		controlList.Add (KeyCode.Escape, new PauseGame (_player));
		controlList.Add (KeyCode.E, new PickupItem (_player));
	}

	public void Execute () 
	{
		foreach (KeyCode key in controlList.Keys) 
		{
			if(Input.GetKeyDown(key))
			{
				ICommand cmd = null;
				controlList.TryGetValue(key,out cmd);
				if(cmd != null)
				{
					cmd.KeyDown();
				}
			}
			if(Input.GetKey(key))
			{
				ICommand cmd = null;
				controlList.TryGetValue(key,out cmd);
				if(cmd != null)
				{
					cmd.KeyPressed();
				}
			}
			else
			{
				Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
				Vector2 velocity = rigidbody.velocity;
				Vector2.SmoothDamp(velocity,Vector2.zero,ref velocity,3f);
				rigidbody.velocity = velocity;
			}
		}
	}
}
