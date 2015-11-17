using UnityEngine;
using System.Collections;

public class L01_W01GameController : MonoBehaviour {

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



	/// <summary>
	/// The asteroid prefab.
	/// </summary>
	public GameObject AsteroidPrefab;
	private float asteroidDelay;
	private bool initAsteroid;
	/// <summary>
	/// The cross asteroid prefab.
	/// </summary>
	public GameObject CrossAsteroidPrefab;
	private float CrossAsteroidDelay;
	private bool initCrossAsteroid;
	private float crossAstCount;

	/// <summary>
	/// The tube prefab.
	/// </summary>
	public GameObject tubePrefab;
	private float tubeDelay; 
	private bool initTube;

	/// <summary>
	/// The gas cloud prefab.
	///</summary>
	public GameObject gasCloudPrefab;
	private float gasCloudDelay;
	private bool initGasCloud;




	/// <summary>
	/// The pick up01 prefab.
	/// </summary>
	public GameObject pickUp01Prefab;
	private float pickUpDelay;
	private bool initPickup;
	private float pickupCount;

	/// <summary>
	/// The fuel cell prefab.
	/// </summary>
	public GameObject fuelCellPrefab;
	private float fuelCellDelay;
	private bool initFuelCell;

	/// <summary>
	/// The shield prefab.
	/// </summary>
	public GameObject shieldPrefab;
	private float shieldDelay;
	private bool initShield;


	public float enemyCount;//REALLY OBSTICALES 

	private float delayTimer;//Maim Delay Timer//


	private float pause = 1000000000000000000000000000000000.0f;


	private float Rand;


	void Start () {
		player = GameObject.Find ("player");
		player.GetComponent<playercontroller> ().level = 1f;
		delayTimer = 0f;
		initObsticleDelays ();
		health = player.GetComponent<playercontroller> ().health;
		pickupCount = player.GetComponent<playercontroller> ().pickUpCount;
		StartCoroutine(PauseCoroutine());  
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
			initBoostDelays();
			inBoost=true;
		}
		if (Input.GetButtonUp("Jump")&& health >=.1f && inBoost==true){
			undoBoostDelays ();
			inBoost=false;
		}
		UpdateDelays ();
	}



	void Update() {	
	
		delayTimer = delayTimer + (4 * Time.deltaTime);

		health = player.GetComponent<playercontroller> ().health;
		pickupCount = player.GetComponent<playercontroller> ().pickUpCount;
		playerHealth = health;

		if (health <= 0) {
			//level 1//
			asteroidDelay = pause;
			tubeDelay = pause;
			gasCloudDelay = pause;
			CrossAsteroidDelay = pause;
			pickUpDelay = pause;
			fuelCellDelay = pause;
			shieldDelay = pause;

			playerAlive = false;
			inBoost = false;
		}

		if (playerAlive== false) {
			initObsticleDelays ();
			if (health>=.1f && Input.GetButtonDown ("Submit")) {
				Debug.Log ("Resume enemies");
				delayTimer = 0f;
				playerAlive = true;
			}
		}
		if (pickupCount <= 0) {

			///Continue playing
		} else {
			endTime = Time.deltaTime;
			if(PlayerData.playerData.levelReached<=0){
				PlayerData.playerData.levelReached = 1;
			}
			
			PlayerData.playerData.Save();
			gameWon=true;
			Time.timeScale = 0;
			player.GetComponent<playercontroller> ().gameWon = true;

			//Change Save Data To level first complete

		}
		///////////////////Start SPawning each object after delay only once!

				if (delayTimer >= asteroidDelay && initAsteroid == false) {
					StartCoroutine ("StartSpawningAsteroid");
					asteroidDelay = asteroidDelay/2;
					initAsteroid = true;
				}
				if (delayTimer >= gasCloudDelay && initGasCloud == false) {
					StartCoroutine ("StartSpawningGasCloud");
					initGasCloud = true;
				}
				if (delayTimer >= tubeDelay && initTube == false) {
					StartCoroutine ("StartSpawningTube");
					initTube = true;
				}

		if (delayTimer >= pickUpDelay && initPickup == false) {
			StartCoroutine ("PickUp01");
			initPickup = true;
		}
		if (delayTimer >= fuelCellDelay && initFuelCell == false) {
			StartCoroutine ("StartSpawningFuelCell");
			initFuelCell = true;
		}
		
		if (delayTimer >= shieldDelay && initShield == false) {
			StartCoroutine ("StartSpawningShield");
			initShield = true;
		}


	}
	


	void initObsticleDelays(){
		Debug.Log ("Init");
		asteroidDelay = FirstWorldTimers.FirstLevel.asteroidDelay;
		tubeDelay = FirstWorldTimers.FirstLevel.tubeDelay;
		gasCloudDelay = FirstWorldTimers.FirstLevel.gasCloudDelay;
		CrossAsteroidDelay = FirstWorldTimers.FirstLevel.CrossAsteroidDelay;
		
		pickUpDelay = FirstWorldTimers.FirstLevel.pickUpDelay;
		fuelCellDelay =FirstWorldTimers.FirstLevel.fuelCellDelay;
		shieldDelay = FirstWorldTimers.FirstLevel.shieldDelay;

	}



	void UpdateDelays(){//increase spawn rate as time goes on
	
		asteroidDelay = asteroidDelay	-(Time.deltaTime/100f);
		tubeDelay = tubeDelay	-(Time.deltaTime/100f);
		gasCloudDelay = gasCloudDelay	-(Time.deltaTime/100f);
		CrossAsteroidDelay = CrossAsteroidDelay	-(Time.deltaTime/100f);

		pickUpDelay = pickUpDelay	-(Time.deltaTime/100f);
		fuelCellDelay =fuelCellDelay	-(Time.deltaTime/100f);
		shieldDelay = shieldDelay	-(Time.deltaTime/100f);	
	}
	void undoBoostDelays(){	

		asteroidDelay = asteroidDelay*2;
		tubeDelay = tubeDelay*2;
		gasCloudDelay = gasCloudDelay*2;
		CrossAsteroidDelay = CrossAsteroidDelay*2;


		pickUpDelay = pickUpDelay*2;
		fuelCellDelay =fuelCellDelay*4;
		shieldDelay = shieldDelay*2;
	}


	void initBoostDelays(){

		asteroidDelay = asteroidDelay/2;
		tubeDelay = tubeDelay/2;
		gasCloudDelay = gasCloudDelay/2;
		CrossAsteroidDelay = CrossAsteroidDelay/2;


		pickUpDelay = pickUpDelay/2;
		fuelCellDelay =fuelCellDelay/4;
		shieldDelay = shieldDelay/2;

	}
