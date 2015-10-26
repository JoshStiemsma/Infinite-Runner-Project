using UnityEngine;
using System.Collections;

public class wallController : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;

	private bool shieldOn;
	private bool gotHit;

	
	void Start () {

		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
		if (health <= 0f) {
			Destroy(gameObject);

		} else {
			speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
			/////////// Random starting angles:
		

			/////////// Spawn off the top of the screen in a random x position:
		
			transform.position = new Vector3 (0, 50, 1500);
	
		}

		

	}






	void OnCollisionEnter(Collision col)
	{
		
		if (gotHit == false) {
			if (col.gameObject.tag == "Player" && shieldOn == false) {	
				GameObject.Find ("player").GetComponent<playercontroller> ().health -= 25.0f;
				Debug.Log("player git Swiping block");
			} else if (col.gameObject.tag == "Player" && shieldOn == true) {
				GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
			} 
			gotHit=true;
			
		}
		
	}

	void OnTriggerEnter( Collider col ) {
		if ( col.gameObject.tag == "enemy" ) {
			Destroy(col.gameObject);
		}
	}
	
	void Update () {
	
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
			////////////////////////////BOOOOOOOST//////////////////////////////
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
		
		
		//////////// Move the object:
		Vector3 pos = transform.position;
		pos.z -= speed * Time.deltaTime;

		if(health >= .1f){
		transform.position = pos;
		} else{//if health is under 0
			transform.position = transform.position;	
		}


		if (pos.z < -8){ Destroy (gameObject);
		}

	
}
}
