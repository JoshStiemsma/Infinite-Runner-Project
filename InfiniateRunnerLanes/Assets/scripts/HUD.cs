using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {
	public Text Health;
	private float playerHealth;

	public Text Score;
	public float playerScore;


	public Text restart;
	private bool playerAlive = true;
	private float finalScore;

	public Text Pickups;
	public float pickUpCount;


	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		pickUpCount =  GameObject.Find ("player").GetComponent<playercontroller> ().pickUpCount;

		playerScore = 0;
		Health.text = "Health:" + playerHealth.ToString();
		Pickups.text = "Pickups:" + pickUpCount.ToString ();	
		Score.text = "Score:" + playerScore.ToString ("F1");
		restart.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		pickUpCount =  GameObject.Find ("player").GetComponent<playercontroller> ().pickUpCount;
		Health.text = "Health:"  + playerHealth.ToString();
		Pickups.text = "Pickups:" + pickUpCount.ToString();
	
			


		if (playerHealth <= 0) {
			restart.text = "Press Enter to Restart!";
			playerAlive = false;
			finalScore = playerScore;
			Score.text = "Score:" + finalScore.ToString ("F1");


		} else {
			playerScore = playerScore+1*Time.deltaTime;
			restart.text = "";
			Score.text = "Score:" + playerScore.ToString ("F1");
		}




	}
}
