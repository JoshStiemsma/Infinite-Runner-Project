using UnityEngine;
using System.Collections;

public class cameracontroller : MonoBehaviour {


	public GameObject player;

	public Vector3 offset;

	private float charMode = 0f;

	// Use this for initialization
	void Start () {

	  offset = transform.position - player.transform.position;

	}

	void FixedUpdate () {


		if (Input.GetKeyDown ("z") && charMode != 1f) {
			offset = offset*6;
			charMode += 1f;		
		}

		
		if (Input.GetKeyDown ("x") && charMode != -1f ) {
			offset = offset/6;
			charMode -= 1f;		
		}

	
	}



	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}



}
