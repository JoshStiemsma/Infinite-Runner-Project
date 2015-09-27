using UnityEngine;
using System.Collections;

public class enBholeController : MonoBehaviour {

	private float playerHealth;
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float scale;
	/// <summary>
	/// A helper for storing euler angles. We store this to avoid gimbal lock.
	/// </summary>
	Vector3 angles = Vector3.zero;
    Vector3 scales = Vector3.zero;

    void Start () {
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;;
		speed = 25f;
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
		
		Debug.Log ("HIT SOMETHING");
		GameObject.Find("player").GetComponent<playercontroller>().health -= 100f;;
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
