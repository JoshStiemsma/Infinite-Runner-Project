using UnityEngine;
using System.Collections;

public class L03_W02GameController : MonoBehaviour {

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
		player.GetComponent<playercontroller> ().level = 3f;
		
	}

	void Start () {
		Debug.Log ("Start Second Level");
		delayTimer = 0f;
		initObsticleDelays ();
		health = player.GetComponent<playercontroller> ().health;
		pickupCount = player.GetComponent<playercontroller> ().pickUpCount;
		StartCoroutine(PauseCoroutine());  
		Update ();
		Time.timeScale = 1;
	}

	/// <summary>
	/// Pauses the coroutine.
	/// </summary>
	/// <returns>The coroutine.</returns>
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


	/// <summary>
	/// Update this instance.
	/// </summary>
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
			
			///Edit Per Level*************///
			if(PlayerData.playerData.levelReached<=4){
				PlayerData.playerData.levelReached = 5;
			}
			
			PlayerData.playerData.Save();
			gameWon=true;
			Time.timeScale = 0;
			player.GetComponent<playercontroller> ().gameWon = true;
			endTime = Time.deltaTime;

		}
		///////////////////Start SPawning each object after delay only once!

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
		if (delayTimer >= FanDelay && initFan == false) {
			StartCoroutine ("StartSpawningFans");
			initFan = true;
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
		LightDelay = SecondWorldTimers.ThirdLevel.LightDelay;
		BlocksDelay=SecondWorldTimers.ThirdLevel.BlocksDelay;
		enSpinDelay=SecondWorldTimers.ThirdLevel.enSpinDelay;
		enSwipeDelay = SecondWorldTimers.ThirdLevel.enSwipeDelay;
		MedHoleWallDelay = SecondWorldTimers.ThirdLevel.MedHoleWallDelay;
		BeamDelay = SecondWorldTimers.ThirdLevel.BeamDelay;
		FanDelay = SecondWorldTimers.ThirdLevel.FanDelay;
		pickUpDelay = SecondWorldTimers.ThirdLevel.pickUpDelay;
		fuelCellDelay = SecondWorldTimers.ThirdLevel.fuelCellDelay;
		shieldDelay = SecondWorldTimers.ThirdLevel.shieldDelay;
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

	/// <summary>
	/// Spawns the pick up01.
	/// </summary>
	/// <returns>The pick up01.</returns>
	GameObject SpawnPickUp01() {
		return Instantiate (pickUp01Prefab);
	}
	/// <summary>
	/// Spawns the fuel cells.
	/// </summary>
	/// <returns>The fuel cells.</returns>
	GameObject SpawnFuelCells() {
		return Instantiate (fuelCellPrefab);
	}
	/// <summary>
	/// Spawns the shield.
	/// </summary>
	/// <returns>The shield.</returns>
	GameObject SpawnShield() {
		return Instantiate (shieldPrefab);
	}

	/// <summary>
	/// Spawns the spinning enemy.
	/// </summary>
	/// <returns>The spinning enemy.</returns>
	GameObject SpawnSpinningEnemy(){
		return Instantiate (enSpinningPrefab);
	}
	/// <summary>
	/// Spawns the swipe enemy.
	/// </summary>
	/// <returns>The swipe enemy.</returns>
	GameObject SpawnSwipeEnemy(){
		return Instantiate (enSwipePrefab);	
	}
	/// <summary>
	/// Spawns the spinning blocks.
	/// </summary>
	/// <returns>The spinning blocks.</returns>
	GameObject SpawnSpinningBlocks(){
		return Instantiate (BlocksPrefab);
	}
	/// <summary>
	/// Spawns the med hole wall.
	/// </summary>
	/// <returns>The med hole wall.</returns>
	GameObject SpawnMedHoleWall(){
		return Instantiate (MedHoleWallPrefab);
	}
	/// <summary>
	/// Spawns the fan.
	/// </summary>
	/// <returns>The fan.</returns>
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
	
	/// <summary>
	/// Starts the spawning spin.
	/// </summary>
	/// <returns>The spawning spin.</returns>
	IEnumerator StartSpawningSpin(){
		while(true){
			SpawnSpinningEnemy();
			yield return new WaitForSeconds(enSpinDelay);
		}
	}

	/// <summary>
	/// Starts the spawning swipe.
	/// </summary>
	/// <returns>The spawning swipe.</returns>
	IEnumerator StartSpawningSwipe(){
		while(true){
			SpawnSwipeEnemy();
			yield return new WaitForSeconds(enSwipeDelay);
		}
	}	
	/// <summary>
	/// Starts the spawning blocks.
	/// </summary>
	/// <returns>The spawning blocks.</returns>
	IEnumerator StartSpawningBlocks(){
		while(true){
			SpawnSpinningBlocks();
			yield return new WaitForSeconds(BlocksDelay);
		}
	}
	/// <summary>
	/// Starts the spawning med hole wall.
	/// </summary>
	/// <returns>The spawning med hole wall.</returns>
	IEnumerator StartSpawningMedHoleWall(){
		while(true){
			SpawnMedHoleWall();
			yield return new WaitForSeconds(MedHoleWallDelay);
		}
	}
	/// <summary>
	/// Starts the spawning fans.
	/// </summary>
	/// <returns>The spawning fans.</returns>
	IEnumerator StartSpawningFans(){
		while(true){
			SpawnFan();
			yield return new WaitForSeconds(FanDelay);
		}
	}




	//all//
	/// <summary>
	/// Picks the up01.
	/// </summary>
	/// <returns>The up01.</returns>
	IEnumerator PickUp01(){
		while(true){
			SpawnPickUp01();
			yield return new WaitForSeconds(pickUpDelay);
		}
	}
	/// <summary>
	/// Starts the spawning fuel cell.
	/// </summary>
	/// <returns>The spawning fuel cell.</returns>
	IEnumerator StartSpawningFuelCell(){
		while(true){
			SpawnFuelCells();
			yield return new WaitForSeconds(fuelCellDelay);
		}
	}
	/// <summary>
	/// Starts the spawning shield.
	/// </summary>
	/// <returns>The spawning shield.</returns>
	IEnumerator StartSpawningShield(){
		while(true){
			SpawnShield();
			yield return new WaitForSeconds(shieldDelay);
		}
	}
}

