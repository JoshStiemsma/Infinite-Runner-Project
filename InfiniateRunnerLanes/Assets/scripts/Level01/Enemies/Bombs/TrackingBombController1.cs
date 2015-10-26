﻿using UnityEngine;
using System.Collections;

public class TrackingBombController1 : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	private float speed;
	private float health;
	private bool shieldOn;
	private Vector3 playerPos;

	private bool gotHit;

	private bool yellow;
	private bool white;

	private Vector3 scale;
	private Vector3 angles;

	private bool up;
	private bool right;
	private float spacer;

	public GameObject FuelPrefab;
	public GameObject ExplosionPrefab;

	void Start () {
	
		scale = transform.localScale;
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		//Debug.Log ("Enemies:" + enemyCount);
		if (health <= 0f) {
			Destroy(gameObject);
			
		} else {
			speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;;		
			angles.x = Random.Range (0, 360);
			angles.y = Random.Range (0, 360);
			angles.z = Random.Range (0, 360);
		}

		flipUp ();
		Invoke("flipRight", .25f);
		
	}
	
	void OnCollisionEnter(Collision col){
		if (gotHit == false) {
			if (col.gameObject.tag == "Player" && shieldOn == false) {	
				GameObject.Find ("player").GetComponent<playercontroller> ().health -= 25.0f;
			} else if (col.gameObject.tag == "Player" && shieldOn == true) {
				GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
			} 
			if (col.gameObject.tag == "Bullet") {
				Debug.Log ("Hit");
				Instantiate ( FuelPrefab , transform.position, Quaternion.identity);
				destroy ();
			}
			gotHit=true;
		}
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;

	}
	void destroy(){
		Debug.Log ("DESTROY");
		Destroy (this.gameObject);
		Destroy (gameObject);
	}
	
	void Update () {
		playerPos = GameObject.Find ("player").transform.position;
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		scale = transform.localScale;
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;


		//////////// Move the object:
		Vector3 pos = transform.position;	
		////////// rotate the bomb:
		angles.x += 20 * Time.deltaTime;
		angles.z += 40 * Time.deltaTime;


		if (playerPos.x > pos.x) {
			pos.x = pos.x + speed / 10 * Time.deltaTime;
		}else if (playerPos.x < pos.x) {
			pos.x = pos.x - speed / 10 * Time.deltaTime;
		}
		if (playerPos.y > pos.y) {
			pos.y = pos.y + speed / 10 * Time.deltaTime;
		}else if (playerPos.y < pos.y) {
			pos.y = pos.y - speed / 10 * Time.deltaTime;
		}




//		///SPiral effect///////
//		spacer = spacer * (Time.deltaTime*2);
//		if (right) {
//			pos.x = pos.x + speed / 20 * Time.deltaTime + spacer;
//		} else {
//			pos.x = pos.x - speed / 20 * Time.deltaTime - spacer;
//		}
//
//
//		if (up) {
//			pos.y = pos.y + speed / 20 * Time.deltaTime+ spacer;
//		} else {
//			pos.y = pos.y - speed / 20 * Time.deltaTime - spacer; 
//		}


		pos.z -= speed/3 * Time.deltaTime;

		if(health >= .1f){
			transform.position = pos;
			transform.rotation = Quaternion.Euler (angles);

		} else{//if health is under 0
			transform.position = transform.position;//do nothing	
		}

		
		if (pos.z <= 10) { 
///EXPLODE HERE		
			Instantiate (ExplosionPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		
	}

	void flipUp(){
		up = !up;
		Invoke("flipUp", .5f);
	}
	void flipRight(){
		right = !right;
		Invoke("flipRight", .5f);
	}

}

