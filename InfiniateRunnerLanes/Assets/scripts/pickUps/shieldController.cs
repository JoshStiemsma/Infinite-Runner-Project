using UnityEngine;
using System.Collections;

public class shieldController : MonoBehaviour {
	private bool isShieldOn;
	// Use this for initialization
	void Start () {
		isShieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;
	}
	
	// Update is called once per frame
	void Update () {


		//Debug.Log ("shieldController?" + GameObject.Find ("player").GetComponent<playercontroller> ().shield);

		isShieldOn = GameObject.Find ("player").GetComponent<playercontroller> ().shield;

		if (isShieldOn== true) {
			GetComponent<Renderer>().enabled = true;
		}

		if(isShieldOn==false) {
			GetComponent<Renderer>().enabled = false;
		}
	}
}
