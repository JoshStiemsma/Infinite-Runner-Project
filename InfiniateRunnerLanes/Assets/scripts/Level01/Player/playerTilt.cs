using UnityEngine;
using System.Collections;

public class playerTilt : MonoBehaviour {
	public Transform rotationTarget;
	private Quaternion rotationTargetRot;

	private float speed = 20f;
	private bool inRoll;
	private bool playerAlive;
	private bool playerInput;

	private bool isLerping;
	// Use this for initialization
	void Start () {
		rotationTargetRot = rotationTarget.rotation;
		Debug.Log (rotationTargetRot);
		playerAlive= GameObject.Find ("player").GetComponent<playercontroller> ().playerAlive;
		inRoll= GameObject.Find ("player").GetComponent<playercontroller> ().inRoll;
	}
	
	// Update is called once per frame
	void Update () {
		playerAlive= GameObject.Find ("player").GetComponent<playercontroller> ().playerAlive;
		inRoll= GameObject.Find ("player").GetComponent<playercontroller> ().inRoll;
		//Debug.Log ("Ship : " + transform.rotation + " Targets Rotation : " + rotationTarget.transform.rotation);

		float step = speed * Time.deltaTime;
		///////LEFT and RIGHT////////////////////////////////////////
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");



				///if verticle input rotate ship/////////////////////////
				if (Mathf.Round (vertical * 100f) / 100f >= .2) {
			rotationTargetRot.x = -.1f;
				} else if (Mathf.Round (vertical * 100f) / 100f <= -.2) {
			rotationTargetRot.x = .1f;
				} else if (inRoll == false) {
			rotationTargetRot.x = 0f;
			}

		///if horizontal input rotate ship/////////////////////////
		if (Mathf.Round (horizontal * 100f) / 100f >= .2) {
			rotationTargetRot.z = -.1f;
		} else if (Mathf.Round (horizontal * 100f) / 100f <= -.2) {
			rotationTargetRot.z = .1f;
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






//
//				if(horizontal==0 && vertical==0){
//					//transform.eulerAngles = new Vector3 (0, 0, 0);
//					transform.localRotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0,0,0,0), speed*Time.deltaTime);
//				} else{
//					transform.localRotation = Quaternion.RotateTowards(transform.rotation, rotationTarget.rotation, speed*Time.deltaTime);
//				}
//		
//		
























//		///if verticle input rotate ship/////////////////////////
//		if (Mathf.Round (vertical * 100f) / 100f >= .2) {
//			//rotationTarget.localRotation= new Quaternion( 30, rotationTargetRot.y, rotationTargetRot.z, rotationTargetRot.w);
//			transform.localRotation = Quaternion.RotateTowards(transform.rotation, rotationTarget.rotation, speed/10*Time.deltaTime);
//			//transform.rotation = Quaternion.Euler ((transform.rotation.eulerAngles.x + 10f * Time.deltaTime * Input.GetAxis ("Horizontal")),transform.rotation.eulerAngles.y,  transform.rotation.eulerAngles.z);
//		} else if (Mathf.Round (vertical * 100f) / 100f <= -.2) {
//			rotationTarget.localRotation= new Quaternion( -30, rotationTargetRot.y, rotationTargetRot.z, rotationTargetRot.w);
//			//player.transform.localRotation = Quaternion.RotateTowards(transform.rotation, rotationTarget.rotation, speed/10*Time.deltaTime);
//			
//		} else if (inRoll == false) {
//			rotationTarget.localRotation= new Quaternion( 0, rotationTargetRot.y, rotationTargetRot.z, rotationTargetRot.w);
//			transform.localRotation = Quaternion.RotateTowards(transform.rotation, rotationTarget.rotation, speed/10*Time.deltaTime);
//			
//		}
//		
//		//////////////////if horizontal input rotate ship////////////////////////////////////////////
//		if (Mathf.Round (horizontal * 100f) / 100f >= .2 && inRoll == false) {
//			//z
//			//y
//		} else if (Mathf.Round (horizontal * 100f) / 100f <= -.2 && inRoll == false) {
//	
//		} else if (inRoll == false) {
//			//AngZ = 0.0f;
//			//AngY = 0.0f;
//			rotationTarget.rotation= new Quaternion( rotationTargetRot.x, rotationTargetRot.y, rotationTargetRot.z, rotationTargetRot.w);
//		}   
//		
//		
//		
//		
//		
//		if (horizontal >= -.2f && horizontal <= .2f && vertical == 0 && inRoll == false && playerAlive) {
//			transform.rotation = new Quaternion (0, 0, 0, 0);
//			//player.transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTarget.rotation, speed/10*Time.deltaTime);
//			
//		}
//		
//		if(horizontal==0 && vertical==0){
//			//transform.eulerAngles = new Vector3 (0, 0, 0);
//			transform.localRotation = Quaternion.RotateTowards(transform.rotation, new Quaternion(0,0,0,0), speed/10*Time.deltaTime);
//		} else{
//			//transform.eulerAngles = new Vector3 (AngX, AngY, AngZ);
//			transform.localRotation = Quaternion.RotateTowards(transform.rotation, rotationTarget.rotation, speed/10*Time.deltaTime);
//			//transform.eulerAngles = new Vector3.RotateTowards(transform.rotation, rotationTarget.rotation, speed/10*Time.deltaTime);
//				//(transform.eulerAngles.x+1, transform.eulerAngles.y+1, transform.eulerAngles.z+1);
//		}
//		transform.Rotate(speed*Time.deltaTime,0, 0);
//


	}
}
