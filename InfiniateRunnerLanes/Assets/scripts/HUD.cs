using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {
	public Text Health;
	private float playerHealth;

	public Text Score;

	public float playerScore;
	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find ("player").GetComponent<playercontroller> ().health;

		Health.text = "Health:" + playerHealth.ToString();

		playerScore = 0;

		Score.text = "Score:" + playerScore.ToString ("F1");
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = GameObject.Find ("player").GetComponent<playercontroller> ().health;
		Health.text = "Health:"  + playerHealth.ToString();

	
			playerScore = playerScore+1*Time.deltaTime;
		Score.text = "Score:" + playerScore.ToString ("F1");
	}
}
