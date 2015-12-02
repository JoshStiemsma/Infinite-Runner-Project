using UnityEngine;
using System.Collections;

public class pickupShield : MonoBehaviour {
	private GameObject player;
	private Vector3 pos;
	public float speed;
	private float playerHealth;


	public bool dropped;
	private int world;
	private int dir = 1;
	private float dirCounter;
	// Use this for initialization
	void Start () {

		player = GameObject.Find ("player");
		world = player.transform.GetComponent<playercontroller> ().world;

		if (world != 3) {
			if (dropped) {
			
			} else {
				transform.position = new Vector3 (Random.Range (-60f, 60f), Random.Range (-40f, 40f), 2000);
			}
			speed = player.GetComponent<playercontroller> ().forwardSpeed;
		} 
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("GRABBED SHIELD");
			player.GetComponent<playercontroller> ().shield = true;
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
        if (world == 1)
        {
            pos.z -= speed * Time.deltaTime;

            if (pos.z < -8)
            {
                Destroy(gameObject);
            }

        }
        else
        {
            pos.y = pos.y + 10 * dir * Time.deltaTime;

            if (dirCounter <= 2)
            {
                dirCounter = dirCounter + 1 * Time.deltaTime;
            }
            else
            {
                dirCounter = 0;
                dir = dir * -1;
            }

            if (player.transform.position.z >= transform.position.z + 5f)
            {
                Destroy(gameObject);
            }

        }
        if (playerHealth >= .1f){
			transform.position = pos;
		} else{//if health is under 0
			transform.position = transform.position;	
		}		
		

	}
}
