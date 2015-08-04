using UnityEngine;
using System.Collections;

public class PlayerStats {

	public int Level{ get; set; }
	public int MaxExperience{ get; set; }
	public int Experience{ get; set; }
	
	public int Health{ get; set; }
	public int MaxHealth{ get; set; }
	public float Defense{ get; set; }
	
	public float AttackSpeed{ get; set; }
	public float AttackFrequency{ get; set; }
	public float AttackRange{ get; set; }
	public float AttackDamage{ get; set; }
	
	public float MoveSpeed{ get; set; }

	public PlayerStats()
	{
		Level = 1;
		MaxExperience = 100;
		Experience = 0;
		MaxHealth = 100;
		Health = MaxHealth;
		Defense = 0;
		AttackSpeed = 1;
		AttackFrequency = .1f;
		AttackRange = 10;
		AttackDamage = 1;
		MoveSpeed = 250;
	}
}
