using UnityEngine;
using System.Collections;

public class OnCollisionDestroy : MonoBehaviour {
	private float playerHealth;
	private bool shieldOn;

	void Start() {
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
	}


	void OnCollisionEnter(Collision col)
	{
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		shieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;

		if (col.gameObject.tag == "Player" && shieldOn == false) {	
			GameObject.Find ("player").GetComponent<playercontroller> ().health -= 25.0f;
			Debug.Log("player hit collision Object - 25 health");
		} else if (col.gameObject.tag == "Player" && shieldOn == true) {
			GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		} 
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		
	}
}
