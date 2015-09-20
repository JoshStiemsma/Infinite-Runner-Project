using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
	
	/// <summary>
	/// The enemy prefab to spawn.
	/// </summary>
	public GameObject enBasicPrefab;
	public GameObject enSpinningPrefab;
	public GameObject enBholePrefab;


	public float enBasicDelay = 10f;
	public float enSpinDelay = 30f;
	public float enBholeDelay = 60f;
	
	void Start () {
		StartCoroutine ("StartSpawningBasic");

		StartCoroutine ("StartSpawningSpin");

		StartCoroutine ("StartSpawningbhole");
		
	}

	void FixedUpdate(){
	if (Input.GetButtonDown ("Jump")) {
			enBasicDelay = enBasicDelay/2;
			enSpinDelay = enSpinDelay/2;
			enBholeDelay = enBholeDelay/2;
	}
	if (Input.GetButton ("Jump")) {
			enBasicDelay = enBasicDelay/2;
			enSpinDelay = enSpinDelay/2;
			enBholeDelay = enBholeDelay/2;
		}
	
	if (Input.GetButtonUp("Jump")){
			enBasicDelay = enBasicDelay*2;
			enSpinDelay = enSpinDelay*2;
			enBholeDelay = enBholeDelay*2;
			
		}

}
	/// <summary>
	/// Spawns an enemy.
	/// </summary>
	GameObject SpawnBasicEnemy(){
		return Instantiate (enBasicPrefab);
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




	GameObject SpawnSpinningEnemy(){
		return Instantiate (enSpinningPrefab);
	}
	IEnumerator StartSpawningSpin(){
		while(true){
			SpawnSpinningEnemy();
			yield return new WaitForSeconds(enSpinDelay);
		}
	}
	


	GameObject SpawnBholeEnemy(){
		return Instantiate (enBholePrefab);
	}
	IEnumerator StartSpawningbhole(){
		while(true){
			SpawnBholeEnemy();
			yield return new WaitForSeconds(enBholeDelay);
		}
	}
	



}
