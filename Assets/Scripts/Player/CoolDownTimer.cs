using UnityEngine;
using System.Collections;

public class CoolDownTimer {
	private float MaxCooldownTime{ get; set; }
	private float CooldownTime{ get; set; }

	private bool cu;
	public bool CanUse
	{ 
		get
		{
			return cu;
		}
	}

	public CoolDownTimer(float _maxCoolDownTime)
	{
		SetCoolDown (_maxCoolDownTime);
	}

	public void SetCoolDown(float _maxCoolDownTime)
	{
		MaxCooldownTime = _maxCoolDownTime;
		CooldownTime = 0f;
		cu = true;
	}

	public void CoolDown()
	{
		if (CooldownTime > 0f) {
			CooldownTime -= Time.deltaTime;
			cu = false;
		} else {
			cu = true;
		}
	}
	
	public void StartCoolDown()
	{
		CooldownTime = MaxCooldownTime;
	}
}
