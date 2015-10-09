using UnityEngine;
using System.Collections;

public class playerTilt : MonoBehaviour {
	public Transform rotationTarget;
	private Quaternion rotationTargetRot;

	private float speed = 10f;
	private bool inRoll;
	private bool playerAlive;


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
		float step = speed * Time.deltaTime;
		///////LEFT and RIGHT////////////////////////////////////////
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

//		transform.rotation = Quaternion.Euler ( 
//		                                       (transform.rotation.eulerAngles.x - speed * Time.deltaTime * vertical), 
//		                                       (transform.rotation.eulerAngles.y - speed * Time.deltaTime * horizontal),
//		                                       transform.rotation.eulerAngles.z);





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
		} else if (inRoll == false) {
			rotationTargetRot.z = 0f;
		}








		rotationTarget.rotation= new Quaternion( rotationTargetRot.x, rotationTargetRot.y, rotationTargetRot.z, 1);
		


		if (horizontal <=.3f && horizontal >=-.3f && vertical <=.3f && vertical >=-.3f) {//if barel any input and close to 0 rotation
			//if (transform.localRotation.x < .3f && transform.localRotation.x > -.3f) {
				//transform.localRotation = new Quaternion( 0, 0, 0, 1);
				transform.localRotation = Quaternion.Lerp (transform.rotation, new Quaternion(0,0,0,1), step);
			//}
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
