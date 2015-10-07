﻿using UnityEngine;
using System.Collections;

public class InitFrameMovement1 : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;
	public bool renewable;
	//Vector3 scales = Vector3.zero;
	
	
	
	void Start () {
		
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
		if (health <= 0f) {
			Destroy(gameObject);
			
		} else {
			speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
			/////////// Random starting angles:
			
//			scales.x = Random.Range (1f, 100f);
//			scales.y = Random.Range (1f, 100f);
//			scales.z = Random.Range (1f, 100f);
			
			/////////// Spawn off the top of the screen in a random x position:
			
			//transform.position = new Vector3 (0, 0, 2000);
			//transform.localScale = scales;
		}
		
		
		
	}

	
	
	void Update () {
		
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		////////////////////////////BOOOOOOOST//////////////////////////////
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;

		//////////// Move the object:
		Vector3 pos = transform.position;
		pos.z -= speed * Time.deltaTime;
		
		if (health >= .1f) {
			transform.position = pos;
		} else {//if health is under 0
			transform.position = transform.position;
			
			
			
		}
		
		
		if (pos.z < -8) {
			if(renewable==false){
			Destroy(gameObject);
			} else{
				transform.position= new Vector3(pos.x, pos.y, 1245f);
			}
		}
	}
		

}