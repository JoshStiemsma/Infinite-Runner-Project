using UnityEngine;
using System.Collections;

public class FloorSwitchController : MonoBehaviour {
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


	public void SwitchMesh(){
		Rand = Random.Range(0, 80);
		if (Rand <=10)
		{
			nextMesh = HalfTunnel;
		}else if (Rand <=20 && Rand >=11)
		{
			nextMesh = ArchSpikeFloor;
		}else if (Rand <=30 && Rand >=21)
		{
			nextMesh = tunnelFloor;
		}else if (Rand <=40 && Rand >=31)
		{
			nextMesh = bumpFloor;
		}else if (Rand <=50 && Rand >=41)
		{
			nextMesh = DropFloor;
		}else if (Rand <=60 && Rand >=51)
		{
			nextMesh = fissureFloor;
		}else if (Rand <=70 && Rand >=61)
		{
			nextMesh = SpikeFloor;
		}else  {
			nextMesh = NormalValley;
		}
		Vector3 scale = transform.localScale;
		transform.localScale = new Vector3 (scale.x * -1, scale.y, scale.z * -1);
		Debug.Log("Switch floor of:  " + this.gameObject);
		transform.GetComponent<MeshFilter> ().mesh = nextMesh;
		transform.GetComponent<MeshCollider>().sharedMesh = null;
		transform.GetComponent<MeshCollider> ().sharedMesh = nextMesh;
		transform.GetComponent<PickupSpawner>().SpawnPickup();
	
			CopyFloor.transform.GetComponent<MeshFilter> ().mesh = nextMesh;
			CopyFloor.transform.GetComponent<MeshCollider>().sharedMesh = null;
			CopyFloor.transform.GetComponent<MeshCollider> ().sharedMesh = nextMesh;
		CopyFloor.transform.localScale = new Vector3 (scale.x * -1, scale.y, scale.z * -1);
	

	}
}
