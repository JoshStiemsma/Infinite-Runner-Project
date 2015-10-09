using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
	public float enemyCount;
	/// <summary>
	/// The Onsticle prefab to spawn.
	/// </summary>
	//Obsticle
	//level 1//
	public GameObject AsteroidPrefab;
	public GameObject enBholePrefab;
	public GameObject CrossAsteroidPrefab;

	public GameObject enemyShipPrefab;

	public GameObject tubePrefab;
	public GameObject gasCloudPrefab;

	//level 2//
	public GameObject enSpinningPrefab;
	public GameObject enSwipePrefab;
	public GameObject BlocksPrefab;
	//exteriors and walls
	public GameObject MedHoleWallPrefab;

	//pickups
	public GameObject pickUp01Prefab;
	public GameObject fuelCellPrefab;
	public GameObject shieldPrefab;


	/// ///////////	DELAYSSSS/// 
		private float delayTimer;//Maim Delay Timer//
	/// level 1///
	private float asteroidDelay;
	private float enBholeDelay;
	private float CrossAsteroidDelay;
	private float enemyShipDelay;
	private float tubeDelay; 
	private float gasCloudDelay;

	//level 2//
	private float enSpinDelay;
	private float enSwipeDelay;
	private float BlocksDelay;
	private float BeamDelay;
	private float MedHoleWallDelay;
	private float LightDelay;

	//pickups//
	private float pickUpDelay;
	private float fuelCellDelay;
	private float shieldDelay;


	private float pause = 1000000000000000000000000000000000.0f;
	//private bool firstFrame = false;
	private float health;

	//fuel
	private float fuel;
	public float playerHealth;
	private bool playerAlive = true;
	private bool inBoost;



	/// <summary>
	/// /initiations
	/// </summary>
	private bool initAsteroid;
	private bool initTube;
	private bool initBhole;
	private bool initGasCloud;
	private bool initCrossAsteroid;
	private float crossAstCount;
	private bool initEnemyShip;

	private bool initSpin;
	private bool initSwipe;
	private bool initBlocks;
	private bool initMedHole;
	private bool initLight;
	private bool initBeam;

	private bool initPickup;
	private bool initFuelCell;
	private bool initShield;


	public int level;

	void Start () {
		delayTimer = 0f;
		initObsticleDelays ();
		health = GameObject.Find ("player").GetComponent<playercontroller> ().health;
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
				} else {
					Time.timeScale = 0;
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
		//Debug.Log ("Enemies:" + enemyCount);
		delayTimer = delayTimer + (4 * Time.deltaTime);
		//Debug.Log (asteroidDelay);
		//grab players health from plyer//
		health = GameObject.Find ("player").GetComponent<playercontroller> ().health;
		playerHealth = health;
		if (health <= 0) {
			Debug.Log ("Pause enemies");
			//level 1//
			asteroidDelay = pause;
			enBholeDelay = pause;
			enemyShipDelay = pause;
			tubeDelay = pause;
			gasCloudDelay = pause;
			CrossAsteroidDelay = pause;
			//level 2//
			LightDelay = pause;
			BlocksDelay = pause;
			enSpinDelay = pause;
			enSwipeDelay = pause;
			MedHoleWallDelay = pause;
			BeamDelay = pause;
			//all//
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

		///////////////////Start SPawning each object after delay only once!
		/// 		//////////////Level 1 Start Coroutines//////
			if (level == 1) {

			if (delayTimer >= asteroidDelay && initAsteroid == false) {
				StartCoroutine ("StartSpawningAsteroid");
				initAsteroid = true;
			}

			if (delayTimer >= enemyShipDelay && initEnemyShip == false) {
				StartCoroutine ("StartSpawningEnemyShip");
				initEnemyShip = true;
			}
			if (delayTimer >= CrossAsteroidDelay && initCrossAsteroid == false) {
				StartCoroutine ("StartSpawningCrossAsteroid");
				initCrossAsteroid = true;
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
			if (delayTimer >= enBholeDelay && initBhole==false) {
				StartCoroutine ("StartSpawningbhole");
				initBhole=true;
			}
			if (delayTimer >= shieldDelay && initShield == false) {
				StartCoroutine ("StartSpawningShield");
				initShield = true;
			}
			if (delayTimer >= gasCloudDelay && initGasCloud == false) {
				StartCoroutine ("StartSpawningGasCloud");
				initGasCloud = true;
			}

		}
		//////////////Level 2 Start Coroutines//////
		if (level == 2) {
			if (delayTimer >= MedHoleWallDelay && initMedHole==false) {
				StartCoroutine ("StartSpawningMedHoleWall");
				initMedHole=true;
			}
			if (delayTimer >= enSpinDelay && initSpin == false) {
				StartCoroutine ("StartSpawningSpin");
				initSpin = true;
			}
			if (delayTimer >= enSwipeDelay && initSwipe == false) {
				StartCoroutine ("StartSpawningSwipe");
				initSwipe = true;
			}
	
			if (delayTimer >= BlocksDelay && initBlocks == false) {
				StartCoroutine ("StartSpawningBlocks");
				initBlocks = true;
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
	}
	


	void initObsticleDelays(){
		//level 1//
		Debug.Log ("Initiate Delays");

		asteroidDelay = 2.5f;

		enBholeDelay = 15f;
		enemyShipDelay = 45f; //150
		tubeDelay = 10f;
		gasCloudDelay = 250f;
		CrossAsteroidDelay = 100f;
		//level 2//
		LightDelay = 2f;
		BlocksDelay = 4f;
		enSpinDelay = 25f;
		enSwipeDelay = 10f;
		MedHoleWallDelay = 40f;
		BeamDelay = 2f;

		pickUpDelay = 300;
		fuelCellDelay =50;
		shieldDelay = 175;
	}



	void UpdateDelays(){
		//level 1//
		asteroidDelay = asteroidDelay	-(Time.deltaTime/100f);
		enemyShipDelay = enemyShipDelay	-(Time.deltaTime/100f);
		enBholeDelay = enBholeDelay	-(Time.deltaTime/100f);
		tubeDelay = tubeDelay	-(Time.deltaTime/100f);
		gasCloudDelay = gasCloudDelay	-(Time.deltaTime/100f);
		CrossAsteroidDelay = CrossAsteroidDelay	-(Time.deltaTime/100f);
		//level 2//
		LightDelay = LightDelay	-(Time.deltaTime/100f);
		BlocksDelay = BlocksDelay	-(Time.deltaTime/100f);
		enSpinDelay = enSpinDelay	-(Time.deltaTime/100f);
		enSwipeDelay = enSwipeDelay	-(Time.deltaTime/100f);
		MedHoleWallDelay = MedHoleWallDelay	-(Time.deltaTime/100f);
		BeamDelay = BeamDelay	-(Time.deltaTime/100f);
		
		pickUpDelay = pickUpDelay	-(Time.deltaTime/100f);
		fuelCellDelay =fuelCellDelay	-(Time.deltaTime/100f);
		shieldDelay = shieldDelay	-(Time.deltaTime/100f);	
	}
	void undoBoostDelays(){	
		//level 1//
		asteroidDelay = asteroidDelay*2;

		enBholeDelay = enBholeDelay*2;
		enemyShipDelay = enemyShipDelay * 2;
		tubeDelay = tubeDelay*2;
		gasCloudDelay = gasCloudDelay*2;
		CrossAsteroidDelay = CrossAsteroidDelay*2;
		//level 2//
		LightDelay = LightDelay*2;
		BlocksDelay = BlocksDelay*2;
		enSpinDelay = enSpinDelay*2;
		enSwipeDelay = enSwipeDelay*2;
		MedHoleWallDelay = MedHoleWallDelay*2;
		BeamDelay = BeamDelay*2;
		
		pickUpDelay = pickUpDelay*2;
		fuelCellDelay =fuelCellDelay*4;
		shieldDelay = shieldDelay*2;
	}


	void initBoostDelays(){
		//level 1//
		asteroidDelay = asteroidDelay/2;
		enBholeDelay = enBholeDelay/2;
		enemyShipDelay = enemyShipDelay / 2;
		tubeDelay = tubeDelay/2;
		gasCloudDelay = gasCloudDelay/2;
		CrossAsteroidDelay = CrossAsteroidDelay/2;
		//level 2//
		LightDelay = LightDelay/2;
		BlocksDelay = BlocksDelay/2;
		enSpinDelay = enSpinDelay/2;
		enSwipeDelay = enSwipeDelay/2;
		MedHoleWallDelay = MedHoleWallDelay/2;
		BeamDelay = BeamDelay/2;
		
		pickUpDelay = pickUpDelay/2;
		fuelCellDelay =fuelCellDelay/4;
		shieldDelay = shieldDelay/2;

	}
//	void StartCoroutines(){
//
//	}


	//level 1//
	GameObject SpawnAsteroid(){	
			return Instantiate (AsteroidPrefab);
		//enemyCount++;
	}
	GameObject SpawnCrossAsteroid(){	
		return Instantiate (CrossAsteroidPrefab);		
	}
	GameObject SpawnEnemyShip(){	
		return Instantiate (enemyShipPrefab);		
	}
	GameObject SpawnBholeEnemy(){
		return Instantiate (enBholePrefab);	
	}
	GameObject Spawntube() {
		return Instantiate(tubePrefab);
	}
	GameObject SpawnGasCloud() {
		return Instantiate (gasCloudPrefab);
	}

	//level 2//
	GameObject SpawnSpinningEnemy(){
		return Instantiate (enSpinningPrefab);
	}
	GameObject SpawnSwipeEnemy(){
		return Instantiate (enSwipePrefab);	
	}
	GameObject SpawnSpinningBlocks(){
		return Instantiate (BlocksPrefab);
	}
	GameObject SpawnMedHoleWall(){
		return Instantiate (MedHoleWallPrefab);
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
		while(true){
			if(crossAstCount<=20){
			SpawnCrossAsteroid();
				crossAstCount++;
			}else {
				StopCoroutine("SpawnMultCrossAsteroids");
				crossAstCount=0;
			}
			yield return new WaitForSeconds(.5f);			
		}
	}
	IEnumerator StartSpawningEnemyShip(){		
		while(true){			
			SpawnEnemyShip();
			yield return new WaitForSeconds(enemyShipDelay);			
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
	IEnumerator StartSpawningbhole(){
		while(true){
			SpawnBholeEnemy();
			yield return new WaitForSeconds(enBholeDelay);
		}
	}


	//level 2//
	IEnumerator StartSpawningSpin(){
		while(true){
			SpawnSpinningEnemy();
			yield return new WaitForSeconds(enSpinDelay);
		}
	}
	IEnumerator StartSpawningSwipe(){
		while(true){
			SpawnSwipeEnemy();
			yield return new WaitForSeconds(enSwipeDelay);
		}
	}	IEnumerator StartSpawningBlocks(){
		while(true){
			SpawnSpinningBlocks();
			yield return new WaitForSeconds(BlocksDelay);
		}
	}
	IEnumerator StartSpawningMedHoleWall(){
		while(true){
			SpawnMedHoleWall();
			yield return new WaitForSeconds(MedHoleWallDelay);
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

