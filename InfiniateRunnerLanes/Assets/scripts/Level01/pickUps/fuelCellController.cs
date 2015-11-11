using UnityEngine;
using System.Collections;

public class fuelCellController : MonoBehaviour {
	private GameObject player;

	private Vector3 rot;
	private Vector3 pos;
	private float speed;
	private float playerHealth;

	public bool dropped;
	private int world;
	private int dir = 1;
	private float dirCounter;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		rot = transform.eulerAngles;
		world = player.transform.GetComponent<playercontroller> ().world;

		if (dropped) {

		} else {
			transform.position = new Vector3 (Random.Range (-60f, 60f), Random.Range (-40f, 40f), 2000);
		}
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			player.GetComponent<playercontroller> ().fuel = player.GetComponent<playercontroller> ().fuel + 33f;
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		////////////////////////////BOOOOOOOST//////////////////////////////

		playerHealth = player.GetComponent<playercontroller> ().health;
		
		//////////// Move the object:
		Vector3 pos = transform.position;

		rot.x += 50 * Time.deltaTime;
		rot.y += 50 * Time.deltaTime;

		
		if (world != 3) {
			pos.z -= speed * Time.deltaTime;
		} else {
			pos.y = pos.y + 10*dir *Time.deltaTime;
			
			if(dirCounter<=2){
				dirCounter = dirCounter + 1*Time.deltaTime;
			}else{
				dirCounter=0;
				dir = dir*-1;
			}
			
		}


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
