using UnityEngine;
using System.Collections;

public class Lev_2_PickupSpawner : MonoBehaviour {
	public GameObject fuelPrefab;
	public GameObject shieldPrefab;
	public GameObject resourcePrefab;
	private GameObject chosenPickup;



	public void SpawnPickup(){

		int Rand = Random.Range(0,100);

		if (Rand <= 67) {
			chosenPickup=null;

		} else if (Rand >= 68 && Rand <= 81) {
			chosenPickup = shieldPrefab;
		}else if (Rand >=82 && Rand <= 95) {
			chosenPickup = fuelPrefab;
		}else if (Rand >= 96) {
			chosenPickup = resourcePrefab;
		} 


		Vector3 pos = transform.position;
		if (chosenPickup != null) {
			Instantiate (chosenPickup, new Vector3 (pos.x + Random.Range (0, 80), pos.y + Random.Range(-100, 0), pos.z + Random.Range (-3, 3)), Quaternion.identity);
		}

	}
}
