using UnityEngine;
using System.Collections;

public class CrossAsteroidController : MonoBehaviour {
	private GameObject player;
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;
	Vector3 angles = Vector3.zero;
	Vector3 scales = Vector3.zero;

	public bool shieldOn;

	public GameObject collisionPrefab;

	private bool gotHit;

	public GameObject AsteroidDivisioParticle;

	void Start () {
		player = GameObject.Find ("player");
		health = player.GetComponent<playercontroller> ().health;
		if (health <= 0f) {
			Destroy(gameObject);

		} else {
			speed = player.GetComponent<playercontroller> ().forwardSpeed;;
			/////////// Random starting angles:
			angles.x = Random.Range (0, 360);
			angles.y = Random.Range (0, 360);
			angles.z = Random.Range (0, 360);
		
//			scales.x = Random.Range (75f, 450f);
//			scales.y = Random.Range (75f, 450f);
//			scales.z = Random.Range (75f, 450f);
//		
			/////////// Spawn off the top of the screen in a random x position:
		
			transform.position = new Vector3 (Random.Range (40f, 80f), Random.Range (35f, 70f), Random.Range (0f, 200f));
			//transform.localScale = scales;
		}

		

	}
	
	void OnCollisionEnter(Collision col)
	{

	if (gotHit == false) {
			if (col.gameObject.tag == "Player" && shieldOn == false) {	
				player.GetComponent<playercontroller> ().health -= 25.0f;
				Instantiate (collisionPrefab, transform.position, Quaternion.identity);
			} else if (col.gameObject.tag == "Player" && shieldOn == true) {
				player.GetComponent<playercontroller> ().shield = false;
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
		shieldOn = player.GetComponent<playercontroller> ().shield;
		health = player.GetComponent<playercontroller> ().health;

			////////////////////////////BOOOOOOOST//////////////////////////////
		speed = player.GetComponent<playercontroller> ().forwardSpeed;

		//////////// Spin the object:
//		angles.x += 20 * Time.deltaTime;
//		angles.z += 40 * Time.deltaTime;



		
		
		//////////// Move the object:
		Vector3 pos = transform.position;
		pos.x -= speed/5 * Time.deltaTime;
		pos.y -= speed/10 * Time.deltaTime;
		pos.z -= speed/2 * Time.deltaTime;
		if(health >= .1f){
		//transform.rotation = Quaternion.Euler (angles);
		transform.position = pos;
		} else{//if health is under 0
			transform.position = transform.position;
		
		
			
		}


		if (pos.y < -4){ Destroy (gameObject);
		}

	
}
}
