using UnityEngine;
using System.Collections;

public class sunMovement : MonoBehaviour {

	private GameObject planet;
	public float Speed = -.01f;
	private Vector3 pos;
	
	
	// Use this for initialization
	void Start () {
		planet = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		pos = transform.position;
		
		
		transform.position = new Vector3(pos.x,pos.y,pos.z+(Speed/5));
	}
}
