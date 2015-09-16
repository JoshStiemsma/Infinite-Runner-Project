using UnityEngine;
using System.Collections;

public class SwipingObsticle : MonoBehaviour {

	GameObject obsticle;
	public float direction = 1f;
	public float speed = 3f;
	public float width = 1.5f;
	// Use this for initialization
	void Start () {
		obsticle = this.gameObject as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = obsticle.transform.position; 


		if (pos.x >= width) {
			direction=-1f;
		}
		if (pos.x <= -width) {
			direction=1f;
		}

		obsticle.transform.position = new Vector3(pos.x + (Time.deltaTime*direction*speed), pos.y, pos.z);




	}
}
