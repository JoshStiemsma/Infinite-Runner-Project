using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public float speed = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		speed = speed + 1;


		transform.position = new Vector3( pos.x, pos.y ,pos.z + (speed* Time.deltaTime));
	}
}
