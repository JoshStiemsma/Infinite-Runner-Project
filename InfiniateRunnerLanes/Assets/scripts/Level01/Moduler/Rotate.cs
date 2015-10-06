using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	private bool inBoost;
	// Use this for initialization
	void Start () {
		inBoost = GameObject.Find ("player").GetComponent<playercontroller> ().inBoost;

	}
	
	// Update is called once per frame
	void Update () {
		inBoost = GameObject.Find ("player").GetComponent<playercontroller> ().inBoost;

		if (inBoost) {
			transform.Rotate(0,360*Time.deltaTime*2, 0);
		}
		if (inBoost==false) {
			transform.Rotate(0,360*Time.deltaTime, 0);
		}
	}
}
