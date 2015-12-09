using UnityEngine;
using System.Collections;

public class L02_W02GameController : MonoBehaviour {

	public bool gameWon;
	public float endTime;
	/// <summary>
	/// The player.
	/// </summary>
	private GameObject player;
	private float health;
	public float playerHealth;
	private bool playerAlive = true;
	private bool inBoost;
	private float fuel;


	public GameObject Floor;

	private float pickupCount;

	public float enemyCount;//REALLY OBSTICALES 

	private float delayTimer;//Maim Delay Timer//


	private float pause = 1000000000000000000000000000000000.0f;


	private float Rand;



	void Start () {
		player = GameObject.Find ("player");
		player.GetComponent<playercontroller> ().level = 2f;
        player.GetComponent<playercontroller>().world = 2;
        delayTimer = 0f;

		health = player.GetComponent<playercontroller> ().health;
		pickupCount = player.GetComponent<playercontroller> ().pickUpCount;

	}

	IEnumerator PauseCoroutine() {
		while (true)
		{
			if (Input.GetKeyDown(KeyCode.P))
			{
				if (Time.timeScale == 0)
				{
					Time.timeScale = 1;
					player.GetComponent<AudioSource>().volume = player.GetComponent<AudioSource>().volume/.75f;
					player.GetComponent<AudioSource>().pitch = player.GetComponent<AudioSource>().pitch*2;
					player.GetComponent<playercontroller>().paused=false;
				} else {
					Time.timeScale = 0;
					player.GetComponent<AudioSource>().volume = player.GetComponent<AudioSource>().volume*.75f;
					player.GetComponent<AudioSource>().pitch = player.GetComponent<AudioSource>().pitch/2;
			
					player.GetComponent<playercontroller>().paused=true;
				}
			}    
			yield return null;    
		}
	}

	void FixedUpdate(){
		//firstFrame = true;
		if (Input.GetButtonDown ("Jump")&& health >=.1f && inBoost==false) {
			inBoost=true;
		}
		if (Input.GetButtonUp("Jump")&& health >=.1f && inBoost==true){
			inBoost=false;
		}

	}



	void Update() {	
	
		delayTimer = delayTimer + (4 * Time.deltaTime);

		health = player.GetComponent<playercontroller> ().health;
		pickupCount = player.GetComponent<playercontroller> ().pickUpCount;
		playerHealth = health;

		if (health <= 0) {

			playerAlive = false;
			inBoost = false;
		}

		if (playerAlive == false) {
            if (health >= .1f && Input.GetButtonDown("Submit"))
            {
                Debug.Log("Resume enemies");
                delayTimer = 0f;
                playerAlive = true;
            }
        }



		if (pickupCount <= 3) {

			///Continue playing
		} else {
			endTime = Time.deltaTime;
			if (PlayerData.playerData.levelReached <= 5) {
				PlayerData.playerData.levelReached = 6;
			}
			
			PlayerData.playerData.Save ();
			gameWon = true;
			Time.timeScale = 0;
			player.GetComponent<playercontroller> ().gameWon = true;

			//Change Save Data To level first complete

		}

	}





}

