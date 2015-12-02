using UnityEngine;
using System.Collections;

public class W2_FloorSwitch : MonoBehaviour {
	public Mesh Basic;
	//Public Mesh Bendtunnel;
	public Mesh Hallway;

	
	private int Rand;
	private Mesh nextMesh;

	public GameObject CopyFloor;







    /// <summary>
    /// Select next level plane Mesh at Random Likelyness and then apply it to object as well as clone of object down field 
    /// Also run the Spawn Pickup Function
    /// </summary>
	public void SwitchMesh(){
		Rand = Random.Range(0, 80);
		if (Rand <=10)
		{
			nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
			transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <=20 && Rand >=11)
		{
			nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
			transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <=30 && Rand >=21)
		{
			nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
			transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <=40 && Rand >=31)
		{
			nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
			transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <=50 && Rand >=41)
		{
			nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
			transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <=60 && Rand >=51)
		{
			nextMesh = Hallway;
			transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else if (Rand <=70 && Rand >=61)
		{
			nextMesh = Hallway;
			transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
        }
        else  {
			nextMesh = Basic;
            transform.GetComponent<Lev_2_ObsticleSpawner>().SpawnObsticle();
			transform.GetComponent<Lev_2_PickupSpawner>().SpawnPickup();
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
