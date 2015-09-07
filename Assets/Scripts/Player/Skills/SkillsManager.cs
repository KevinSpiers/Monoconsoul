using UnityEngine;
using System.Collections;

public class SkillsManager {

	public static int skillLength = 3;
	private ISkill[] skill = new ISkill[skillLength];

	public int selectedSkillPos = 0;
	public ISkill selectedSkill = null;

	private bool CheckIfHasSkill()
	{
		for (int i = 0; i < skillLength; i++) {
			if(skill[i] != null)
			{
				return true;
			}
		}
		return false;
	}

	public int NextOpenSkillSlotPos()
	{
		for (int i = 0; i < skillLength; i++) {
			if(skill[i] == null)
			{
				return i;
			}
		}
		return -1;
	}

	//Sets the selected skill for Attack2
	public void SelectSkill()
	{
		if (CheckIfHasSkill ()) {
			do {
				selectedSkillPos = (selectedSkillPos + 1) % skillLength;
				selectedSkill = skill [selectedSkillPos];
			} while(selectedSkill == null);
		}
	}

	public void RevSelectSkill()
	{
		if (CheckIfHasSkill()) {
			do {
				selectedSkillPos -= 1;
				if (selectedSkillPos < 0) {
					selectedSkillPos += skillLength;
				}
				selectedSkill = skill [selectedSkillPos];
			} while(selectedSkill == null);
		}
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
	}
}
