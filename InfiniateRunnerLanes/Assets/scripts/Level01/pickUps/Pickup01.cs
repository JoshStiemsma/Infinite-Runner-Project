﻿using UnityEngine;
using System.Collections;

public class Pickup01 : MonoBehaviour {
	private GameObject player;
	public Vector3 rot;
	private Vector3 pos;
	public float speed;
	private float playerHealth;
	private bool picked;

	public bool dropped;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		rot = transform.eulerAngles;

		if (dropped) {
			
		} else {
			transform.position = new Vector3 (Random.Range (-40f, 40f), Random.Range (-35f, 35f), 2000);
		}
	
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player" && picked==false) {
			picked=true;
			Debug.Log ("GRABBED Pickup");
			player.GetComponent<playercontroller> ().pickUpCount++;
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		////////////////////////////BOOOOOOOST//////////////////////////////
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		playerHealth = player.GetComponent<playercontroller> ().health;
		
		//////////// Move the object:
		Vector3 pos = transform.position;
		pos.z -= speed * Time.deltaTime;
		rot.x += 20 * Time.deltaTime;
		rot.y += 20 * Time.deltaTime;




		if(playerHealth >= .1f){
			transform.rotation = Quaternion.Euler (rot);
			transform.position = pos;
		} else{//if health is under 0
			transform.position = transform.position;	
		}
		
		
		if (pos.z < -8){ Destroy (gameObject);
		}
	}
}
