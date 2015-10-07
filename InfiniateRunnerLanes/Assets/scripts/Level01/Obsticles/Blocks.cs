﻿using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;
	Vector3 scales = Vector3.zero;

	public bool shieldOn;
	
	public GameObject collisionPrefab;
	
	private bool gotHit;
	
	void Start () {

		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
		if (health <= 0f) {
			Destroy(gameObject);

		} else {
			speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
			/////////// Random starting angles:
		
			scales.x = Random.Range (10f, 100f);
			scales.y = Random.Range (10f, 100f);
			scales.z = Random.Range (10f, 100f);
		
			/////////// Spawn off the top of the screen in a random x position:
		
			transform.position = new Vector3 (Random.Range (-38f, 38f), Random.Range (-40f, 40f), 2000);
			transform.localScale = scales;
		}

		

	}
	
	void OnCollisionEnter(Collision col)
	{
		
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
			}else{
				destroy ();
			}
			gotHit=true;
			
		}
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;

	}
	
	void destroy(){
		Debug.Log ("DESTROY");
		
	//	Destroy (this.gameObject);
		Destroy (gameObject);
		
		
	}
	
	
	void Update () {
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
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