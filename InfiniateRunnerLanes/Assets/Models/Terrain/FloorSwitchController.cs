using UnityEngine;
using System.Collections;

public class FloorSwitchController : MonoBehaviour {
	public Mesh BendFloor;
	public Mesh tunnelFloor;
	public Mesh bumpFloor;
	public Mesh DropFloor;
	public Mesh fissureFloor;
	
	private int Rand;
	private Mesh nextMesh;

	public GameObject CopyFloor;
	public void SwitchMesh(){
		Rand = Random.Range(0, 3);
		if (Rand == 0)
		{
			nextMesh = BendFloor;
		}
		else if (Rand == 1)
		{
			nextMesh = fissureFloor;
		}else if (Rand == 2)
		{
			nextMesh = DropFloor;
		}else if (Rand == 2)
		{
			nextMesh = tunnelFloor;
		}else  {
			nextMesh = bumpFloor;
		}


		Debug.Log("Switch floor of:  " + this.gameObject);
		transform.GetComponent<MeshFilter> ().mesh = nextMesh;
		if (CopyFloor != null) {
			CopyFloor.transform.GetComponent<MeshFilter> ().mesh = nextMesh;
		}

	}
}
