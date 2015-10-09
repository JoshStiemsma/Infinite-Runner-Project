using UnityEngine;
using System.Collections;

public class pickupShield : MonoBehaviour {
	
	private Vector3 pos;
	public float speed;
	private float playerHealth;


	public bool dropped;
	// Use this for initialization
	void Start () {

		if (dropped) {
			
		} else {
			transform.position = new Vector3 (Random.Range (-60f, 60f), Random.Range (-40f, 40f), 2000);
		}


		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("GRABBED SHIELD");
			GameObject.Find ("player").GetComponent<playercontroller> ().shield = true;
			Destroy (gameObject);
		}
	
	}
	// Update is called once per frame
	void Update () {
		////////////////////////////BOOOOOOOST//////////////////////////////
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		
		//////////// Move the object:
		Vector3 pos = transform.position;
		pos.z -= speed * Time.deltaTime;

		if(playerHealth >= .1f){
			transform.position = pos;
		} else{//if health is under 0
			transform.position = transform.position;	
		}		
		
		if (pos.z < -8){ Destroy (gameObject);
		}
	}
}
