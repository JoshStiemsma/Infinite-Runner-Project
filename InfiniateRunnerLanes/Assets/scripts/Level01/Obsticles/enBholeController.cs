using UnityEngine;
using System.Collections;

public class enBholeController : MonoBehaviour {

	private float playerHealth;
	
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



	public GameObject PullOBJ;
	public float ForceSpeed = 60f;
	
	public void OnTriggerStay (Collider coll) {
		//Debug.Log ("inBHoleField");
		if (coll.gameObject.tag == ("Player")){
			PullOBJ = coll.gameObject;
			PullOBJ.GetComponent<Rigidbody>().AddForce(Vector3.MoveTowards(
														PullOBJ.transform.position,
														transform.position, 
														ForceSpeed * Time.deltaTime));


//			PullOBJ.transform.position = Vector3.MoveTowards
//				(PullOBJ.transform.position,
//				 transform.position,
//				 ForceSpeed * Time.deltaTime);
		} 
	}


    void Start () {
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;;
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
        scale = Random.Range(5f, 25f);
        scales = new Vector3(10, 10, 10);

        /////////// Random starting angles:
        angles.x = Random.Range (0, 360);
        angles.y = Random.Range (0, 360);
        angles.z = Random.Range (0, 360);

        /////////// Spawn off the top of the screen in a random x position:

        transform.position = new Vector3 (Random.Range(-40f, 40f), Random.Range(-10f, 20f), 200);
		transform.localScale = scales;
	}


	void OnCollisionEnter(Collision col)
	{
		
		GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		Debug.Log ("HIT SOMETHING");
		if (wasHit == false) {
			if (GameObject.Find ("player").GetComponent<playercontroller> ().shield = true) {
				GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
			} else if (GameObject.Find ("player").GetComponent<playercontroller> ().shield = false) {
				GameObject.Find ("player").GetComponent<playercontroller> ().health -= 25.0f;
			}
			wasHit=true;
		}
	}
	
	void Update () {







		////////////////////////////BOOOOOOOST//////////////////////////////
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
        transform.localScale = scales;

        //////////// Spin the object:
        angles.x += 20 * Time.deltaTime;
        angles.z += 40 * Time.deltaTime;

        //////////// Move the object:
        Vector3 pos = transform.position;
		if (playerHealth >= .1f) {
			transform.rotation = Quaternion.Euler (angles);
			pos.z -= speed * Time.deltaTime;
			transform.position = pos;
		}
		//////////// If off the bottom of the screen, destroy this object:
		if (pos.z < -8) Destroy (gameObject);
	}
}
