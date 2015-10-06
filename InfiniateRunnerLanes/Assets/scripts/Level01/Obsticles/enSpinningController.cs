using UnityEngine;
using System.Collections;

public class enSpinningController : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	/// <summary>
	/// A helper for storing euler angles. We store this to avoid gimbal lock.
	/// </summary>
	Vector3 angles = Vector3.zero;

	private float playerHealth;

	void Start () {
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
		playerHealth = GameObject.Find ("player").GetComponent<playercontroller> ().health;
		/////////// Random starting angles:
		//angles.x = Random.Range (0, 360);
		//angles.y = Random.Range (0, 360);
		//angles.z = Random.Range (0, 360);
		
		/////////// Spawn off the top of the screen in a random x position:
		transform.position = new Vector3 (0, 0, 1000);
	}
	
	void OnCollisionEnter(Collision col)
	{
		
		GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		Debug.Log ("HIT SOMETHING");
		
		if (GameObject.Find ("player").GetComponent<playercontroller> ().shield = true) {
			GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		} else if (GameObject.Find ("player").GetComponent<playercontroller> ().shield = false) {
			GameObject.Find ("player").GetComponent<playercontroller> ().health -= 25.0f;
		}
	}
	
	
	void Update () {
		////////////////////////////BOOOOOOOST//////////////////////////////
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;



		//////////// Spin the object:
		//angles.x += 20 * Time.deltaTime;
		angles.z += 40 * Time.deltaTime;

		
		//////////// Move the object:
		Vector3 pos = transform.position;
	if (playerHealth >= .1f) {
			transform.rotation = Quaternion.Euler (angles);
			pos.z -= speed * Time.deltaTime;
			transform.position = pos;
		} else {
			Destroy (gameObject);
		}
		//////////// If off the bottom of the screen, destroy this object:
		if (pos.z < -8) Destroy (gameObject);
	}
}
