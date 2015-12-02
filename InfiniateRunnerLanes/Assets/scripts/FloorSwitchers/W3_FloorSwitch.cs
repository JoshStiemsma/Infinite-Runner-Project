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
    public Mesh NormalValley;

    private int Rand;
    private Mesh nextMesh;

    public GameObject CopyFloor;

    /// <summary>
    /// Select next level plane Mesh at Random Likelyness and then apply it to object as well as clone of object down field 
    /// SpawnObsticle Function if capable
    /// Spawn Pickup Function if capable
    /// </summary>
    public void SwitchMesh()
    {
        Rand = Random.Range(0, 80);
        if (Rand <= 10)
        {
            nextMesh = HalfTunnel;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 20 && Rand >= 11)
        {
            nextMesh = ArchSpikeFloor;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 30 && Rand >= 21)
        {
            nextMesh = tunnelFloor;
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
            transform.GetComponent<PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 40 && Rand >= 31)
        {
            nextMesh = bumpFloor;
            transform.GetComponent<PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 50 && Rand >= 41)
        {
            nextMesh = DropFloor;
            transform.GetComponent<PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 60 && Rand >= 51)
        {
            nextMesh = fissureFloor;
            transform.GetComponent<PickupSpawner>().SpawnPickup();
        }
        else if (Rand <= 70 && Rand >= 61)
        {
            nextMesh = SpikeFloor;
        }
        else
        {
            nextMesh = NormalValley;
            transform.GetComponent<PickupSpawner>().SpawnPickup();
            transform.GetComponent<Lev_3_ObsticleSpawner>().SpawnObsticle();
        }
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z * -1);
        Debug.Log("Switch floor of:  " + this.gameObject);
        transform.GetComponent<MeshFilter>().mesh = nextMesh;
        transform.GetComponent<MeshCollider>().sharedMesh = null;
        transform.GetComponent<MeshCollider>().sharedMesh = nextMesh;
    

        CopyFloor.transform.GetComponent<MeshFilter>().mesh = nextMesh;
        CopyFloor.transform.GetComponent<MeshCollider>().sharedMesh = null;
        CopyFloor.transform.GetComponent<MeshCollider>().sharedMesh = nextMesh;
        CopyFloor.transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z * -1);


    }
}



