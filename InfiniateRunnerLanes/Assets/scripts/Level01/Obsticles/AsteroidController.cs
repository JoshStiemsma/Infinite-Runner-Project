using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {
	private GameObject player;
	private Vector3 playerScale;

	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	private float health;
	private float damage;

	public float speed;
	private float playerHealth;
	public bool shieldOn;

	public Vector3 angles;
	public Vector3 scales;

	private bool gotHit;
	private float enemyCount;
	public GameObject AsteroidDivisioParticle;
	public GameObject collisionPrefab;
	private float dropChoice;

	public GameObject Pickup01Prefab;
	public GameObject ShieldPrefab;
	public GameObject FuelPrefab;



	private float distanceFromPlayer;



	void Start () {
		health = 100f;
		player = GameObject.Find ("player");
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		playerHealth = player.GetComponent<playercontroller> ().health;
		enemyCount = player.GetComponent<playercontroller> ().enemyCount+1;
		//Debug.Log ("Enemies:" + enemyCount);
		if (playerHealth <= 0f) {
			Destroy(gameObject);

		} else {
			speed = player.GetComponent<playercontroller> ().forwardSpeed;;
			/////////// Random starting angles:
			angles.x = Random.Range (0, 360);
			angles.y = Random.Range (0, 360);
			angles.z = Random.Range (0, 360);
		
			scales.x = Random.Range (150, 750f);
			scales.y = Random.Range (150, 750f);
			scales.z = Random.Range (150, 750f);
		
			/////////// Spawn off the top of the screen in a random x position:
		
			transform.position = new Vector3 (Random.Range (-38f, 38f), Random.Range (-40f, 40f), 2000);
			transform.localScale = new Vector3 (1, 1, 1);
		}

		

	}
	
	void OnCollisionExit(Collision col){
	if (gotHit == false) {
			if (col.gameObject.tag == "Player" && shieldOn == false) {	
				player.GetComponent<playercontroller> ().health -= 25.0f;
				Instantiate (collisionPrefab, transform.position, Quaternion.identity);
				Debug.Log ("DESTROY via player");
				destroy ();
			} else if (col.gameObject.tag == "Player" && shieldOn == true) {
				player.GetComponent<playercontroller> ().shield = false;
				Instantiate (collisionPrefab, transform.position, Quaternion.identity);
				Debug.Log ("DESTROY via player");
				destroy ();
			} 

			gotHit=true;
		}
		if (col.gameObject.tag == "Bullet") {


			distanceFromPlayer = transform.position.z;
			//can be 0-6000  so fr is 1/1 near is 0/1  with dist/6000

			damage = 50f * (1-(distanceFromPlayer/6001));
			health = health - damage;
		
			Debug.Log ("health: " + health + "   distace: " + distanceFromPlayer + "  Damage:  " + damage);
		}
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		if (health <= 0f) {
			destroy ();
			Debug.Log ("DESTROY via health");
		}
	}



	void destroy(){
		Instantiate (AsteroidDivisioParticle, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z ), Quaternion.identity);
		//Destroy (gameObject);
	
		dropChoice = Random.Range (-1.0f, 1.0f);
		if(dropChoice<=-.95f){
			Instantiate ( Pickup01Prefab , new Vector3(player.transform.position.x+Random.Range(-10,10),player.transform.position.y+Random.Range(3,5),transform.position.z), Quaternion.identity);
		}else if (dropChoice<-.8f && dropChoice>=-.94f){
			Instantiate ( ShieldPrefab , new Vector3(player.transform.position.x+Random.Range(-10,10),player.transform.position.y+Random.Range(3,5),transform.position.z), Quaternion.identity);
		}else if (dropChoice<-.5f && dropChoice>=-.79f){
			Instantiate ( FuelPrefab , new Vector3(player.transform.position.x+Random.Range(-10,10),player.transform.position.y+Random.Range(3,5),transform.position.z), Quaternion.identity);
		} else {

		}
		
		Destroy (this.gameObject);
		
	}

	void Update () {
		shieldOn = player.GetComponent<playercontroller> ().shield;
		playerHealth = player.GetComponent<playercontroller> ().health;

			//////////////////////////BOOOOOOOST//////////////////////////////
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		playerScale = transform.localScale;

		////////// Spin the object:
		angles.x += 20 * Time.deltaTime;
		angles.z += 40 * Time.deltaTime;



		if (playerScale.x <= scales.x) {
			playerScale.x = playerScale.x +7f;
		}
		if (playerScale.y <= scales.y) {
			playerScale.y = playerScale.y +5f;
		}
		if (playerScale.z <= scales.z) {
			playerScale.z = playerScale.z +5f;
		}

		transform.localScale = new Vector3( playerScale.x, playerScale.y, playerScale.z);

		
		//////////// Move the object:
		Vector3 pos = transform.position;

			pos.z -= speed * Time.deltaTime;
			
	


		if(playerHealth >= .1f){
		transform.rotation = Quaternion.Euler (angles);
		transform.position = pos;
		} else{//if health is under 0
			transform.position = transform.position;//do nothing	
		}


		if (pos.z < -8){ Destroy (gameObject);

		}

	
}
}
