using UnityEngine;
using System.Collections;

public class SWCycleSkill : IACommand {
	
	Player player;
	public SWCycleSkill(Player _player)
	{
		player = _player;
	}

	public void PositiveAxis(float num)
	{
		if (num >= .1) {
			if (!Game.GamePaused) {
				player.skills.SelectSkill ();
			}
		}
	}

	public void NegativeAxis(float num)
	{
		if (num <= .1) {
			if (!Game.GamePaused) {
				player.skills.RevSelectSkill ();
			}
		}
	}
}
