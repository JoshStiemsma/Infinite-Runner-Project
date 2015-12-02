using UnityEngine;
using System.Collections;

public class PresetObsticle : MonoBehaviour {
	private GameObject player;
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;
	public bool renewable;
	private bool gotHit;
	private bool shieldOn;
	//Vector3 scales = Vector3.zero;
	
	
	
	void Start () {
		player = GameObject.Find ("player");
		health = player.GetComponent<playercontroller> ().health;
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		shieldOn = player.GetComponent<playercontroller> ().shield;
		if (health <= 0f) {
			Destroy(gameObject);
			
		} else {
			speed = player.GetComponent<playercontroller> ().forwardSpeed;
			/////////// Random starting angles:
			
//			scales.x = Random.Range (1f, 100f);
//			scales.y = Random.Range (1f, 100f);
//			scales.z = Random.Range (1f, 100f);
			
			/////////// Spawn off the top of the screen in a random x position:
			
			//transform.position = new Vector3 (0, 0, 2000);
			//transform.localScale = scales;
		}
		
		
		
	}

	
	
	void Update () {
		
		health = player.GetComponent<playercontroller> ().health;
		////////////////////////////BOOOOOOOST//////////////////////////////
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		shieldOn = player.GetComponent<playercontroller> ().shield;
		//////////// Move the object:
		Vector3 pos = transform.position;
		pos.z -= speed * Time.deltaTime;
		
		if (health >= .1f) {
			transform.position = pos;
		} else {//if health is under 0
			transform.position = transform.position;
			
			
			
		}
	
		
		if (pos.z < -8) {
			if(renewable==false){
			Destroy(gameObject);
			} else{
				transform.position= new Vector3(pos.x, pos.y, 5000f);
			}
		}
	}
	void OnCollisionEnter(Collision col)
	{
		
		if (gotHit == false) {
			if (col.gameObject.tag == "Player" && shieldOn == false) {	
				player.GetComponent<playercontroller> ().health -= 25.0f;
			} else if (col.gameObject.tag == "Player" && shieldOn == true) {
				player.GetComponent<playercontroller> ().shield = false;

			} 

			gotHit=true;	
		}
	}	

}
