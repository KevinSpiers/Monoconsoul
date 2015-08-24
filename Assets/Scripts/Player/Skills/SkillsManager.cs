using UnityEngine;
using System.Collections;

public class SkillsManager {

	public static int skillLength = 3;
	private ISkill[] skill = new ISkill[skillLength];

	public int selectedSkillPos = 0;
	public ISkill selectedSkill = null;

	public IMainSkill mainSkill = null;
	
	//TODO: Add function to check open spot starting with the current selected skill position
	
	public IMainSkill CheckMainSkill()
	{
		return mainSkill;
	}

	public IMainSkill SetMainSkill(IMainSkill _mainSkill)
	{
		IMainSkill oldSkill = mainSkill;
		mainSkill = _mainSkill;

		return oldSkill;
	}
	
	//Sets the selected skill for Attack2
	public void SelectSkill()
	{
		selectedSkillPos = (selectedSkillPos + 1) % skillLength;
		selectedSkill = skill [selectedSkillPos];
	}

	public void RevSelectSkill()
	{
		selectedSkillPos -= 1;
		if (selectedSkillPos < 0) {
			selectedSkillPos += skillLength;
		}
		selectedSkill = skill [selectedSkillPos];
	}

	//Used for checking the Skills at a given position and for checking the modifiers at a given position. 
	public ISkill CheckSkill(int _position)
	{
		if (_position >= 0 && _position < skillLength) {
			return skill[_position];
		} else {
			return null;
		}
	}

	//Sets the skills and modifiers. Useful for when picking up or moving skills and modifiers.
	public ISkill SetSkill(ISkill _skill, int _position)
	{
		if (_position >= 0 && _position < skillLength) {
			ISkill oldSkill = skill[_position];
			skill[_position] = _skill;

			if(_position == selectedSkillPos){
				selectedSkill = _skill;
			}

			return oldSkill;
		} else {
			return null;
		}
	}

	//Always checks to see if any of the skills need to be put on cooldown
	public void CoolDown()
	{
		for(int i = 0; i < skillLength; i++){
			if(skill[i] != null){
				skill[i].skillCoolDown.CoolDown();
			}
		}
		if (mainSkill != null) {
			mainSkill.skillCoolDown.CoolDown ();
		}
	}
}
