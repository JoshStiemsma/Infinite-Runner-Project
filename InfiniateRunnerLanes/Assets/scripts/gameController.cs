using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
	
	/// <summary>
	/// The enemy prefab to spawn.
	/// </summary>
	public GameObject enBasicPrefab;
	public GameObject enSpinningPrefab;
	public GameObject enBholePrefab;
	public GameObject enSwipePrefab;
	public GameObject BlocksPrefab;
	
	public GameObject tubePrefab;
	
	public float enBasicDelay;
	public float enSpinDelay;
	public float enBholeDelay;
	public float enSwipeDelay;
	public float BlocksDelay;
	public float tubeDelay; 


	private bool firstFrame = false;
	private float health;




	
	void Start () {
		BlocksDelay = 2f;
		enBasicDelay = .7f;
		enSpinDelay = 25f;
		enBholeDelay = 10f;
		enSwipeDelay = 10f;
		tubeDelay = 10f;

			StartCoroutine ("StartSpawningBasic");
		
			StartCoroutine ("StartSpawningSpin");
		
			StartCoroutine ("StartSpawningbhole");
		
			StartCoroutine ("StartSpawningSwipe");
		
			StartCoroutine ("StartSpawningTube");

		StartCoroutine ("StartSpawningBlocks");
		

	}
	void FixedUpdate(){
		firstFrame = true;
		if (Input.GetButtonDown ("Jump")) {
			BlocksDelay = 1f;
			enBasicDelay = .5f;
			enSpinDelay = 5f;
			enBholeDelay = 2;
			enSwipeDelay = 3f;
			tubeDelay = 5f;
		}
		if (Input.GetButton ("Jump")) {
			BlocksDelay = 1f;
			enBasicDelay = .5f;
			enSpinDelay = 5;
			enBholeDelay = 2;
			enSwipeDelay = 3f;
			tubeDelay = 5f;
		}
		
		if (Input.GetButtonUp("Jump")){
			BlocksDelay = 2f;
			enBasicDelay = .7f;
			enSpinDelay = 25f;
			enBholeDelay = 10f;
			enSwipeDelay = 15f;
			tubeDelay = 10f;
		}

	

	

	}



	void Update() {
		 
		//grab players health from plyer//
		health = GameObject.Find ("player").GetComponent<playercontroller> ().health;
	}
	
	/// <summary>
	/// Spawns an enemy.
	/// </summary>
	/// 
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
	
	
	
	
	
	/// <summary>
	/// A coroutine that spawns enemies every half second.
	/// </summary>


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

