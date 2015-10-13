using UnityEngine;
using System.Collections;

public class cameracontroller : MonoBehaviour {


	public GameObject player;

	public Vector3 offset;

	private float charMode = 0f;
	public float camHeight = 3f;

	private float initCamHeight;
	// Use this for initialization
	void Start () {

	  offset = transform.position - player.transform.position;
		initCamHeight = camHeight;
	}

	void FixedUpdate () {
		charMode = GameObject.Find ("player").GetComponent<playercontroller> ().charMode;
		Debug.Log (charMode);

	
	}



	
	// Update is called once per frame
	void LateUpdate () {
		UpdateCamera ();
			
	}
	public void UpdateCamera(){
		charMode = GameObject.Find ("player").GetComponent<playercontroller> ().charMode;
		

		
		if (charMode == 1) {
			camHeight = 9;
		}
		if (charMode == 0) {
			camHeight = 3;
		}
		if (charMode == -1) {
			camHeight = 1;
		}

		transform.position = new Vector3 (player.transform.position.x, camHeight, player.transform.position.z+offset.z); 
	}


}
