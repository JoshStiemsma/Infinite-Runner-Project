using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	private float playerHealth;
	public Text restart;
	private bool playerAlive = true;


	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		restart.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;

		if (playerHealth <= 0) {
			restart.text = "Press Enter to Restart!";
			playerAlive = false;
		} else {
			restart.text = "";
		}

	}
}
