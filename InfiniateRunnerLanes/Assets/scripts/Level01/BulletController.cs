using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public float speed = 1000f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;


		transform.position = new Vector3( pos.x, pos.y ,pos.z + (speed* Time.deltaTime));
	}
}
