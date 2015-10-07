using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
	
	
	public GameObject player;
	private bool playerAlive;
	
	private Vector3 offset;
	
	private float charMode = 0f;
	public float camHeight = 1f;


	private Vector3 initOffset;
	private float initCamheight;

	private float newZ;

	private Vector3 offsetFar;
	private Vector3 offsetNear;

	private float camheightFar;
	private float camheightNear;
	// Use this for initialization
	void Start () {
		playerAlive = GameObject.Find ("player").GetComponent<playercontroller> ().playerAlive;
		offset = transform.position - player.transform.position;
		initOffset = transform.position - player.transform.position;
		initCamheight = camHeight;

		offsetFar = offset * 6;
		offsetNear = offset / 6;

		camheightFar = camHeight + 2.7f; 
		camheightNear =  camHeight - 2.7f; 
	}
	
	void FixedUpdate () {
		playerAlive = GameObject.Find ("player").GetComponent<playercontroller> ().playerAlive;

		//BIGGER
		if (Input.GetKeyDown ("z") && Input.GetKeyDown ("x")==false) {
			//Debug.Log ("far" + offsetFar + "by" + offset);
			charMode = 1f;	
		}
		//SMALLER
		if (Input.GetKeyDown ("x") && Input.GetKeyDown ("z")==false) {
			charMode = -1f;	
			//Debug.Log("near" + offsetNear + "by" + offset);
		}  
		
		//NORMAL SIZE
		if(Input.GetKeyUp ("x") || Input.GetKeyUp ("z")) {		
			charMode = 0f;	
		}


		if (charMode == -1) {
			offset = offsetNear;		
			camHeight = camheightNear;
		}
		if (charMode == 0) {
			offset = initOffset;
			camHeight = initCamheight;
		}	
		if (charMode == 1) {
			offset = offsetFar;
			camHeight = camheightFar;
		}

		newZ = player.transform.position.z + offset.z;
	
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y+camHeight,newZ);
		




		
	}
	
	
	
	
	// Update is called once per frame
	void LateUpdate () {

 
		
	}
	
	
	
}
