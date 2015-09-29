using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	public Text Health;
	private float playerHealth;

	public Text Fuel;
	public float playerFuel;



	public Text restart;
	private bool playerAlive = true;


	public Text Pickups;
	public float pickUpCount;


	// Use this for initialization
	void Start () {
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		pickUpCount =  GameObject.Find ("player").GetComponent<playercontroller> ().pickUpCount;
		playerFuel = GameObject.Find ("player").GetComponent<playercontroller> ().fuel;

		Health.text = "Health:" + playerHealth.ToString();
		Pickups.text = "Pickups:" + pickUpCount.ToString ();	
		Fuel.text = "Fuel:" + playerFuel.ToString ("F1") + "/100";
		restart.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		pickUpCount =  GameObject.Find ("player").GetComponent<playercontroller> ().pickUpCount;
		playerFuel = GameObject.Find ("player").GetComponent<playercontroller> ().fuel;
		Health.text = "Health:"  + playerHealth.ToString();
		Pickups.text = "Pickups:" + pickUpCount.ToString();
		Fuel.text = "Fuel:" + playerFuel.ToString ("F1") + "/100";
			


		if (playerHealth <= 0) {
			restart.text = "Press Enter to Restart!";
			playerAlive = false;




		} else {

			restart.text = "";

		}




	}
}
