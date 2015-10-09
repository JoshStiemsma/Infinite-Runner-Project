using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public GameObject BombPrefab;
	public float speed;
	private float playerHealth;
	private bool shieldOn;
	public Vector3 angles;
	

	private bool flyingIn;
	private bool droppingBomb;
	private bool bombsDropped;
	private bool flyingOut;

	private bool initBombs;
	private bool initFinal;
	private float bombDelay;
	private float bombCount;

	private bool gotHit;
	private float enemySpeed;
	private float enemyHealth;
	private Vector3 playerPos;

	private float dropChoice;

	public GameObject Pickup01Prefab;
	public GameObject ShieldPrefab;
	public GameObject FuelPrefab;
	//private float enemyCount;
	//public GameObject AsteroidDivisioParticle;
	
	void Start () {
		enemyHealth = 100f;

		playerPos = GameObject.Find ("player").GetComponent<playercontroller> ().transform.position;
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		flyingIn = true;
		bombDelay = 4f;
		angles.x = 100f;
		if (playerHealth <= 0f) {
			Destroy(gameObject);
		} else {
			transform.position = new Vector3 (200, Random.Range (-300f, 300f), 0);
		}
	}


	void Update () {
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		playerPos = GameObject.Find ("player").GetComponent<playercontroller> ().transform.position;
		////////////////////////////BOOOOOOOST//////////////////////////////
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
		
		enemySpeed = (speed / 7) * Time.deltaTime;
		
		
		//////////// Move the object:
		Vector3 pos = transform.position;
		if (pos.x >= .1f && flyingIn == true) {
			flyingIn = true;
			droppingBomb = false;
			flyingOut = false;
		} 
		if (pos.x >= .1f && flyingOut == true) {
			flyingIn = false;
			droppingBomb = false;
			flyingOut = true;
		} 
		if (pos.x <= 0f && flyingIn == true) {
			flyingIn = false;
			droppingBomb = true;
			flyingOut = false;
		}

		if (bombCount>=5) {
			StopCoroutine ("StartSpawningBombs");
			if(initFinal==false){
				StartCoroutine ("SpawnMultBombs");
			initFinal = true;
			}
		}
		if (bombCount>=10) {
			flyingOut=true;
			flyingIn = false;
			droppingBomb = false;
			StopCoroutine ("SpawnMultBombs");
		}
		if (flyingIn) {
			pos.z += speed/2 * Time.deltaTime;
			pos.x -= speed/2 * Time.deltaTime;
			if(pos.y>=2f){
				pos.y -= speed/4 * Time.deltaTime;
			}
			if(pos.y<=-2f){
				pos.y += speed/4 * Time.deltaTime;
			}
		}
		if (droppingBomb) {
			if (initBombs == false) {
				StartCoroutine ("StartSpawningBombs");
				Debug.Log("Droppingbomb");
				initBombs = true;
			}
//			if(initFinal == true){
//
//				initFinal = false;
//			}

		}	
		if (flyingOut) {
			//.z += speed * Time.deltaTime;
			pos.x += speed/2 * Time.deltaTime;
		}


		
		if (playerHealth >= .1f) {
			if(droppingBomb){
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPos.x,playerPos.y,pos.z), enemySpeed);
			}else {
				transform.position = pos;
			}
		} else {//if health is under 0
			transform.position = transform.position;//do nothing	
		}
		angles.y += 200 * Time.deltaTime;
		transform.rotation = Quaternion.Euler (angles);
		
		if (flyingOut==true && pos.x > 200f) {
			Destroy (gameObject);
			StopCoroutine("StartSpawningBombs");
			StopCoroutine("SpawnMultBombs");
		}
		
	}
	GameObject SpawnBomb(){	
	return Instantiate (BombPrefab, transform.position, transform.rotation) as GameObject;

		//return Instantiate (BombPrefab);
	}




	void OnCollisionEnter(Collision col){
			if (col.gameObject.tag == "Bullet") {
				Debug.Log ("Hit Enemy with Bullet!");
				enemyHealth = enemyHealth - 50f;
			}
		if (enemyHealth <= 0f) {
			destroy ();
		}
	}
	void destroy(){
		Debug.Log ("Killed Enemy Ship");
		 dropChoice = Random.Range (-1.0f, 1.0f);
		if(dropChoice>=.3f){
			Instantiate ( Pickup01Prefab , new Vector3(transform.position.x+Random.Range(-10,10),transform.position.y+Random.Range(3,5),transform.position.z), Quaternion.identity);
			Instantiate ( ShieldPrefab , new Vector3(transform.position.x+Random.Range(-10,10),transform.position.y+Random.Range(3,5),transform.position.z), Quaternion.identity);
		}else if (dropChoice<-.3f){
			Instantiate ( FuelPrefab , new Vector3(transform.position.x+Random.Range(110,10),transform.position.y+Random.Range(3,5),transform.position.z), Quaternion.identity);
			Instantiate ( ShieldPrefab , new Vector3(transform.position.x+Random.Range(-10,10),transform.position.y+Random.Range(3,5),transform.position.z), Quaternion.identity);
		}else{
			Instantiate ( Pickup01Prefab , new Vector3(transform.position.x+Random.Range(-10,10),transform.position.y+Random.Range(3,5),transform.position.z), Quaternion.identity);
			Instantiate ( FuelPrefab , new Vector3(transform.position.x+Random.Range(-10,10),transform.position.y+Random.Range(3,5),transform.position.z), Quaternion.identity);
		}

		Destroy (this.gameObject);

	}




	IEnumerator StartSpawningBombs(){
		while(true){		
			SpawnBomb();
			bombCount++;
			yield return new WaitForSeconds(bombDelay);			
		}
	}
	IEnumerator SpawnMultBombs(){
		while(true){		
			SpawnBomb();
			bombCount++;
			yield return new WaitForSeconds(.5f);			
		}
	}


	}
