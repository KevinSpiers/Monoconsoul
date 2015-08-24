using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public PlayerStats stats;
	public IPlayerState playerState;
	public SkillsManager skills;
	IController controls;

	public bool canPickUp = false;
	public bool isPickingUp = false;

	void Start () 
	{
		stats = new PlayerStats ();
		skills = new SkillsManager ();
		controls = new KeyboardController (this);
	}

	void Update () 
	{
		controls.Execute ();
		skills.CoolDown ();
	}
}
