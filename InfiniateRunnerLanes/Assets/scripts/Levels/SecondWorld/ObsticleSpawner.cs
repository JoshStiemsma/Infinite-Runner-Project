using UnityEngine;
using System.Collections;

public class ObsticleSpawner : MonoBehaviour
{

    //might spawn random obsticle at center of walls
    public GameObject FanPrefab;
    public GameObject farFanPrefab;
    public GameObject HolePrefab;
    public GameObject farHolePrefab;
    private GameObject chosenPickup;

    private GameObject instaPrefab;
    private GameObject instafarPrefab;
    public void SpawnObsticle()
    {

        int Rand = Random.Range(0, 100);

        if (Rand <= 33)
        {
            chosenPickup = HolePrefab;

        }
        else if (Rand >= 34 && Rand <= 66)
        {
            chosenPickup = HolePrefab;
        }
        else if (Rand >= 67 && Rand <= 95)
        {
            chosenPickup = FanPrefab;
        }
        else if (Rand >= 96)
        {
            chosenPickup = null;
        }


        Vector3 pos = transform.position;
        if (chosenPickup == HolePrefab)
        {
           instaPrefab= Instantiate(HolePrefab, new Vector3(pos.x,pos.y-50f,pos.z), Quaternion.Euler(0, 90, 0)) as GameObject;
            instafarPrefab = Instantiate(farHolePrefab, new Vector3(pos.x, pos.y - 50f, pos.z+800), Quaternion.Euler(0, 90, 0)) as GameObject;

            instafarPrefab.transform.parent = instaPrefab.transform;
        }
        else if (chosenPickup == FanPrefab)
        {
            instaPrefab = Instantiate(FanPrefab, new Vector3(pos.x, pos.y - 50, pos.z-15), Quaternion.Euler(0, 90, 0)) as GameObject;
            instafarPrefab = Instantiate(farFanPrefab, new Vector3(pos.x, pos.y - 50, pos.z+785), Quaternion.Euler(0, 90, 0)) as GameObject;
            instafarPrefab.transform.parent = instaPrefab.transform;
        }
        else if (chosenPickup != null)
        {
            // Instantiate(chosenPickup, new Vector3(pos.x + Random.Range(0, 80), pos.y + Random.Range(-100, 0), pos.z + Random.Range(-3, 3)), Quaternion.identity);
          //  Instantiate(chosenPickup, pos, Quaternion.identity);
        }



    }
}
