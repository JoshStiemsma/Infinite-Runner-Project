using UnityEngine;
using System.Collections;

public class Lev_2_ObsticleSpawner : MonoBehaviour
{
    private GameObject player;
    public float level;

    //might spawn random obsticle at center of walls
    public GameObject FanPrefab;
    public GameObject farFanPrefab;
    public GameObject lFanPrefab;
    public GameObject lfarFanPrefab;
    public GameObject rFanPrefab;
    public GameObject rfarFanPrefab;


    public GameObject HolePrefab;
    public GameObject farHolePrefab;

	public GameObject CubePrefab;
	public GameObject farCubePrefab;

	public GameObject SweepPrefab;
	public GameObject farSweepPrefab;

	


    private GameObject chosenPickup;

    private GameObject instaPrefab;
    private GameObject instafarPrefab;

    void Start()
    {
        player = GameObject.Find("player");
        level = player.transform.GetComponent<playercontroller>().level;

    }


    /// <summary>
    /// Level 1 object spawn Odds
    /// </summary>
    void Level01()
    {
        int Rand = Random.Range(0, 100);
        if (Rand <= 25)
        {
            chosenPickup = CubePrefab;
        }
        else if (Rand >= 26 && Rand <= 50)
        {
            chosenPickup = SweepPrefab;
            //chosenPickup = HolePrefab;
        }
        else if (Rand >= 51 && Rand <= 60)
        {
            int bRand = Random.Range(0, 30);
            if (bRand <= 10)
            {
                chosenPickup = rFanPrefab;
            }
            else if (bRand >= 20)
            {
                chosenPickup = lFanPrefab;
            }
            else
            {
                chosenPickup = FanPrefab;
            }
        }
        else if (Rand >= 61)
        {
            chosenPickup = null;
        }
    }//End level01

    /// <summary>
    /// Level 2 object spawn Odds
    /// </summary>
    void Level02()
    {
        int Rand = Random.Range(0, 100);
        if (Rand <= 40)
        {
            chosenPickup = CubePrefab;
        }
        else if (Rand >= 41 && Rand <= 80)
        {
            chosenPickup = SweepPrefab;
            //chosenPickup = HolePrefab;
        }
        else if (Rand >= 81)
        {
            int bRand = Random.Range(0, 30);
            if (bRand <= 10)
            {
                chosenPickup = rFanPrefab;
            }
            else if (bRand >= 20)
            {
                chosenPickup = lFanPrefab;
            }
            else
            {
                chosenPickup = FanPrefab;
            }
        }

    }//end Level02

    /// <summary>
    /// Level 3 object spawn Odds
    /// </summary>
    void Level03()
    {
        int Rand = Random.Range(0, 100);
        if (Rand <= 40)
        {
            chosenPickup = CubePrefab;
        }
        else if (Rand >= 41 && Rand <= 80)
        {
            chosenPickup = SweepPrefab;
            //chosenPickup = HolePrefab;
        }
        else if (Rand >= 81)
        {
            int bRand = Random.Range(0, 30);
            if (bRand <= 10)
            {
                chosenPickup = rFanPrefab;
            }
            else if (bRand >= 20)
            {
                chosenPickup = lFanPrefab;
            }
            else
            {
                chosenPickup = FanPrefab;
            }
        }
    }//End level03


