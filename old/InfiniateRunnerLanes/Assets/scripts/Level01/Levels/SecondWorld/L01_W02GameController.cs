using UnityEngine;
using System.Collections;

public class L01_W02GameController : MonoBehaviour {

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

	public GameObject enSpinningPrefab;
	public GameObject enSwipePrefab;
	public GameObject BlocksPrefab;
	public GameObject fanLeftPrefab;
	public GameObject fanRightPrefab;
	public GameObject fanUpPrefab;
	public GameObject fanDownPrefab;
	//exteriors and walls
	public GameObject MedHoleWallPrefab;

	private float enSpinDelay;
	private float enSwipeDelay;
	private float BlocksDelay;
	private float BeamDelay;
	private float MedHoleWallDelay;
	private float LightDelay;
	private float FanDelay;

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

	private bool initSpin;
	private bool initSwipe;
	private bool initBlocks;
	private bool initMedHole;
	private bool initLight;
	private bool initBeam;
	private bool initFan;

	public float enemyCount;//REALLY OBSTICALES 

	private float delayTimer;//Maim Delay Timer//


	private float pause = 1000000000000000000000000000000000.0f;


	private float Rand;

	void Awake(){
		player = GameObject.Find ("player");
		player.GetComponent<playercontroller> ().level = 1f;

	}
	void Start () {
		Debug.Log ("Start Second Level");

		///Edit per Level***********///
		delayTimer = 0f;
		initObsticleDelays ();
		health = player.GetComponent<playercontroller> ().health;
		pickupCount = player.GetComponent<playercontroller> ().pickUpCount;
		StartCoroutine(PauseCoroutine());  
		Update ();
		Time.timeScale = 1;
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
			LightDelay = pause;
			BlocksDelay = pause;
			enSpinDelay = pause;
			enSwipeDelay = pause;
			MedHoleWallDelay = pause;
			BeamDelay = pause;
			FanDelay = pause;
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
		if (pickupCount <= 2) {

			///Continue playing
		} else {
			endTime = Time.deltaTime;
			
			///Edit Per Level*************///
			if(PlayerData.playerData.levelReached<=3){
				PlayerData.playerData.levelReached = 4;
			}
			
			PlayerData.playerData.Save();
			gameWon=true;
			Time.timeScale = 0;
			player.GetComponent<playercontroller> ().gameWon = true;


		}
		///////////////////Start SPawning each object after delay only once!


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
	

	/// <summary>
	/// Inits the obsticle delays.
	/// </summary>
	void initObsticleDelays(){
		LightDelay = SecondWorldTimers.FirstLevel.LightDelay;
		BlocksDelay=SecondWorldTimers.FirstLevel.BlocksDelay;
		enSpinDelay=SecondWorldTimers.FirstLevel.enSpinDelay;
		enSwipeDelay = SecondWorldTimers.FirstLevel.enSwipeDelay;
		MedHoleWallDelay = SecondWorldTimers.FirstLevel.MedHoleWallDelay;
		BeamDelay = SecondWorldTimers.FirstLevel.BeamDelay;
		FanDelay = SecondWorldTimers.FirstLevel.FanDelay;
		pickUpDelay = SecondWorldTimers.FirstLevel.pickUpDelay;
		fuelCellDelay = SecondWorldTimers.FirstLevel.fuelCellDelay;
		shieldDelay = SecondWorldTimers.FirstLevel.shieldDelay;
	}


/// <summary>
/// Updates the delays.
/// </summary>
	void UpdateDelays(){//increase spawn rate as time goes on
		LightDelay = LightDelay	-(Time.deltaTime/100f);
		BlocksDelay = BlocksDelay	-(Time.deltaTime/100f);
		enSpinDelay = enSpinDelay	-(Time.deltaTime/100f);
		enSwipeDelay = enSwipeDelay	-(Time.deltaTime/100f);
		MedHoleWallDelay = MedHoleWallDelay	-(Time.deltaTime/100f);
		BeamDelay = BeamDelay	-(Time.deltaTime/100f);
		FanDelay = FanDelay	-(Time.deltaTime/100f);

		pickUpDelay = pickUpDelay	-(Time.deltaTime/100f);
		fuelCellDelay =fuelCellDelay	-(Time.deltaTime/100f);
		shieldDelay = shieldDelay	-(Time.deltaTime/100f);	
	}
	/// <summary>
	/// Undos the boost delays.
	/// </summary>
	void undoBoostDelays(){	

		LightDelay = LightDelay*2;
		BlocksDelay = BlocksDelay*2;
		enSpinDelay = enSpinDelay*2;
		enSwipeDelay = enSwipeDelay*2;
		MedHoleWallDelay = MedHoleWallDelay*2;
		BeamDelay = BeamDelay*2;
		FanDelay = FanDelay * 2;

		pickUpDelay = pickUpDelay*2;
		fuelCellDelay =fuelCellDelay*4;
		shieldDelay = shieldDelay*2;
	}

	/// <summary>
	/// Inits the boost delays. 
	/// </summary>
	void initBoostDelays(){

		LightDelay = LightDelay/2;
		BlocksDelay = BlocksDelay/2;
		enSpinDelay = enSpinDelay/2;
		enSwipeDelay = enSwipeDelay/2;
		MedHoleWallDelay = MedHoleWallDelay/2;
		BeamDelay = BeamDelay/2;
		FanDelay = FanDelay / 2;

		pickUpDelay = pickUpDelay/2;
		fuelCellDelay =fuelCellDelay/4;
		shieldDelay = shieldDelay/2;

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
	GameObject SpawnFan(){
		Rand = Random.Range(0,4);
		if (Rand <= .9f) {
			return Instantiate (fanLeftPrefab);
		} else if (Rand <= 1.9f && Rand >= 1f) {
			return Instantiate (fanUpPrefab);
		} else if (Rand <= 2.9f && Rand >= 2f) {
			return Instantiate (fanRightPrefab);
		} else if (Rand <= 4f && Rand >= 3f) {
			return Instantiate (fanDownPrefab);
		}else {
			return Instantiate (fanLeftPrefab);
			
		}
	}
	
	
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
	IEnumerator StartSpawningFans(){
		while(true){
			SpawnFan();
			yield return new WaitForSeconds(FanDelay);
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

