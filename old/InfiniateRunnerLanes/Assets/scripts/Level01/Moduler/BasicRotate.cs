using UnityEngine;
using System.Collections;

public class BasicRotate : MonoBehaviour {
	public float speed = 2;
	
	// Update is called once per frame
	void Update () {

		//transform.Rotate(180*Time.deltaTime/speed,360*Time.deltaTime/speed,400*Time.deltaTime/speed);
		transform.Rotate(0,0,180*Time.deltaTime/speed);

	}
}
