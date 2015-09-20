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

	public float enBasicDelay;
	public float enSpinDelay;
	public float enBholeDelay;
	public float enSwipeDelay;
	
	
	void Start () {
		enBasicDelay = 3f;
		enSpinDelay = 5f;
		enBholeDelay = 10f;
		enSwipeDelay = 10f;
		
		StartCoroutine ("StartSpawningBasic");


		
		StartCoroutine ("StartSpawningSpin");

		StartCoroutine ("StartSpawningbhole");

		StartCoroutine ("StartSpawningSwipe");
		
	}

	void FixedUpdate(){
	if (Input.GetButtonDown ("Jump")) {
			enBasicDelay = .5f;
			enSpinDelay = 1f;
			enBholeDelay = 2;
			enSwipeDelay = 3f;
		}
	if (Input.GetButton ("Jump")) {
			enBasicDelay = .5f;
			enSpinDelay = 1;
			enBholeDelay = 2;
			enSwipeDelay = 3f;
		}
	
	if (Input.GetButtonUp("Jump")){
			enBasicDelay = 3f;
			enSpinDelay = 5f;
			enBholeDelay = 10f;
			enSwipeDelay = 15f;
			
		}

}
	/// <summary>
	/// Spawns an enemy.
	/// </summary>
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
	
	/// <summary>
	/// A coroutine that spawns enemies every half second.
	/// </summary>
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
	

}
