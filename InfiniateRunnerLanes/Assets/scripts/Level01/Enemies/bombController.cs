using UnityEngine;
using System.Collections;

public class bombController : MonoBehaviour {
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;
	public bool shieldOn;

	private bool gotHit;

	private bool yellow;
	private bool white;

	private Vector3 scale;

	private bool up;
	private bool right;
	private float spacer;

	public GameObject FuelPrefab;

	void Start () {
	
		scale = transform.localScale;
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		//Debug.Log ("Enemies:" + enemyCount);
		if (health <= 0f) {
			Destroy(gameObject);
			
		} else {
			speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;;		
			/////////// Spawn off the top of the screen in a random x position:


			//transform.position = new Vector3 (Random.Range (-38f, 38f), Random.Range (-40f, 40f), 1000);
		}
		
		Invoke("colorWhite", 1f);
		flipUp ();
		Invoke("flipRight", .25f);
		
	}
	
	void OnCollisionEnter(Collision col){
		if (gotHit == false) {
			if (col.gameObject.tag == "Player" && shieldOn == false) {	
				GameObject.Find ("player").GetComponent<playercontroller> ().health -= 25.0f;
			} else if (col.gameObject.tag == "Player" && shieldOn == true) {
				GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
			} 
			if (col.gameObject.tag == "Bullet") {
				Debug.Log ("Hit");
				Instantiate ( FuelPrefab , transform.position, Quaternion.identity);
				destroy ();
			}
			gotHit=true;
		}
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;

	}
	void destroy(){
		Debug.Log ("DESTROY");
		Destroy (this.gameObject);
		Destroy (gameObject);
	}
	
	void Update () {
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		scale = transform.localScale;
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;


		//////////// Move the object:
		Vector3 pos = transform.position;	
		///SPiral effect///////
		spacer = spacer * (Time.deltaTime*2);
		if (right) {
			pos.x = pos.x + speed / 20 * Time.deltaTime+ spacer;
		} else {
			pos.x = pos.x - speed / 20 * Time.deltaTime- spacer;
		}


		if (up) {
			pos.y = pos.y + speed / 20 * Time.deltaTime+ spacer;
		} else {
			pos.y = pos.y - speed / 20 * Time.deltaTime - spacer; 
		}


		pos.z -= speed/3 * Time.deltaTime;

		if(health >= .1f){
			transform.position = pos;

		} else{//if health is under 0
			transform.position = transform.position;//do nothing	
		}

		
		if (pos.z <= 20) { 
			if (scale.x < 15) {
				transform.localScale = new Vector3 (30, 30, 30);
				GetComponent<Renderer> ().material.SetColor ("_Color", Color.red);
			}
			if (scale.x > 15) {
				transform.localScale = new Vector3 (14, 14, 14);
				GetComponent<Renderer> ().material.SetColor ("_Color", Color.yellow);
			}
			Debug.Log ("EXPLOSION");		
		}

		if (pos.z <= -5) { 
			Destroy(gameObject);	
		}
		
	}
	void colorWhite() {
		GetComponent<Renderer> ().material.SetColor ("_Color", Color.white);
		Debug.Log ("White");
		Invoke("colorYellow", .3f);
	}
	void colorYellow() {
		GetComponent<Renderer> ().material.SetColor ("_Color", Color.yellow);
		Debug.Log ("yellow");
		Invoke("colorWhite", .3f);
	}
	void flipUp(){
		up = !up;
		Invoke("flipUp", .5f);
	}
	void flipRight(){
		right = !right;
		Invoke("flipRight", .5f);
	}

}

