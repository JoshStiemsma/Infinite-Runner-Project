using UnityEngine;
using System.Collections;

public class MainMenuAsteroidController : MonoBehaviour {

	public float speed = 2;
	private Vector3 pos;




	void Update () {
		pos = transform.position;
		//transform.Rotate(180*Time.deltaTime/speed,360*Time.deltaTime/speed,400*Time.deltaTime/speed);
		//transform.Rotate(0,0,360*Time.deltaTime/speed);

		if (pos.x >= -2000f) {
			transform.position = new Vector3 (pos.x - 10, pos.y, pos.z);

		} else {

			transform.position = new Vector3 (2000f, Random.Range(0,450), pos.z);
			transform.localScale =  new Vector3 ( Random.Range(250,800),  Random.Range(250,800),  Random.Range(250,800));
		}
	}
}
