using UnityEngine;
using System.Collections;

public class FireballObj : MonoBehaviour, ISkillObj {

	public Vector3 StartLocation{ get; set; }
	public Vector2 Direction{ get; set; }
	public float Speed{ get; set; }
	public float MaxDistanceCovered { get; set; }
	public float Damage { get; set; }

	private float distanceCovered;

	void Start () 
	{
		this.gameObject.transform.position = StartLocation;
		Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D> ();
		rigidbody.AddForce (Direction * Speed * 300);
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
			distanceCovered = distanceCovered + (StartLocation - this.gameObject.transform.position).magnitude;
			StartLocation = this.gameObject.transform.position;
		} else {
			Destroy(this.gameObject);
		}
	}
}
