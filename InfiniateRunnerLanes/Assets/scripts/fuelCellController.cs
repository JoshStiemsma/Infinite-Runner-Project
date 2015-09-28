using UnityEngine;
using System.Collections;

public class fuelCellController : MonoBehaviour {

	private Vector3 rot;
	private Vector3 pos;
	private float speed;
	private float playerHealth;
	
	// Use this for initialization
	void Start () {
		rot = transform.eulerAngles;
		transform.position = new Vector3 (Random.Range (-60f, 60f), Random.Range (-40f, 40f), 600);
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
	}

	void OnCollisionEnter(Collision col)
	{
		GameObject.Find ("player").GetComponent<playercontroller> ().fuel = GameObject.Find ("player").GetComponent<playercontroller> ().fuel + 25f;
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
		////////////////////////////BOOOOOOOST//////////////////////////////

		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		
		//////////// Move the object:
		Vector3 pos = transform.position;
		pos.z -= speed * Time.deltaTime;
		rot.x += 50 * Time.deltaTime;
		rot.y += 50 * Time.deltaTime;




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
