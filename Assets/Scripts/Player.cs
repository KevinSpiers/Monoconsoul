using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public PlayerStats stats;
	public IPlayerState playerState;
	public SkillsManager skills;
	public ModifiersManager modifiers;
	IController controls;

	void Start () 
	{
		stats = new PlayerStats ();
		skills = new SkillsManager ();
		controls = new KeyboardController (this);

		skills.SetSkill (new Fireball (this), 0);
	}

	void Update () 
	{
		controls.Execute ();
		skills.CoolDown ();
	}
}
