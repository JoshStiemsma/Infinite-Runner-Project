using UnityEngine;
using System.Collections;

public class FanController : MonoBehaviour {
	private GameObject player;
	public float speed;
	private float health;
	public bool shieldOn;

	

	public bool Left;
	public bool Right;
	public bool Up;
	public bool Down;

	public float force;

	// Use this for initialization
	void Start () {
	if (force ==null) {
			force = 3000.0f;
		}
		health = player.GetComponent<playercontroller> ().health;
		if (health <= 0f) {
			Destroy(gameObject);
			
		} else {
			speed = player.GetComponent<playercontroller> ().forwardSpeed;;

			/////////// Spawn off the top of the screen in a random x position:
			
			transform.position = new Vector3 (0, 0, 2000);

		}
	}
	
	// Update is called once per frame
	void Update () {
		health = player.GetComponent<playercontroller> ().health;
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		//////////// Move the object:
		Vector3 pos = transform.position;
		
		pos.z -= speed * Time.deltaTime;


		if(health >= .1f){
			transform.position = pos;
		} else{//if health is under 0
			transform.position = transform.position;//do nothing	
		}

		if (pos.z < -8){ Destroy (gameObject);
			
		}
	}

	void OnTriggerStay(Collider other) {
		//Debug.Log ("ontrigger");
		if (other.attachedRigidbody)
		//	Debug.Log ("move rigid body");

		if (Left) {
			other.attachedRigidbody.AddForce (Vector3.left * 2000);
		}else if (Right) {
			other.attachedRigidbody.AddForce (Vector3.right * 2000);
		}else if (Up) {
			other.attachedRigidbody.AddForce (Vector3.up * 2000);
		}else if (Down) {
			other.attachedRigidbody.AddForce (Vector3.down * 2000);
		} 
	}
}
