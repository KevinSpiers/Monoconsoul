using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public PlayerStats stats;
	public SkillsManager skills;
	public ItemsManager items;
	IController controls;

	void Start () 
	{
		stats = new PlayerStats ();
		items = new ItemsManager ();
		skills = new SkillsManager ();
		controls = new KeyboardController (this);
	}

	void Update () 
	{
		controls.Execute ();
		skills.CoolDown ();
	}

}
