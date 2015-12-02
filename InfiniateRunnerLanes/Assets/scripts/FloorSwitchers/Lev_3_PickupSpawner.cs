using UnityEngine;
using System.Collections;

public class Lev_3_PickupSpawner : MonoBehaviour {
	public GameObject fuelPrefab;
	public GameObject shieldPrefab;
	public GameObject resourcePrefab;
	private GameObject chosenPickup;



	public void SpawnPickup(){

		int Rand = Random.Range(0,100);

		if (Rand <= 10) {
			//chosenPickup=null;
			chosenPickup = shieldPrefab;
		} else if (Rand >= 11 && Rand <= 40) {
			chosenPickup = shieldPrefab;
		}else if (Rand >=41 && Rand <= 75) {
			chosenPickup = fuelPrefab;
		}else if (Rand >= 76) {
			chosenPickup = resourcePrefab;
		} 


		Vector3 pos = transform.position;
		if (chosenPickup != null) {
			Instantiate (chosenPickup, new Vector3 (pos.x + Random.Range (-50, 50), pos.y + Random.Range(-10, 20), pos.z + Random.Range (-3, 3)), Quaternion.identity);
		}

	}
}
