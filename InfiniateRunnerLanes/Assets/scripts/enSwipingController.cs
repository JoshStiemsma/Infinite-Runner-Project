using UnityEngine;
using System.Collections;

	
	public class enSwipingController : MonoBehaviour {
		
		/// <summary>
		/// The velocity (meters per second) the enemy should move down the screen.
		/// </summary>
		public float speed;
	public float direction = 1;
		/// <summary>
		/// A helper for storing euler angles. We store this to avoid gimbal lock.
		/// </summary>
		Vector3 angles = Vector3.zero;
		
	private float playerHealth;

		void Start () {

		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
			/////////// Random starting angles:
			//angles.x = Random.Range (0, 360);
			//angles.y = Random.Range (0, 360);
			//angles.z = Random.Range (0, 360);
			
			/////////// Spawn off the top of the screen in a random x position:
			
			transform.position = new Vector3 (Random.Range(-40f, 40f), Random.Range(-10f, 20f), 200);
			transform.localScale = new Vector3(Random.Range(5f, 10f)*(transform.position.x/10),Random.Range(5f, 30f),Random.Range(5f, 30f));
		}
		
		void OnCollisionEnter(Collision col)
		{
			
			Debug.Log ("HIT SOMETHING");
			
		}
		
		
		void Update () {
			
			////////////////////////////BOOOOOOOST//////////////////////////////
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
			
			
			
			
			
			
			
			
			
			//////////// Spin the object:
			//angles.x += 20 * Time.deltaTime;
			//angles.z += 40 * Time.deltaTime;
			//transform.rotation = Quaternion.Euler (angles);
			
			//////////// Move the object:
			Vector3 pos = transform.position;


		if (pos.x >= 55) {
			direction = direction*-1;
		}
		if (pos.x <= -55) {
			direction = direction*-1;
		}
		pos.x += direction * speed * Time.deltaTime;


		if (playerHealth >= .1f) {
			pos.z -= speed * Time.deltaTime;
			transform.position = pos;
		}else {
			Destroy (gameObject);
		}
			//////////// If off the bottom of the screen, destroy this object:
			if (pos.z < -8) Destroy (gameObject);
		}
	}
