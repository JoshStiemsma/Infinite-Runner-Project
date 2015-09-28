using UnityEngine;
using System.Collections;

public class wallController : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;



	
	void Start () {

		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
		if (health <= 0f) {
			Destroy(gameObject);

		} else {
			speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
			/////////// Random starting angles:
		

			/////////// Spawn off the top of the screen in a random x position:
		
			transform.position = new Vector3 (0, 0, 600);
	
		}

		

	}
	
	void OnCollisionEnter(Collision col)
	{
		
		Debug.Log ("HIT SOMETHING");
		GameObject.Find("player").GetComponent<playercontroller>().health -= 100.0f;
		if (col.collider.tag == "enemy"){
			
			Destroy(col.gameObject);
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
