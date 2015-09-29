using UnityEngine;
using System.Collections;

public class enBasicController : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;
	Vector3 angles = Vector3.zero;
	Vector3 scales = Vector3.zero;

	public bool shieldOn;


	
	void Start () {

	health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		if (health <= 0f) {
			Destroy(gameObject);

		} else {
			speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;;
			/////////// Random starting angles:
			angles.x = Random.Range (0, 360);
			angles.y = Random.Range (0, 360);
			angles.z = Random.Range (0, 360);
		
			scales.x = Random.Range (75f, 250f);
			scales.y = Random.Range (75f, 250f);
			scales.z = Random.Range (75f, 250f);
		
			/////////// Spawn off the top of the screen in a random x position:
		
			transform.position = new Vector3 (Random.Range (-60f, 60f), Random.Range (-40f, 40f), 600);
			transform.localScale = scales;
		}

		

	}
	
	void OnCollisionEnter(Collision col)
	{

	
		if (shieldOn == false) {
		
			GameObject.Find ("player").GetComponent<playercontroller> ().health -= 25.0f;
		} else if (shieldOn == true) {
			GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		} 
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		Destroy (this.gameObject);
	}
	
	
	void Update () {
		Debug.Log (shieldOn);
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;

			////////////////////////////BOOOOOOOST//////////////////////////////
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;

		//////////// Spin the object:
		angles.x += 20 * Time.deltaTime;
		angles.z += 40 * Time.deltaTime;



		
		
		//////////// Move the object:
		Vector3 pos = transform.position;
		pos.z -= speed * Time.deltaTime;

		if(health >= .1f){
		transform.rotation = Quaternion.Euler (angles);
		transform.position = pos;
		} else{//if health is under 0
			transform.position = transform.position;
		
		
			
		}


		if (pos.z < -8){ Destroy (gameObject);
		}

	
}
}
