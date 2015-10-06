using UnityEngine;
using System.Collections;

public class cameracontroller : MonoBehaviour {


	public GameObject player;

	public Vector3 offset;

	private float charMode = 0f;
	public float camHeight = 3f;
	// Use this for initialization
	void Start () {

	  offset = transform.position - player.transform.position;

	}

	void FixedUpdate () {


		if (Input.GetKeyDown ("z") && charMode != 1f) {
			//offset = offset*5;
			charMode += 1f;	
			camHeight = camHeight*3f;
		}

		
		if (Input.GetKeyDown ("x") && charMode != -1f ) {
			//offset = offset/5;
			charMode -= 1f;	
			camHeight = camHeight/3f;
		}

	
	}



	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (player.transform.position.x, camHeight, player.transform.position.z+offset.z); 
			
	}



}
