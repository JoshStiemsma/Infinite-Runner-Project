using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
	
	/// <summary>
	/// The enemy prefab to spawn.
	/// </summary>
	public GameObject enBasicPrefab;
	public GameObject enSpinningPrefab;
	public GameObject enBholePrefab;

	public float enBasicDelay;
	public float enSpinDelay;
	public float enBholeDelay;
	
	
	void Start () {
		enBasicDelay = 3f;
		enSpinDelay = 5f;
		enBholeDelay = 10f;

		StartCoroutine ("StartSpawningBasic");

		StartCoroutine ("StartSpawningSpin");

		StartCoroutine ("StartSpawningbhole");



	}

	void FixedUpdate(){
	if (Input.GetButtonDown ("Jump")) {
			enBasicDelay = 1f;
			enSpinDelay = 2f;
			enBholeDelay = 3;
	}
	if (Input.GetButton ("Jump")) {
			enBasicDelay = 1f;
			enSpinDelay = 2;
			enBholeDelay = 3;
		}
	
	if (Input.GetButtonUp("Jump")){
			enBasicDelay = 3f;
			enSpinDelay = 5f;
			enBholeDelay = 10f;
			
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
	



}
