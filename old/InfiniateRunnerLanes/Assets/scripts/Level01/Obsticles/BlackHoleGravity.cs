using UnityEngine;
using System.Collections;

public class BlackHoleGravity : MonoBehaviour {


	public GameObject center;
	public GameObject player;
	private Vector3 playerPos;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
	}




	void OnTriggerStay(Collider other) {
		//Debug.Log ("ontrigger");


		player = GameObject.Find ("player");
		playerPos = player.transform.position;

		if (other.attachedRigidbody) {

			//old movement
			//other.transform.position = Vector3.Lerp (playerPos, new Vector3 (center.transform.position.x, center.transform.position.y, player.transform.position.z), 1f * Time.deltaTime);
		
			if(other.transform.position.x - center.transform.position.x <=1f  && other.transform.position.x - center.transform.position.x >=-1f ) {
				//do nothing cause player is in center of blackhole
				
			} else if (other.transform.position.x > center.transform.position.x) {
				other.attachedRigidbody.AddForce (Vector3.left * 1000);
				Debug.Log("Move player Left for Blackhole");
			} else if (other.transform.position.x < center.transform.position.x) {
				other.attachedRigidbody.AddForce (Vector3.right * 1000);
				Debug.Log("Move player Right for Blackhole");
			}




			if(other.transform.position.y - center.transform.position.y <=1f && other.transform.position.y - center.transform.position.y >=-1f) {
				//do nothing cause player is in center of blackhole

			} else if(other.transform.position.y > center.transform.position.y) {
				//move player down towards blackhole
				other.attachedRigidbody.AddForce (Vector3.down * 1000);
				Debug.Log("Move player Down for Blackhole");
			}else if (other.transform.position.y < center.transform.position.y) {
				//move player up towards blackhole
				other.attachedRigidbody.AddForce (Vector3.up * 1000);
				Debug.Log("Move player Up for Blackhole");
			}
		
		
		}
	}
}
