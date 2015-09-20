using UnityEngine;
using System.Collections;

public class planetMovement : MonoBehaviour {

	
	private GameObject planet;
	private Vector3 movement = new Vector3(0,1,0);
	public float Speed = -50f;
	private Vector3 pos;
	
	
	// Use this for initialization
	void Start () {
		planet = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		pos = transform.position;
		
		
		transform.position = new Vector3(pos.x,pos.y,pos.z+(Speed*Time.deltaTime));
	}
}
