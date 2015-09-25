using UnityEngine;
using System.Collections;

public class enBasicController : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	/// <summary>
	/// A helper for storing euler angles. We store this to avoid gimbal lock.
	/// </summary>
	Vector3 angles = Vector3.zero;
	Vector3 scales = Vector3.zero;
	
	void Start () {
		speed = 25f;
		/////////// Random starting angles:
		angles.x = Random.Range (0, 360);
		angles.y = Random.Range (0, 360);
		angles.z = Random.Range (0, 360);
		
		scales.x = Random.Range(75f, 250f);
		scales.y = Random.Range(75f, 250f);
		scales.z = Random.Range(75f, 250f);
		
		/////////// Spawn off the top of the screen in a random x position:
		
		transform.position = new Vector3 (Random.Range(-50f, 50f), Random.Range(-40f, 40f), 600);
		transform.localScale = scales;

		GameObject thePlayer = GameObject.Find("player");
		playercontroller playercontroller = thePlayer.GetComponent<playercontroller>();




	}
	
	void OnCollisionEnter(Collision col)
	{
		
		Debug.Log ("HIT SOMETHING");
		GameObject.Find("player").GetComponent<playercontroller>().health -= 25.0f;;
	}
	
	
	void Update () {
		
		////////////////////////////BOOOOOOOST//////////////////////////////
		if (Input.GetButtonDown ("Jump")) {
			speed = 250f;
		}
		if (Input.GetButton ("Jump")) {
			speed = 250f;
		}
		
		
		if (Input.GetButtonUp("Jump")){
			speed = 25f;
		}
		
		
		
		
		
		
		
		
		
		//////////// Spin the object:
		angles.x += 20 * Time.deltaTime;
		angles.z += 40 * Time.deltaTime;
		transform.rotation = Quaternion.Euler (angles);
		
		//////////// Move the object:
		Vector3 pos = transform.position;
		pos.z -= speed * Time.deltaTime;
		transform.position = pos;
		
		//////////// If off the bottom of the screen, destroy this object:
		if (pos.z < -8) Destroy (gameObject);
	}
}
