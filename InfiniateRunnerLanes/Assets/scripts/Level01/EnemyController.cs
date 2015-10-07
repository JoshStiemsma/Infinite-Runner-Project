using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public GameObject BombPrefab;
	public float speed;
	private float health;
	private bool shieldOn;
	
	private bool flyingIn;
	private bool droppingBomb;
	private bool bombsDropped;
	private bool flyingOut;

	private bool initBombs;
	private float bombDelay;
	private float bombCount;

	private bool gotHit;
	private float enemySpeed;

	private Vector3 playerPos;
	//private float enemyCount;
	//public GameObject AsteroidDivisioParticle;
	
	void Start () {
		playerPos = GameObject.Find ("player").GetComponent<playercontroller> ().transform.position;
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		flyingIn = true;
		bombDelay = 1f;

		if (health <= 0f) {
			Destroy(gameObject);
		} else {
			transform.position = new Vector3 (200, 0, 0);
		}
	}


	void Update () {
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
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

		if (bombCount>=4) {
			flyingOut=true;
			flyingIn = false;
			droppingBomb = false;
			StopCoroutine ("StartSpawningBombs");
		}

		if (flyingIn) {
			pos.z += speed/2 * Time.deltaTime;
			pos.x -= speed/2 * Time.deltaTime;
		}
		if (droppingBomb) {
			if (initBombs == false) {
				StartCoroutine ("StartSpawningBombs");
				Debug.Log("Droppingbomb");
				initBombs = true;
			}

		}	
		if (flyingOut) {
			//.z += speed * Time.deltaTime;
			pos.x += speed/2 * Time.deltaTime;
		}


		
		if (health >= .1f) {
			if(droppingBomb){
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerPos.x,playerPos.y,pos.z), enemySpeed);
			}else {
				transform.position = pos;
			}
		} else {//if health is under 0
			transform.position = transform.position;//do nothing	
		}
		
		
		if (flyingOut==true && pos.x > 200f) {
			Destroy (gameObject);
		}
		
	}
	GameObject SpawnBomb(){	
	return Instantiate (BombPrefab, transform.position, transform.rotation) as GameObject;

		//return Instantiate (BombPrefab);
	}

	IEnumerator StartSpawningBombs(){
		while(true){		
			SpawnBomb();
			bombCount++;
			yield return new WaitForSeconds(bombDelay);			
		}
	}


	}
