using UnityEngine;
using System.Collections;

public class cameracontroller1 : MonoBehaviour {
	
	
	public GameObject player;
	
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
		
		offset = transform.position - player.transform.position;
		initOffset = transform.position - player.transform.position;
		initCamheight = camHeight;

		offsetFar = offset * 6;
		offsetNear = offset / 6;

		camheightFar = camHeight + 2.7f; 
		camheightNear =  camHeight - 2.7f; 
	}
	
	void FixedUpdate () {


		//BIGGER
		if (Input.GetKeyDown ("z")) {
			offset = offsetFar;
			camHeight = camheightFar;
			Debug.Log ("far" + offsetFar + "by" + offset);
			charMode = 1f;	
		}
		//SMALLER
		if (Input.GetKeyDown ("x")) {
			offset = offsetNear;
			charMode = -1f;	
			camHeight = camheightNear;
			Debug.Log("near" + offsetNear + "by" + offset);
		}  
		
		//NORMAL SIZE
		if(Input.GetKeyUp ("x") || Input.GetKeyUp ("z")) {
			offset = initOffset;
			charMode = 0f;	
			camHeight = initCamheight;

		}

		newZ = player.transform.position.z + offset.z;
	
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y+camHeight,newZ);
		




		
	}
	
	
	
	
	// Update is called once per frame
	void LateUpdate () {

 
		
	}
	
	
	
}
