﻿using UnityEngine;
using System.Collections;

	
	public class enSwipingController : MonoBehaviour {
	private GameObject player;
		
		public float speed;
		public float swipeSpeed;
		public float direction = 1;

	private bool shieldOn;
	private bool gotHit;

		Vector3 angles = Vector3.zero;
		
	private float playerHealth;

	public bool Clone;

		void Start () {
		player = GameObject.Find ("player");
		playerHealth = player.GetComponent<playercontroller> ().health;
		speed = player.GetComponent<playercontroller> ().forwardSpeed;

		if (player.GetComponent<playercontroller> ().level == 1) {
			swipeSpeed = 25;
		} else if (player.GetComponent<playercontroller> ().level == 2) {
			swipeSpeed = 75;
		} else if (player.GetComponent<playercontroller> ().level == 3) {
			swipeSpeed = 100;
		}

        float Rand = Random.Range(0, 100);
        if (Rand <= 50)
        {
            direction = 1;
        }else
        {
            direction = -1;
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x+100, pos.y, pos.z);

        }

			
			//transform.position = new Vector3 (Random.Range(-40f, 40f), 0, 1500);
			//transform.localScale = new Vector3(Random.Range(5f, 10f)*(transform.position.x/10),Random.Range(5f, 30f),Random.Range(5f, 30f));
		}

    void OnCollisionEnter(Collision col)
    {
        if (gotHit == false)
        {
            if (col.gameObject.tag == "Player")
            {
                if (player.GetComponent<playercontroller>().charMode != 1)
                {
                    if (shieldOn == true)
                    {
                        player.GetComponent<playercontroller>().shield = false;  //costed shield
                    }
                    else
                    {
                        player.GetComponent<playercontroller>().health -= 25.0f;    //cost damage
                    }
                }
                else
                { //No effect on player in hulk mode
                }
                Debug.Log("DESTROY via player");
           
                gotHit = true;
            }
        }


    }


    void Update () {
			
		if (Clone == true) {
			//transform.localScale = transform.parent.localScale;
			transform.position = new Vector3(transform.parent.position.x,transform.parent.position.y,transform.parent.position.z+800);
		} else if (Clone == false) {
			
	
		playerHealth = player.GetComponent<playercontroller> ().health; 
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		shieldOn = player.GetComponent<playercontroller> ().shield;
			//////////// Move the object:
		Vector3 pos = transform.position;
		pos.x += direction * swipeSpeed * Time.deltaTime;
		if (playerHealth >= .1f) {
			//pos.z -= speed * Time.deltaTime;
			transform.position = pos;
		}else {
			Destroy (gameObject);
		}//end  if player is dead
			
		}//end if clone or not
	}//endUpdate
	}//end class
