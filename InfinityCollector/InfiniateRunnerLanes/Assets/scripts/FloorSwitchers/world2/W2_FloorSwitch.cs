using UnityEngine;
using System.Collections;

public class W2_FloorSwitch : MonoBehaviour {
    public GameObject player;
	public Mesh Basic;
	//Public Mesh Bendtunnel;
	public Mesh Hallway;
    public Mesh Door;
    public Mesh Roller;
    public Mesh Roller02;
    public Mesh Roller03;

    private int Rand;
	private Mesh nextMesh;

	public GameObject CopyFloor;

    private float level;
    void Start()
    {
        player = GameObject.Find("player");
       level = player.GetComponent<playercontroller>().level;

    }

    /// <summary>
    /// Level 1 selection range
    /// </summary>
    void Level01Pick()
    {
        Rand = Random.Range(0, 100);
        if (Rand <= 10)
        {
            nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 20 && Rand >= 11)
        {
            nextMesh = Door;
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 30 && Rand >= 21)
        {
            nextMesh = Hallway;
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 52 && Rand >= 49)
        {
            nextMesh = Roller;
        }
        else if (Rand <= 56 && Rand >= 53)
        {
            nextMesh = Roller02;
        }
        else if (Rand <= 60 && Rand >= 57)
        {
            nextMesh = Roller03;
        }
        else
        {
            nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }


    }
    /// <summary>
    /// Level 2 selection range
    /// </summary>
    void Level02Pick()
    {
        Rand = Random.Range(0, 100);
        if (Rand <= 10)
        {
            nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 20 && Rand >= 11)
        {
            nextMesh = Door;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 30 && Rand >= 21)
        {
            nextMesh = Hallway;
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 40 && Rand >= 31)
        {
            nextMesh = Roller;
        }
        else if (Rand <= 50 && Rand >= 41)
        {
            nextMesh = Roller02;
        }
        else if (Rand <= 60 && Rand >= 51)
        {
            nextMesh = Roller03;
        }
        else
        {
            nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }

    }
    /// <summary>
    /// Level 3 selection range
    /// </summary>
    void Level03Pick()
    {
        Rand = Random.Range(0, 100);
        if (Rand <= 10)
        {
            nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 20 && Rand >= 11)
        {
            nextMesh = Door;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 30 && Rand >= 21)
        {
            nextMesh = Hallway;
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 40 && Rand >= 31)
        {
            nextMesh = Roller;
        }
        else if (Rand <= 50 && Rand >= 41)
        {
            nextMesh = Roller02;
        }
        else if (Rand <= 60 && Rand >= 51)
        {
            nextMesh = Roller03;
        }
        else
        {
            nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }

    }





    /// <summary>
    /// Select next level plane Mesh at Random Likelyness and then apply it to object as well as clone of object down field 
    /// Also run the Spawn Pickup Function
    /// </summary>
	public void SwitchMesh(){

        if (level == 1)
        {
            Level01Pick();
        }else if (level == 2)
        {
            Level02Pick();
        }else if (level == 3)
        {
            Level03Pick();
        }

      



		Vector3 scale = transform.localScale;
        //optional to revers left and right of mesh
		///transform.localScale = new Vector3 (scale.x * -1, scale.y, scale.z * -1);
		//Debug.Log("Switch floor of:  " + this.gameObject);
		transform.GetComponent<MeshFilter> ().mesh = nextMesh;
		transform.GetComponent<MeshCollider>().sharedMesh = null;
		transform.GetComponent<MeshCollider> ().sharedMesh = nextMesh;

        CopyFloor.transform.GetComponent<MeshFilter> ().mesh = nextMesh;

		//CopyFloor.transform.localScale = new Vector3 (scale.x * -1, scale.y, scale.z * -1);
	

	}
}
