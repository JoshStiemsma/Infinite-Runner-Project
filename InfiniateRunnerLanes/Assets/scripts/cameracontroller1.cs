using UnityEngine;
using System.Collections;

public class cameracontroller1 : MonoBehaviour {
	
	
	public GameObject player;
	
	public Vector3 offset;
	
	private float charMode = 0f;
	public float camHeight = 1f;
	// Use this for initialization
	void Start () {
		
		offset = transform.position - player.transform.position;
		
	}
	
	void FixedUpdate () {
		
		
		if (Input.GetKeyDown ("z") && charMode != 1f) {
			offset = offset*4;
			charMode += 1f;	
			camHeight = camHeight+2.5f;
		}
		
		
		if (Input.GetKeyDown ("x") && charMode != -1f ) {
			offset = offset/4;
			charMode -= 1f;	
			camHeight = camHeight = camHeight-2.5f;
		}
		
		
	}
	
	
	
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y+camHeight, player.transform.position.z+offset.z); 
		
	}
	
	
	
}
