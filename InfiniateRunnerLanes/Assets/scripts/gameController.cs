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
	//exteriors
	public GameObject tubePrefab;
	//pickups
	public GameObject pickUp01Prefab;




	public float enBasicDelay;
	public float enSpinDelay;
	public float enBholeDelay;
	public float enSwipeDelay;
	public float BlocksDelay;
	public float tubeDelay; 
	public float pickUpDelay;

	private bool firstFrame = false;
	private float health;

	public float playerHealth;
	private bool playerAlive = true;

	
	void Start () {

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
			playerAlive = false;
			StopAllCoroutines();
		
		
		} 
		if (playerAlive== false) {
			if (health >= .1f && Input.GetButtonDown ("Submit")) {
				Debug.Log ("Resume enemies");
				initObsticleDelays ();
				playerAlive = true;
				StartCoroutines();
			}
		}
	}
	
	/// <summary>
	/// Spawns an enemy.
	/// </summary>
	/// 
	void StartCoroutines(){
		StartCoroutine ("StartSpawningBasic");	
		StartCoroutine ("StartSpawningSpin");			
		StartCoroutine ("StartSpawningbhole");		
		StartCoroutine ("StartSpawningSwipe");		
		StartCoroutine ("StartSpawningTube");		
		StartCoroutine ("StartSpawningBlocks");
		StartCoroutine ("PickUp01");
		
	}
	void initObsticleDelays(){
		BlocksDelay = 2f;
		enBasicDelay = .7f;
		enSpinDelay = 25f;
		enBholeDelay = 10f;
		enSwipeDelay = 10f;
		tubeDelay = 10f;
		pickUpDelay = 25;
	}

	void initBoostDelays(){
		BlocksDelay = 1f;
		enBasicDelay = .5f;
		enSpinDelay = 5;
		enBholeDelay = 2;
		enSwipeDelay = 3f;
		tubeDelay = 5f;
		pickUpDelay = 15f;
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
	GameObject Spawntube() {
		return Instantiate(tubePrefab);
	}
	GameObject SpawnPickUp01() {
		return Instantiate (pickUp01Prefab);
	}
	
	
	
	
	
	/// <summary>
	/// A coroutine that spawns enemies every half second.
	/// </summary>
	IEnumerator PickUp01(){
		while(true){
			SpawnPickUp01();
			yield return new WaitForSeconds(pickUpDelay);
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

