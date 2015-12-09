using UnityEngine;
using System.Collections;

public class Lev_3_ObsticleSpawner : MonoBehaviour
{

    //might spawn random obsticle at center of walls
    public GameObject Rock;
    public GameObject farRock;

    public GameObject RockWall;
    public GameObject farRockWall;

    private GameObject chosenPickup;

    private GameObject instaPrefab;
    private GameObject instafarPrefab;

    public int floor;

    /// <summary>
    /// Pick the Spawn Obsticle at roandom possibility and spawn it and its clone as child
    /// </summary>
    public void SpawnObsticle()
    {

        int Rand = Random.Range(0, 100);

        if (Rand <= 33)
        {
            chosenPickup = Rock;

        }
        else if (Rand >= 34 && Rand <= 66)
        {
            chosenPickup = Rock;
        }
        else if (Rand >= 67 && Rand <= 95)
        {
            chosenPickup = RockWall;
        }
        else if (Rand >= 96)
        {
            chosenPickup = null;
        }


        Vector3 pos = transform.position;



        if (chosenPickup == Rock)
        {
                Debug.Log("insta rock at" + pos);
                instaPrefab = Instantiate(Rock, new Vector3(pos.x, pos.y+70, pos.z), Quaternion.Euler(0, 0, 0)) as GameObject;           
                instafarPrefab = Instantiate(farRock, new Vector3(pos.x, pos.y + 70, pos.z + 800), Quaternion.Euler(0, 0, 0)) as GameObject;
                instafarPrefab.transform.parent = instaPrefab.transform;
        }else if (chosenPickup == RockWall)
        {
            Debug.Log("insta rock at" + pos);
            instaPrefab = Instantiate(RockWall, new Vector3(pos.x, pos.y + 70, pos.z), Quaternion.Euler(0, 0, 0)) as GameObject;
            instafarPrefab = Instantiate(farRockWall, new Vector3(pos.x, pos.y + 70, pos.z + 800), Quaternion.Euler(0, 0, 0)) as GameObject;
            instafarPrefab.transform.parent = instaPrefab.transform;
        }

        else if (chosenPickup != null)
        {
            // Instantiate(chosenPickup, new Vector3(pos.x + Random.Range(0, 80), pos.y + Random.Range(-100, 0), pos.z + Random.Range(-3, 3)), Quaternion.identity);
          //  Instantiate(chosenPickup, pos, Quaternion.identity);
        }



    }
}
