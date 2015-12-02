using UnityEngine;
using System.Collections;

public class Lev_3_ObsticleSpawner : MonoBehaviour
{

    //might spawn random obsticle at center of walls
    public GameObject wallPrefab;
    public GameObject farwallPrefab;

    private GameObject chosenPickup;

    private GameObject instaPrefab;
    private GameObject instafarPrefab;

    /// <summary>
    /// Pick the Spawn Obsticle at roandom possibility and spawn it and its clone as child
    /// </summary>
    public void SpawnObsticle()
    {

        int Rand = Random.Range(0, 100);

        if (Rand <= 33)
        {
            chosenPickup = wallPrefab;

        }
        else if (Rand >= 34 && Rand <= 66)
        {
            chosenPickup = wallPrefab;
        }
        else if (Rand >= 67 && Rand <= 95)
        {
            chosenPickup = wallPrefab;
        }
        else if (Rand >= 96)
        {
            chosenPickup = null;
        }


        Vector3 pos = transform.position;



        if (chosenPickup == wallPrefab)
        {
           instaPrefab  = Instantiate(wallPrefab, new Vector3(pos.x,pos.y,pos.z), Quaternion.Euler(0, 0, 0)) as GameObject;
            instafarPrefab = Instantiate(farwallPrefab, new Vector3(pos.x, pos.y , pos.z+800), Quaternion.Euler(0, 0, 0)) as GameObject;

            instafarPrefab.transform.parent = instaPrefab.transform;
        }
        else if (chosenPickup == wallPrefab)
        {
            instaPrefab = Instantiate(wallPrefab, new Vector3(pos.x, pos.y, pos.z-15), Quaternion.Euler(0, 0, 0)) as GameObject;
            instafarPrefab = Instantiate(farwallPrefab, new Vector3(pos.x, pos.y, pos.z+785), Quaternion.Euler(0, 0, 0)) as GameObject;
            instafarPrefab.transform.parent = instaPrefab.transform;
        }
        else if (chosenPickup != null)
        {
            // Instantiate(chosenPickup, new Vector3(pos.x + Random.Range(0, 80), pos.y + Random.Range(-100, 0), pos.z + Random.Range(-3, 3)), Quaternion.identity);
          //  Instantiate(chosenPickup, pos, Quaternion.identity);
        }



    }
}
