
public interface ISkill
{
	SkillCoolDown skillCoolDown{ get; }
	void UseSkill();
	ModifiersManager modifierManager{ get; }
}