    /// <summary>
    /// Pick the Spawn Obsticle at roandom possibility and spawn it and its clone as child
    /// </summary>
    public void SpawnObsticle()
    {
        //pick what will be spawned
        if (level == 1) {
            Level01(); } else if (level == 2) {
            Level02(); } else if (level == 3) {
            Level03();
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
            instaPrefab = Instantiate(FanPrefab, new Vector3(pos.x+50, pos.y - 50, pos.z-15), Quaternion.Euler(0, 90, 0)) as GameObject;
            instafarPrefab = Instantiate(farFanPrefab, new Vector3(pos.x+50, pos.y - 50, pos.z+785), Quaternion.Euler(0, 90, 0)) as GameObject;
            instafarPrefab.transform.parent = instaPrefab.transform;
        }
        else if (chosenPickup == lFanPrefab)
        {
            instaPrefab = Instantiate(lFanPrefab, new Vector3(pos.x + 50, pos.y - 50, pos.z - 15), Quaternion.Euler(0, 0, 0)) as GameObject;
            instafarPrefab = Instantiate(lfarFanPrefab, new Vector3(pos.x + 50, pos.y - 50, pos.z + 785), Quaternion.Euler(0, 0, 0)) as GameObject;
            instafarPrefab.transform.parent = instaPrefab.transform;
        }
        else if (chosenPickup == rFanPrefab)
        {
            instaPrefab = Instantiate(rFanPrefab, new Vector3(pos.x + 50, pos.y - 50, pos.z - 15), Quaternion.Euler(0, 0, 0)) as GameObject;
            instafarPrefab = Instantiate(rfarFanPrefab, new Vector3(pos.x + 50, pos.y - 50, pos.z + 785), Quaternion.Euler(0, 0, 0)) as GameObject;
            instafarPrefab.transform.parent = instaPrefab.transform;
        }
        else if (chosenPickup == CubePrefab)
		{
			Vector3 startPos= new Vector3(pos.x+Random.Range(0,100), pos.y+Random.Range(-110,-10) , pos.z-50);
			instaPrefab = Instantiate(CubePrefab, startPos, Quaternion.Euler(0, 0, 0)) as GameObject;
			instafarPrefab = Instantiate(farCubePrefab, new Vector3(startPos.x, startPos.y, startPos.z + 750), Quaternion.Euler(0, 0, 0)) as GameObject;
			instafarPrefab.transform.parent = instaPrefab.transform;

            if (level == 3)
            {
                 startPos = new Vector3(pos.x + Random.Range(0,100), pos.y + Random.Range(-110, -10), pos.z - 50);
                instaPrefab = Instantiate(CubePrefab, startPos, Quaternion.Euler(0, 0, 0)) as GameObject;
                instafarPrefab = Instantiate(farCubePrefab, new Vector3(startPos.x, startPos.y, startPos.z + 750), Quaternion.Euler(0, 0, 0)) as GameObject;
                instafarPrefab.transform.parent = instaPrefab.transform;
            }

		}
		else if (chosenPickup == SweepPrefab)
		{
			Vector3 startPos= new Vector3(pos.x+Random.Range(-20,20), pos.y+Random.Range(-70,-30) , pos.z-50);
			instaPrefab = Instantiate(SweepPrefab, startPos , Quaternion.Euler(0, 0, 0)) as GameObject;
			instafarPrefab = Instantiate(farSweepPrefab, new Vector3(startPos.x, startPos.y, startPos.z+750), Quaternion.Euler(0, 0, 0)) as GameObject;
			instafarPrefab.transform.parent = instaPrefab.transform;

            if (level == 3)
            {
                startPos = new Vector3(pos.x + Random.Range(-20, 20), pos.y + Random.Range(-70, -30), pos.z - 50);
                instaPrefab = Instantiate(SweepPrefab, startPos, Quaternion.Euler(0, 0, 0)) as GameObject;
                instafarPrefab = Instantiate(farSweepPrefab, new Vector3(startPos.x, startPos.y, startPos.z + 750), Quaternion.Euler(0, 0, 0)) as GameObject;
                instafarPrefab.transform.parent = instaPrefab.transform;

            }
		}
		else if (chosenPickup != null)
		{
            // Instantiate(chosenPickup, new Vector3(pos.x + Random.Range(0, 80), pos.y + Random.Range(-100, 0), pos.z + Random.Range(-3, 3)), Quaternion.identity);
          //  Instantiate(chosenPickup, pos, Quaternion.identity);
        }



    }
}
