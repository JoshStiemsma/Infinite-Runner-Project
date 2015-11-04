using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {
	private float playerHealth;

	void Start() {

		playerHealth = GameObject.Find ("player").GetComponent<playercontroller> ().health;
	}


	void OnCollisionEnter(Collision col)
	{
	
		if (col.gameObject.tag == "Bullet") {	
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "player") {	
			playerHealth = 0;
		}
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		
	}
}
