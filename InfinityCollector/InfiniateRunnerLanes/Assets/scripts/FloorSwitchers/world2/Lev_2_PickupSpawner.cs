using UnityEngine;
using System.Collections;

public class Lev_2_PickupSpawner : MonoBehaviour {
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
            Vector3 NewPos = new Vector3(pos.x + Random.Range(0, 80), pos.y + Random.Range(-100, 0), pos.z + Random.Range(-3, 3));
            instaPrefab =  Instantiate(chosenPickup,NewPos, Quaternion.identity) as GameObject;

            instafarPrefab = Instantiate(ClonedchosenPickup,  Vector3.zero, Quaternion.identity) as GameObject;
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
    }


    /// <summary>
    /// Level one Odds
    /// </summary>
    void Level1Picks()
    {

        int Rand = Random.Range(0, 100);
        int third = Random.Range(0, 100);
        if (third <= 33)
        {
            if (Rand <= 84)
            {
                // chosenPickup = resourcePrefab;
               // Debug.Log("Added Nothing");
            }
            else if (Rand >= 85 && Rand <= 89)
            {
                chosenPickup = shieldPrefab;
                ClonedchosenPickup = ClonedshieldPrefab;
              //  Debug.Log("Added shield");
            }
            else if (Rand >= 90 && Rand <= 94)
            {
                chosenPickup = fuelPrefab;
                ClonedchosenPickup = ClonedfuelPrefab;
               // Debug.Log("Added fuel");
            }
            else if (Rand >= 95)
            {
                chosenPickup = resourcePrefab;
                ClonedchosenPickup = ClonedresourcePrefab;
              //  Debug.Log("Added resource");
            }
        }//end 1/3 chance of spawning pickup
        else
        {
          //  Debug.Log("Not even gona try");
        }
    }

    /// <summary>
    /// Level 2 Odds
    /// </summary>
    void Level2Picks()
    {
        int Rand = Random.Range(0, 1000);
        int third = Random.Range(0, 100);
        if (Rand <= 829)
        {
            // chosenPickup = resourcePrefab;
            Debug.Log("Added Nothing");
        }
        else if (Rand >= 830 && Rand <= 889)
        {
            chosenPickup = shieldPrefab;
            ClonedchosenPickup = ClonedshieldPrefab;
            Debug.Log("Added shield");
        }
        else if (Rand >= 890 && Rand <= 939)
        {
            chosenPickup = fuelPrefab;
            ClonedchosenPickup = ClonedfuelPrefab;
            Debug.Log("Added fuel");
        }
        else if (Rand >= 940)
        {
            chosenPickup = resourcePrefab;
            ClonedchosenPickup = ClonedresourcePrefab;
            Debug.Log("Added resource");
        }
    }

    /// <summary>
    /// Level 3 Odds
    /// </summary>
    void Level3Picks()
    {
        int Rand = Random.Range(0, 1000);
        int third = Random.Range(0, 100);
       // if (third <= 66)
      //  {
            if (Rand <= 879)
            {
                // chosenPickup = resourcePrefab;
                Debug.Log("Added Nothing");
            }
            else if (Rand >= 880 && Rand <= 919)
            {
                chosenPickup = shieldPrefab;
                ClonedchosenPickup = ClonedshieldPrefab;
                Debug.Log("Added shield");
            }
            else if (Rand >= 920 && Rand <= 959)
            {
                chosenPickup = fuelPrefab;
                ClonedchosenPickup = ClonedfuelPrefab;
                Debug.Log("Added fuel");
            }
            else if (Rand >= 960)
            {
                chosenPickup = resourcePrefab;
                ClonedchosenPickup = ClonedresourcePrefab;
                Debug.Log("Added resource");
            }
       // }//end 1/3 chance of spawning pickup

    }

}
