using UnityEngine;
using System.Collections;

public class enBholeController : MonoBehaviour {
	private GameObject player;

	private float playerHealth;
	
	private Vector3 playerPos;
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float scale;
	private Vector3 currentVelocity;
	/// <summary>
	/// A helper for storing euler angles. We store this to avoid gimbal lock.
	/// </summary>
	Vector3 angles = Vector3.zero;
    Vector3 scales = Vector3.zero;

	private bool wasHit;


	public float ForceSpeed = 60f;
	
	public void OnTriggerStay (Collider coll) {
		//Debug.Log ("inBHoleField");
		if (coll.gameObject.tag == ("Player")){

		} 
	}


    void Start () {
		player = GameObject.Find ("player");
		playerHealth = player.GetComponent<playercontroller> ().health;
	
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
        scale = Random.Range(5f, 25f);
        scales = new Vector3(10, 10, 10);

        /////////// Random starting angles:
        angles.x = Random.Range (0, 360);
        angles.y = Random.Range (0, 360);
        angles.z = Random.Range (0, 360);

        /////////// Spawn off the top of the screen in a random x position:

        transform.position = new Vector3 (Random.Range(-40f, 40f), Random.Range(-10f, 20f), 2000);
		transform.localScale = scales;
	}


	void OnCollisionEnter(Collision col)
	{
		
		player.GetComponent<playercontroller> ().shield = false;

		Debug.Log ("HIT SOMETHING");
		if (wasHit == false) {
			if (player.GetComponent<playercontroller> ().shield = true) {
				player.GetComponent<playercontroller> ().shield = false;
			} else if (player.GetComponent<playercontroller> ().shield = false) {
				player.GetComponent<playercontroller> ().health -= 90.0f;
			}
			wasHit=true;
		}
	}
	
	void Update () {

			player = GameObject.Find ("player");
		playerPos = player.transform.position;
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
        transform.localScale = scales;

        //////////// Spin the blackhole:
        //angles.x += 20 * Time.deltaTime;
        //angles.z += 40 * Time.deltaTime;

        //////////// Move the Blackhole
        Vector3 pos = transform.position;
		if (playerHealth >= .1f) {
			//transform.rotation = Quaternion.Euler (angles);
			pos.z -= speed * Time.deltaTime;
			transform.position = pos;
		}


		////OLD Gravity statement//////
//		if (pos.z <= 300f && pos.z>=0f) {
//			if(pos.x-playerPos.x<=50f && pos.y-playerPos.y<=50f){
//	
//				player.transform.position = Vector3.Lerp (playerPos, new Vector3(transform.position.x, transform.position.y, player.transform.position.z ), 1f*Time.deltaTime);
//			}
//
//		}


		//////////// If off the bottom of the screen, destroy this object:
		if (pos.z < -8) Destroy (gameObject);
	}
}
