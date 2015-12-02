using UnityEngine;
using System.Collections;

public class TerrainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;


		transform.position = new Vector3 (pos.x,pos.y ,pos.z-1);



		if (pos.z <= -530) {
			transform.position = new Vector3 (pos.x,pos.y ,970);


		}
	}
}
