using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;
	public bool shieldOn;

	public Vector3 angles;
	public Vector3 scales;

	private bool gotHit;
	private float enemyCount;
	public GameObject AsteroidDivisioParticle;
	public GameObject collisionPrefab;
	void Start () {

	health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		enemyCount = GameObject.Find ("Main Camera").GetComponent<gameController> ().enemyCount+1;
		//Debug.Log ("Enemies:" + enemyCount);
		if (health <= 0f) {
			Destroy(gameObject);

		} else {
			speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;;
			/////////// Random starting angles:
			angles.x = Random.Range (0, 360);
			angles.y = Random.Range (0, 360);
			angles.z = Random.Range (0, 360);
		
			scales.x = Random.Range (75f, 750f);
			scales.y = Random.Range (75f, 750f);
			scales.z = Random.Range (75f, 750f);
		
			/////////// Spawn off the top of the screen in a random x position:
		
			transform.position = new Vector3 (Random.Range (-38f, 38f), Random.Range (-40f, 40f), 1000);
			transform.localScale = scales;
		}

		

	}
	
	void OnCollisionEnter(Collision col){
	if (gotHit == false) {
			if (col.gameObject.tag == "Player" && shieldOn == false) {	
				GameObject.Find ("player").GetComponent<playercontroller> ().health -= 25.0f;
				Instantiate (collisionPrefab, transform.position, Quaternion.identity);
			} else if (col.gameObject.tag == "Player" && shieldOn == true) {
				GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
				Instantiate (collisionPrefab, transform.position, Quaternion.identity);
			} 
			if (col.gameObject.tag == "Bullet") {
				Debug.Log ("Hit");
			}
			gotHit=true;
		}
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		destroy ();
	}
	void destroy(){
		Debug.Log ("DESTROY");
		Instantiate (AsteroidDivisioParticle, new Vector3(transform.position.x, transform.position.y, transform.position.z ), Quaternion.identity);
		Destroy (this.gameObject);
		Destroy (gameObject);
	}

	void Update () {
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;

			//////////////////////////BOOOOOOOST//////////////////////////////
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;

		////////// Spin the object:
		angles.x += 20 * Time.deltaTime;
		angles.z += 40 * Time.deltaTime;



		
		
		//////////// Move the object:
		Vector3 pos = transform.position;

			pos.z -= speed * Time.deltaTime;
			
	


		if(health >= .1f){
		transform.rotation = Quaternion.Euler (angles);
		transform.position = pos;
		} else{//if health is under 0
			transform.position = transform.position;//do nothing	
		}


		if (pos.z < -8){ Destroy (gameObject);
			GameObject.Find ("Main Camera").GetComponent<gameController> ().enemyCount--;
		}

	
}
}
