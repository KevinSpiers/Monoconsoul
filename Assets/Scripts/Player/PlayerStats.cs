using UnityEngine;
using System.Collections;

public class PlayerStats {

	private int lvl;
	public int Level
	{
		get
		{
			return lvl;
		}
	}
	private int exp;
	public int Experience
	{
		get
		{
			return exp;
		}
	}
	private int maxExp;
	public int MaxExperience
	{ 
		get
		{
			return maxExp;
		}
	}
	private int hp;
	public int Health
	{
		get
		{
			return hp;
		}
	}

	private int maxHp;
	private int b_maxHp;
	public int MaxHealth
	{
		get
		{
			if(maxHp+b_maxHp > 0){
				return maxHp+b_maxHp;
			}else{
				return 1;
			}
		}
	}

	private int def;
	private int b_def;
	public float Defense
	{
		get
		{
			if(def+b_def > 0){
				return def+b_def;
			}else{
				return 0;
			}
		}
	}

	private float attkFreq;
	private float b_attkFreq;
	public float AttackFrequency
	{
		get
		{
			if(attkFreq+b_attkFreq > 0){
				return attkFreq+b_attkFreq;
			}else{
				return 1;
			}
		}
	}

	private float attkDmg;
	private float b_attkDmg;
	public float AttackDamage
	{
		get
		{
			if(attkDmg+b_attkDmg > 10){
				return attkDmg+b_attkDmg;
			}else{
				return 10;
			}
		}
	}

	private float moveSpd;
	private float b_moveSpd;
	public float MoveSpeed
	{
		get
		{
			if(moveSpd+b_moveSpd > 50){
				return moveSpd+b_moveSpd;
			}else{
				return 50;
			}
		}
	}

    HealthExpUpdate hpExpBarUpdate = new HealthExpUpdate();
	public PlayerStats()
	{
		lvl = 1;
		maxExp = 100;
		exp = 0;
		b_maxHp = 100;
		hp = b_maxHp;
		b_def = 3;
		b_attkFreq = 1;
		b_attkDmg = 1;
		b_moveSpd = 0;

		maxHp = 0;
		def = 0;
		attkFreq = 0;
		attkDmg = 0;
		moveSpd = 0;
	}

    //Experience

	public void GainExperience(int _exp)
	{
		exp += _exp;
		if (exp >= maxExp) {
			exp -= maxExp;
			lvl += 1;
			maxExp = (int)((100 * Mathf.Pow (1.22863f,lvl-1) + 100 + (lvl-1) * 257.9f)/2);
		}
        hpExpBarUpdate.UpdateExperienceBar();
    }

    //Health

	public void GainHealth(int _heal)
	{
		if (hp + _heal > maxHp + b_maxHp) {
			hp = b_maxHp + maxHp;
		} else {
			hp += _heal;
		}
        hpExpBarUpdate.UpdateHealthBar();
    }

	public void LoseHealth(int _hurt)
	{
		if (hp - _hurt < 0) {
			hp = 0;
		} else {
			hp -= _hurt;
		}
        hpExpBarUpdate.UpdateHealthBar();
    }

    //Max Health

	public void GainBaseMaxHealth(int _maxHpGain)
	{
		float prop = hp / ((b_maxHp + maxHp) * 1.0f);
		b_maxHp += _maxHpGain;
		hp = (int)((b_maxHp + maxHp) * prop);
        hpExpBarUpdate.UpdateHealthBar();
    }

	public void LoseBaseMaxHealth(int _maxHpLose)
	{
		float prop = hp / ((b_maxHp + maxHp) * 1.0f);
		b_maxHp -= _maxHpLose;
		hp = (int)((b_maxHp + maxHp) * prop);
        hpExpBarUpdate.UpdateHealthBar();
    }

	public void GainMaxHealth(int _maxHpGain)
	{
		float prop = hp / ((b_maxHp + maxHp) * 1.0f);
		maxHp += _maxHpGain;
		hp = (int)((b_maxHp + maxHp) * prop);
        hpExpBarUpdate.UpdateHealthBar();
    }
	
	public void LoseMaxHealth(int _maxHpLose)
	{
		float prop = hp / ((b_maxHp + maxHp) * 1.0f);
		maxHp -= _maxHpLose;
		hp = (int)((b_maxHp + maxHp) * prop);
        hpExpBarUpdate.UpdateHealthBar();
    }

    //Defence

	public void GainBaseDefense(int _defGain)
	{
		b_def += _defGain;
	}
	
	public void LoseBaseDefense(int _defLose)
	{
		if (b_def - _defLose < 0) {
			b_def = 0;
		} else {
			b_def -= _defLose;
		}
	}

	public void GainDefense(int _defGain)
	{
		def += _defGain;
	}

	public void LoseDefense(int _defLose)
	{
		def -= _defLose;
	}

	//Attack Frequency

	public void GainBaseAttackFrequency(int _attkFreqGain)
	{
		b_attkFreq += _attkFreqGain;
	}
	
	public void LoseBaseAttackFrequency(int _attkFreqLose)
	{
		if (b_attkFreq - _attkFreqLose < 0) {
			b_attkFreq = 0;
		} else {
			b_attkFreq -= _attkFreqLose;
		}
	}
	
	public void GainAttackFrequency(int _attkFreqGain)
	{
		attkFreq += _attkFreqGain;
	}

	public void LoseAttackFrequency(int _attkFreqLose)
	{
		attkFreq -= _attkFreqLose;
	}

	public void GainBaseAttackDamage(int _attkDmgGain)
	{
		b_attkDmg += _attkDmgGain;
	}
	
	public void LoseBaseAttackDamage(int _attkDmgLose)
	{
		if (b_attkDmg - _attkDmgLose < 0) {
			b_attkDmg = 0;
		} else {
			b_attkDmg -= _attkDmgLose;
		}
	}

	public void GainAttackDamage(int _attkDmgGain)
	{
		attkDmg += _attkDmgGain;
	}

	public void LoseAttackDamage(int _attkDmgLose)
	{
		attkDmg -= _attkDmgLose;
	}

    //Movement Speed

	public void GainBaseMoveSpeed(int _moveSpdGain)
	{
		b_moveSpd += _moveSpdGain;
	}
	
	public void LoseBaseMoveSpeed(int _moveSpdLose)
	{
		if (b_moveSpd - _moveSpdLose < 0) {
			b_moveSpd = 0;
		} else {
			b_moveSpd -= _moveSpdLose;
		}
	}

	public void GainMoveSpeed(int _moveSpdGain)
	{
		moveSpd += _moveSpdGain;
	}

	public void LoseMoveSpeed(int _moveSpdLose)
	{
		moveSpd -= _moveSpdLose;
	}

}
