using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour {
	private GameObject player;
	private float playerHealth;
	private bool shieldOn;
	public float Damage = 25f;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {
		player = GameObject.Find ("player"); 
		shieldOn = player.GetComponent<playercontroller> ().shield;
		playerHealth = player.GetComponent<playercontroller> ().health;
	}

/// <summary>
/// Raises the collision enter event.
/// </summary>
	void OnCollisionEnter(Collision col)
	{
		playerHealth = player.GetComponent<playercontroller> ().health;
		shieldOn = player.GetComponent<playercontroller> ().shield;

		if (col.gameObject.tag == "Player" && shieldOn == false) {	
			player.GetComponent<playercontroller> ().health -= Damage;
			Debug.Log("player hit collision Object - 25 health");
		} else if (col.gameObject.tag == "Player" && shieldOn == true) {
			player.GetComponent<playercontroller> ().shield = false;
		} 
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;
		
	}
}
