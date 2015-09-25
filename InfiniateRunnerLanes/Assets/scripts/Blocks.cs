using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;
	Vector3 scales = Vector3.zero;


	
	void Start () {

		health = GameObject.Find ("player").GetComponent<playercontroller> ().health;

		if (health <= 0f) {
			Destroy(gameObject);

		} else {
			speed = 25f;
			/////////// Random starting angles:
		
			scales.x = Random.Range (1f, 100f);
			scales.y = Random.Range (1f, 100f);
			scales.z = Random.Range (1f, 100f);
		
			/////////// Spawn off the top of the screen in a random x position:
		
			transform.position = new Vector3 (Random.Range (-60f, 60f), Random.Range (-40f, 40f), 600);
			transform.localScale = scales;
		}

		

	}
	
	void OnCollisionEnter(Collision col)
	{
		
		Debug.Log ("HIT SOMETHING");
		GameObject.Find("player").GetComponent<playercontroller>().health -= 25.0f;;
	}
	
	
	void Update () {
		health = GameObject.Find ("player").GetComponent<playercontroller> ().health;

			////////////////////////////BOOOOOOOST//////////////////////////////
		if (Input.GetButtonDown ("Jump")) {
			speed = 250f;
		}
		if (Input.GetButton ("Jump")) {
			speed = 250f;
		}		
		if (Input.GetButtonUp("Jump")){
			speed = 50f;
		}

		
		
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
