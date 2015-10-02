using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
	
	/// <summary>
	/// The enemy prefab to spawn.
	/// </summary>
	//enemies
	public GameObject enBasicPrefab;
	public GameObject enSpinningPrefab;
	public GameObject enBholePrefab;
	public GameObject enSwipePrefab;
	public GameObject BlocksPrefab;
	//exteriors and walls
	public GameObject tubePrefab;
	public GameObject MedHoleWallPrefab;
	//pickups
	public GameObject pickUp01Prefab;
	public GameObject fuelCellPrefab;

	public GameObject shieldPrefab;



	private float enBasicDelay;
	private float enSpinDelay;
	private float enBholeDelay;
	private float enSwipeDelay;
	private float BlocksDelay;

	private float tubeDelay; 
	private float MedHoleWallDelay;

	private float pickUpDelay;
	private float fuelCellDelay;
	private float shieldDelay;


	private bool firstFrame = false;
	private float health;


	//fuel
	private float fuel;

	public float playerHealth;
	private bool playerAlive = true;


	private float delayTimer;


	/// <summary>
	/// /initiations
	/// </summary>
	private bool initBasic;
	private bool initSpin;
	private bool initBhole;
	private bool initSwipe;
	private bool initTube;
	private bool initBlocks;
	private bool initMedHole;
	private bool initPickup;
	private bool initFuelCell;
	private bool initShield;

	void Start () {
	

		delayTimer = 0f;

		initObsticleDelays ();
		StartCoroutines();

		//grab players health from plyer//
		health = GameObject.Find ("player").GetComponent<playercontroller> ().health;

	}
	void FixedUpdate(){
		firstFrame = true;
		if (Input.GetButtonDown ("Jump")&& health >=.1f) {
			initBoostDelays();
		}
		if (Input.GetButton ("Jump")&& health >=.1f) {
			initBoostDelays();

		}
		
		if (Input.GetButtonUp("Jump")&& health >=.1f){
			initObsticleDelays ();
		}

	

	


	

	}



	void Update() {	
		delayTimer = delayTimer + (4 * Time.deltaTime);

		//grab players health from plyer//
		health = GameObject.Find ("player").GetComponent<playercontroller> ().health;
		playerHealth = health;
		if (health <= 0) {
			Debug.Log ("Pause enemies");
			BlocksDelay = 100000f;
			enBasicDelay = 100000f;
			enSpinDelay = 100000f;
			enBholeDelay = 100000f;
			enSwipeDelay = 100000f;
			tubeDelay = 100000f;
			pickUpDelay = 1000000000f;
			fuelCellDelay = 100000000f;
			MedHoleWallDelay = 100000000000f;
			shieldDelay = 100000000000000000000f;
			playerAlive = false;
			//StopAllCoroutines();		
		
		} 
		if (playerAlive = true) {
			initObsticleDelays ();
		}
		if (playerAlive== false) {
			if (health >= .1f && Input.GetButtonDown ("Submit")) {
				Debug.Log ("Resume enemies");
				playerAlive = true;
				initObsticleDelays ();

				//StartCoroutines();
			}
		}

		///////////////////Start SPawning each object after delay only once!

		if (delayTimer >= enBasicDelay && initBasic==false ) {
			StartCoroutine ("StartSpawningBasic");
			initBasic=true;
		}
		
		if (delayTimer >= enSpinDelay && initSpin==false) {
			StartCoroutine ("StartSpawningSpin");
			initSpin=true;
		}
		if (delayTimer >= enBholeDelay && initBhole==false) {
			StartCoroutine ("StartSpawningbhole");
			initBhole=true;
		}
		if (delayTimer >= enSwipeDelay && initSwipe==false) {
			StartCoroutine ("StartSpawningSwipe");
			initSwipe=true;
		}
		if (delayTimer >= tubeDelay && initTube==false) {
			StartCoroutine ("StartSpawningTube");
			initTube=true;
		}
		if (delayTimer >= BlocksDelay && initBlocks==false) {
			StartCoroutine ("StartSpawningBlocks");
			initBlocks=true;
		}
		if (delayTimer >= pickUpDelay && initPickup==false) {
			StartCoroutine ("PickUp01");
			initPickup=true;
		}
		if (delayTimer >= fuelCellDelay && initFuelCell==false) {
			StartCoroutine ("StartSpawningFuelCell");
			initFuelCell=true;
		}
		if (delayTimer >= MedHoleWallDelay && initMedHole==false) {
			StartCoroutine ("StartSpawningMedHoleWall");
			initMedHole=true;
		}
		if (delayTimer >= shieldDelay && initShield==false) {
			StartCoroutine ("StartSpawningShield");
			initShield=true;
		}

	}
	
	/// <summary>
	/// Spawns an enemy.
	/// </summary>
	/// 

	void initObsticleDelays(){
		BlocksDelay = 2f;
		enBasicDelay = .7f;
		enSpinDelay = 25f;
		enBholeDelay = 10f;
		enSwipeDelay = 10f;
		tubeDelay = 10f;
		pickUpDelay = 50;
		fuelCellDelay =25;
		MedHoleWallDelay = 40;
		shieldDelay = 10;
	}

	void initBoostDelays(){
		BlocksDelay = 1f;
		enBasicDelay = .5f;
		enSpinDelay = 5;
		enBholeDelay = 2;
		enSwipeDelay = 3f;
		tubeDelay = 5f;
		pickUpDelay = 50f;
		fuelCellDelay = 15f;
		MedHoleWallDelay = 20f;
		shieldDelay = 10;
	}
	void StartCoroutines(){

	}


	GameObject SpawnSpinningBlocks(){
		return Instantiate (BlocksPrefab);
	}
	GameObject SpawnBasicEnemy(){	
			return Instantiate (enBasicPrefab);		
	}
	GameObject SpawnSpinningEnemy(){
		return Instantiate (enSpinningPrefab);
	}
	GameObject SpawnBholeEnemy(){
		return Instantiate (enBholePrefab);
		
	}
	GameObject SpawnSwipeEnemy(){
		return Instantiate (enSwipePrefab);	
	}

	GameObject SpawnMedHoleWall(){
		return Instantiate (MedHoleWallPrefab);
	}

	GameObject Spawntube() {
		return Instantiate(tubePrefab);
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
	IEnumerator StartSpawningMedHoleWall(){
		while(true){
			SpawnMedHoleWall();
			yield return new WaitForSeconds(MedHoleWallDelay);
		}
	}

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

	IEnumerator StartSpawningBlocks(){
		while(true){
			SpawnSpinningBlocks();
			yield return new WaitForSeconds(BlocksDelay);
		}
	}


	IEnumerator StartSpawningBasic(){

		while(true){
		
			SpawnBasicEnemy();
			yield return new WaitForSeconds(enBasicDelay);
			
		}
	}
	
	
	
	
	
	IEnumerator StartSpawningSpin(){
		while(true){
			SpawnSpinningEnemy();
			yield return new WaitForSeconds(enSpinDelay);
		}
	}
	
	
	
	
	IEnumerator StartSpawningbhole(){
		while(true){
			SpawnBholeEnemy();
			yield return new WaitForSeconds(enBholeDelay);
		}
	}
	
	IEnumerator StartSpawningSwipe(){
		while(true){
			SpawnSwipeEnemy();
			yield return new WaitForSeconds(enSwipeDelay);
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
	
}