//	void StartCoroutines(){
//
//	}


	//level 1//
	GameObject SpawnAsteroid(){	
		Rand = Random.Range(0,4);
		if (Rand <= 3f) {
			return Instantiate (AsteroidPrefab);
			Debug.Log("Spawn one asteroid");
		} else if (Rand <= 3.4f && Rand >= 3.1f) {
			Debug.Log("Spawn two asteroid");
			 Instantiate (AsteroidPrefab);
			return Instantiate (AsteroidPrefab);
		
		}else {
			return Instantiate (AsteroidPrefab);
			
		}

			
		//enemyCount++;
	}
	GameObject SpawnCrossAsteroid(){	
		return Instantiate (CrossAsteroidPrefab);		
	}

	GameObject Spawntube() {
		return Instantiate(tubePrefab);
	}
	GameObject SpawnGasCloud() {
		return Instantiate (gasCloudPrefab);
	}






	GameObject SpawnPickUp01() {
		return Instantiate (pickUp01Prefab);
	}
	GameObject SpawnFuelCells() {
		return Instantiate (fuelCellPrefab);
	}
	GameObject SpawnShield() {
		return Instantiate (shieldPrefab);
	}


	
	
	
	
	/// <summary>
	/// A coroutine that spawns enemies every half second.
	/// </summary>
	//level 1//
	IEnumerator StartSpawningAsteroid(){
		while(true){		
			SpawnAsteroid();
			enemyCount++;
			yield return new WaitForSeconds(asteroidDelay);			
		}
	}
	IEnumerator StartSpawningCrossAsteroid(){		
		while(true){			
			StartCoroutine ("SpawnMultCrossAsteroids");
			yield return new WaitForSeconds(CrossAsteroidDelay);			
		}
	}
	IEnumerator SpawnMultCrossAsteroids(){		
		while (true) {
			if (crossAstCount <= 20) {
				SpawnCrossAsteroid ();
				crossAstCount++;
			} else {
				StopCoroutine ("SpawnMultCrossAsteroids");
				crossAstCount = 0;
			}
			yield return new WaitForSeconds (.5f);			
		}
	}
	IEnumerator StartSpawningTube()
	{
		while (true)
		{
			Spawntube();
			yield return new WaitForSeconds(tubeDelay);
		}
	}
	IEnumerator StartSpawningGasCloud()
	{
		while (true)
		{
			SpawnGasCloud();
			yield return new WaitForSeconds(gasCloudDelay);
		}
	}







	//all//
	IEnumerator PickUp01(){
		while(true){
			SpawnPickUp01();
			yield return new WaitForSeconds(pickUpDelay);
		}
	}
	
	IEnumerator StartSpawningFuelCell(){
		while(true){
			SpawnFuelCells();
			yield return new WaitForSeconds(fuelCellDelay);
		}
	}
	IEnumerator StartSpawningShield(){
		while(true){
			SpawnShield();
			yield return new WaitForSeconds(shieldDelay);
		}
	}
}

