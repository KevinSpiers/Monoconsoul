
public interface ISkill
{
	CoolDownTimer skillCoolDown{ get; }
	void UseSkill();
	ModifiersManager modifierManager{ get; }
}