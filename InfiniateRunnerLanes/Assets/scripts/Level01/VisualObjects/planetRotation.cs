using UnityEngine;
using System.Collections;

public class planetRotation : MonoBehaviour {


	private GameObject planet;
	private Vector3 rotateDirection = new Vector3(0,1,0);
	public float rotateSpeed = -5f;



	// Use this for initialization
	void Start () {
		planet = gameObject;
	}
	
	// Update is called once per frame
	void Update () {



		transform.Rotate(rotateDirection * Time.deltaTime, rotateSpeed);
	}
}
