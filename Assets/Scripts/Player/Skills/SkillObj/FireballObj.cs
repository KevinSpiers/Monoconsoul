using UnityEngine;
using System.Collections;

public class FireballObj : MonoBehaviour, ISkillObj {

	private Vector2 StartLocation;
	private Vector2 Direction;
	private float Speed;
	private float MaxDistanceCovered;
	private float Damage;

	private float distanceCovered;

	public void Make(Vector2 _startLocation,Vector2 _direction, float _attackSpeed, float _range, float _damage)
	{
		StartLocation = _startLocation;
		Direction = _direction;
		Speed = _attackSpeed;
		MaxDistanceCovered = _range;
		Damage = _damage;
	}

	void Start () 
	{
		this.gameObject.transform.position = StartLocation;
		Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D> ();
        rigidbody.transform.rotation = new Quaternion(Vector2.up.x + Direction.x, Vector2.up.y + Direction.y, 0f, 0f);
        Debug.Log(rigidbody.transform.rotation);
		rigidbody.velocity =  Direction * Speed;
		distanceCovered = 0f;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag ("Player") && !other.CompareTag("Drop") && !other.CompareTag("Attack")) {
			if(other.CompareTag("Enemy")){
				//Attack Enemy
			}
			Destroy(this.gameObject);
		}
	}

	void Update () 
	{
		if (distanceCovered < MaxDistanceCovered) {
			distanceCovered = distanceCovered + (StartLocation - (Vector2)this.gameObject.transform.position).magnitude;
			StartLocation = this.gameObject.transform.position;
		} else {
			Destroy(this.gameObject);
		}
	}
}
