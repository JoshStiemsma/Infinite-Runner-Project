using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {
	private GameObject player;

	private float playerHealth;

	private bool playerAlive = true;
    public Text restart;

    // Use this for initialization
    void Start () {
		player = GameObject.Find ("player");
		playerHealth = player.GetComponent<playercontroller> ().health;
		restart.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = player.GetComponent<playercontroller> ().health;
		if (playerHealth <= 0) {
			restart.text = "Press Enter to Restart!";
			playerAlive = false;
		} else {
			restart.text = "";
		}

	}
}
