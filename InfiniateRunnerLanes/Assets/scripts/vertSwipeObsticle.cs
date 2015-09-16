using UnityEngine;
using System.Collections;

public class vertSwipeObsticle : MonoBehaviour {

	GameObject obsticle;
	public float direction = 1f;
	public float speed = 3f;
	// Use this for initialization
	void Start () {
		obsticle = this.gameObject as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = obsticle.transform.position; 
		

		if (pos.y >= 36f) {
			direction=-1f;
		}
		if (pos.y <= 32f) {
			direction=1f;
		}
		
		obsticle.transform.position = new Vector3(pos.x, pos.y + (Time.deltaTime*direction*speed), pos.z);
		
		
		
		
	}
}
