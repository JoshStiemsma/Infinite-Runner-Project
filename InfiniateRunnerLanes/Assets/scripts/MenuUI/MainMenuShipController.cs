using UnityEngine;
using System.Collections;

public class MainMenuShipController : MonoBehaviour {

	public float speed = 2;
	private Vector3 pos;
	private float deltaY = 1f;
	private bool flip;
	private float flipCount;

	void Update () {
		pos = transform.position;
		//transform.Rotate(180*Time.deltaTime/speed,360*Time.deltaTime/speed,400*Time.deltaTime/speed);
		transform.Rotate(0,0,360*Time.deltaTime/speed);

		if (flipCount >= .7f) {
			deltaY = deltaY * -1;
			flipCount = 0f;
		} else {
			flipCount = flipCount + 1 * Time.deltaTime;
		}


		if (pos.x <= 2000f) {
			transform.position = new Vector3 (pos.x + 15, pos.y + 3*deltaY, pos.z);

		} else {

			transform.position = new Vector3 (-1000f, Random.Range(100,250), pos.z);
		
		}
	}
}
