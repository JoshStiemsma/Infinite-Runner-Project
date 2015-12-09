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
    private float newY;

    private Vector3 offsetFar;
	private Vector3 offsetNear;

	private float camheightFar;
	private float camheightNear;





	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		playerAlive = player.GetComponent<playercontroller> ().playerAlive;
		charMode = player.GetComponent<playercontroller> ().charMode;

		offset = transform.position - player.transform.position;
		initOffset = transform.position - player.transform.position;
		initCamheight = camHeight;

        offsetFar.z= offset.z * 6;
        offsetNear.z = offset.z / 6;



         camheightFar = camHeight + 2.7f; 
        camheightNear =  camHeight - 1.3f; 
    }
	
	void FixedUpdate () {
		playerAlive = player.GetComponent<playercontroller> ().playerAlive;
		charMode = player.GetComponent<playercontroller> ().charMode;


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
        //newY = player.transform.position.z + offset.y;
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y+ camHeight,     newZ);

	}
	
	

	
	
}
