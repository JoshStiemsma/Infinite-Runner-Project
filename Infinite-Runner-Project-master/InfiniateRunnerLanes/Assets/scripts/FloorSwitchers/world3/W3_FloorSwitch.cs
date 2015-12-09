using UnityEngine;
using System.Collections;

public class W3_FloorSwitch : MonoBehaviour
{
    public Mesh HalfTunnel;
    //Public Mesh Bendtunnel;
    public Mesh ArchSpikeFloor;
    public Mesh tunnelFloor;
    public Mesh bumpFloor;
    public Mesh DropFloor;
    public Mesh fissureFloor;
    public Mesh SpikeFloor;
    public Mesh TightFloor;
    public Mesh CurveFloor;
    public Mesh NormalValley;

    private int Rand;
    private Mesh nextMesh;

    public GameObject CopyFloor;

    private GameObject player;
    private float level;
    void Start()
    {
        player = GameObject.Find("player");
        level = player.GetComponent<playercontroller>().level;

    }

    /// <summary>
    /// Select next level plane Mesh at Random Likelyness and then apply it to object as well as clone of object down field 
    /// SpawnObsticle Function if capable
    /// Spawn Pickup Function if capable
    /// </summary>
    public void SwitchMesh()
    {
      


        if (level == 1)
        {
            Level01Pick();
        }
        else if (level == 2)
        {
            Level02Pick();
        }
        else if (level == 3)
        {
            Level03Pick();
        }

        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z * -1);
       // Debug.Log("Switch floor of:  " + this.gameObject);
        transform.GetComponent<MeshFilter>().mesh = nextMesh;
        transform.GetComponent<MeshCollider>().sharedMesh = null;
        transform.GetComponent<MeshCollider>().sharedMesh = nextMesh;
    

        CopyFloor.transform.GetComponent<MeshFilter>().mesh = nextMesh;

        CopyFloor.transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z * -1);


    }//end spawn

    /// <summary>
    /// Level one Odds
    /// </summary>
          void  Level01Pick()
    {
        Rand = Random.Range(0, 100);
        if (Rand <= 5)
        {
            nextMesh = HalfTunnel;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 10 && Rand >= 6)
        {
            nextMesh = ArchSpikeFloor;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 15 && Rand >= 11)
        {
            nextMesh = tunnelFloor;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 30 && Rand >= 16)
        {
            nextMesh = bumpFloor;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 50 && Rand >= 31)
        {
            nextMesh = DropFloor;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 60 && Rand >= 51)
        {
            nextMesh = fissureFloor;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 70 && Rand >= 61)
        {
            nextMesh = SpikeFloor;
        }
        else if (Rand <= 75 && Rand >= 71)
        {
            nextMesh = CurveFloor;
        }
        else if (Rand <= 80 && Rand >= 76)
        {
            nextMesh = TightFloor;
        }
        else
        {
            nextMesh = NormalValley;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
        }
    }//End level 1 pick


    /// <summary>
    /// Level 2 odds
    /// </summary>
          void Level02Pick(){
        Rand = Random.Range(0, 100);
        if (Rand <= 10)
        {
            nextMesh = HalfTunnel;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 20 && Rand >= 11)
        {
            nextMesh = ArchSpikeFloor;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 30 && Rand >= 21)
        {
            nextMesh = tunnelFloor;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 40 && Rand >= 31)
        {
            nextMesh = bumpFloor;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 50 && Rand >= 41)
        {
            nextMesh = DropFloor;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 60 && Rand >= 51)
        {
            nextMesh = fissureFloor;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 70 && Rand >= 61)
        {
            nextMesh = SpikeFloor;
        }
        else if (Rand <= 80 && Rand >= 71)
        {
            nextMesh = CurveFloor;
        }
        else if (Rand <= 90 && Rand >= 81)
        {
            nextMesh = TightFloor;
        }
        else
        {
            nextMesh = NormalValley;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
        }
    }
    /// <summary>
    /// Level 3 odds
    /// </summary>
          void  Level03Pick() {
        Rand = Random.Range(0, 100);
        if (Rand <= 10)
        {
            nextMesh = HalfTunnel;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 20 && Rand >= 11)
        {
            nextMesh = ArchSpikeFloor;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 30 && Rand >= 21)
        {
            nextMesh = tunnelFloor;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 40 && Rand >= 31)
        {
            nextMesh = bumpFloor;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 50 && Rand >= 41)
        {
            nextMesh = DropFloor;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 60 && Rand >= 51)
        {
            nextMesh = fissureFloor;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 70 && Rand >= 61)
        {
            nextMesh = SpikeFloor;
        }
        else if (Rand <= 80 && Rand >= 71)
        {
            nextMesh = CurveFloor;
        }
        else if (Rand <= 90 && Rand >= 81)
        {
            nextMesh = TightFloor;
        }
        else
        {
            nextMesh = NormalValley;
            transform.GetComponent<Lev_3_PickupSpawner>().SpawnPickup();
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
        }

    }
     

}//end mono



