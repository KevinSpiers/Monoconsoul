using UnityEngine;
using System.Collections;

public class SkillCoolDown {
	private float MaxCooldownTime{ get; set; }
	private float CooldownTime{ get; set; }

	private bool cus;
	public bool CanUseSkill
	{ 
		get
		{
			return cus;
		}
	}

	public SkillCoolDown(float _maxCoolDownTime)
	{
		SetCoolDown (_maxCoolDownTime);
	}

	public void SetCoolDown(float _maxCoolDownTime)
	{
		MaxCooldownTime = _maxCoolDownTime;
		CooldownTime = 0f;
		cus = true;
	}

	public void CoolDown()
	{
		if (CooldownTime > 0f) {
			CooldownTime -= Time.deltaTime;
			cus = false;
		} else {
			cus = true;
		}
	}
	
	public void StartCoolDown()
	{
		CooldownTime = MaxCooldownTime;
	}
}
