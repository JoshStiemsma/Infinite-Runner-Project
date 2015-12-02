using UnityEngine;
using System.Collections;

public class playerTilt : MonoBehaviour {
	private GameObject player;
	public Transform rotationTarget;
	private Quaternion rotationTargetRot;

	private float speed = 20f;
	private bool inRoll;
	private bool playerAlive;
	private bool playerInput;

	private bool isLerping;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		rotationTargetRot = rotationTarget.rotation;
		Debug.Log (rotationTargetRot);
		playerAlive= player.GetComponent<playercontroller> ().playerAlive;
		inRoll= player.GetComponent<playercontroller> ().inRoll;
	}
	
	// Update is called once per frame
	void Update () {
		playerAlive= player.GetComponent<playercontroller> ().playerAlive;
		inRoll= player.GetComponent<playercontroller> ().inRoll;
		//Debug.Log ("Ship : " + transform.rotation + " Targets Rotation : " + rotationTarget.transform.rotation);

		float step = speed * Time.deltaTime;
		///////LEFT and RIGHT////////////////////////////////////////
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");



				///if verticle input rotate ship/////////////////////////
				if (Mathf.Round (vertical * 100f) / 100f >= .2) {
			rotationTargetRot.x = -.2f;
				} else if (Mathf.Round (vertical * 100f) / 100f <= -.2) {
			rotationTargetRot.x = .2f;
				} else if (inRoll == false) {
			rotationTargetRot.x = 0f;
			}

		///if horizontal input rotate ship/////////////////////////
		if (Mathf.Round (horizontal * 100f) / 100f >= .2) {
			rotationTargetRot.z = -.2f;
		} else if (Mathf.Round (horizontal * 100f) / 100f <= -.2) {
			rotationTargetRot.z = .2f;
		} else  {
			rotationTargetRot.z = 0f;
		}
		rotationTarget.rotation= new Quaternion( rotationTargetRot.x, rotationTargetRot.y, rotationTargetRot.z, 1);
		if ((transform.rotation.x - rotationTarget.transform.rotation.x) >= 0.05 ||
			(transform.rotation.y - rotationTarget.transform.rotation.y) >= 0.05 ||
			(transform.rotation.z - rotationTarget.transform.rotation.z) >= 0.05) {
			isLerping = true;
			Debug.Log("facing Forward");
		} else {
			isLerping = false;
		}

		if((Mathf.Round(horizontal * 100f)/ 100f <= .2) && (Mathf.Round(horizontal * 100f)/ 100f >= -.2) && (Mathf.Round(vertical * 100f)/ 100f <= .2) && (Mathf.Round(vertical * 100f)/ 100f >= -.2) ) {
			playerInput = false;
		}else {
			playerInput = true;
		}



		if (playerInput = false && isLerping == true) {//if barel any input and close to 0 rotation
			//if (transform.localRotation.x < .3f && transform.localRotation.x > -.3f) {
			//transform.localRotation = new Quaternion( 0, 0, 0, 1);
			//Lerp to zero
			transform.localRotation = Quaternion.Lerp (transform.rotation, new Quaternion (0, 0, 0, 1), step);
			Debug.Log ("ReturnRotation");
			//}
		} else if (playerInput = false && isLerping == false) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.rotation = new Quaternion(0,0,0,1);
			transform.localRotation = new Quaternion(0,0,0,1);
			Debug.Log("Set Forward");

		} else {
			transform.localRotation = Quaternion.Lerp (transform.rotation, rotationTarget.rotation, step);
		}



	}
}
