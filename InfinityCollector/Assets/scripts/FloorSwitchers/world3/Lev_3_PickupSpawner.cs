using UnityEngine;
using System.Collections;

public class Lev_3_PickupSpawner : MonoBehaviour {
	public GameObject fuelPrefab;
	public GameObject shieldPrefab;
	public GameObject resourcePrefab;
    public GameObject ClonedfuelPrefab;
    public GameObject ClonedshieldPrefab;
    public GameObject ClonedresourcePrefab;

    private GameObject chosenPickup;
    private GameObject ClonedchosenPickup;


    private GameObject instaPrefab;
    private GameObject instafarPrefab;
    private GameObject player;
    private float level;

    void Start()
    {
        player = GameObject.Find("player");
        level = player.GetComponent<playercontroller>().level;

    }

    public void SpawnPickup(){
        FindLevel();





		Vector3 pos = transform.position;
		if (chosenPickup != null) {
            Vector3 NewPos = new Vector3(pos.x + Random.Range(0, 30), pos.y + Random.Range(-25, 25), pos.z + Random.Range(-3, 3));
            instaPrefab = Instantiate(chosenPickup, NewPos, Quaternion.identity) as GameObject;

            instafarPrefab = Instantiate(ClonedchosenPickup, Vector3.zero, Quaternion.identity) as GameObject;
            instafarPrefab.transform.parent = instaPrefab.transform;
        }

	}

    /// <summary>
    /// Find what level is being played and run function for Odds of that level
    /// </summary>
    void FindLevel()
    {
        if (level == 1)
        {
            Level1Picks();
        }
        else if (level == 2)
        {
            Level2Picks();
        }
        else if (level == 3)
        {
            Level3Picks();
        }
    }//End find level

    /// <summary>
    /// Level 1 odds
    /// </summary>
    void Level1Picks()
    {
        int Rand = Random.Range(0, 100);

       if ( Rand <= 32)
        {
            chosenPickup = shieldPrefab;
            ClonedchosenPickup = ClonedshieldPrefab;
        }
        else if (Rand >= 33 && Rand <= 65)
        {
            chosenPickup = fuelPrefab;
            ClonedchosenPickup = ClonedfuelPrefab;
        }
        else if (Rand >= 66)
        {
            chosenPickup = resourcePrefab;
            ClonedchosenPickup = ClonedresourcePrefab;
        }
    }
    /// <summary>
    /// Level 2 odds
    /// </summary>
    void Level2Picks()
    {
        Level1Picks();
    }
    /// <summary>
    /// Level 3 odds
    /// </summary>
    void Level3Picks()
    {
        Level1Picks();
    }

}//End Mono
