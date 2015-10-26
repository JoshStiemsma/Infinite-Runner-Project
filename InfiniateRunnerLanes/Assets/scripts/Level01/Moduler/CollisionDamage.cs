using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour {
	private float playerHealth;
	private bool shieldOn;
	public float Damage;

	void Start() {
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
	}


	void OnCollisionEnter(Collision col)
	{
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;

		if (col.gameObject.tag == "Player" && shieldOn == false) {	
			GameObject.Find ("player").GetComponent<playercontroller> ().health -= Damage;
			Debug.Log("player hit collision Object - 25 health");
		} else if (col.gameObject.tag == "Player" && shieldOn == true) {
			GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		} 
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		
	}
}
