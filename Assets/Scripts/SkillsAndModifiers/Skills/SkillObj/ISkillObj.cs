using UnityEngine;

public interface ISkillObj
{
	Vector3 StartLocation{ get; set; }
	Vector2 Direction{ get; set; }
	float Speed{ get; set; }
	float MaxDistanceCovered { get; set; }
	float Damage { get; set; }
}