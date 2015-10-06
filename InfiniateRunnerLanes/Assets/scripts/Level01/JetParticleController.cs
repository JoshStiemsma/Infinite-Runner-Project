using UnityEngine;
using System.Collections;

public class JetParticleController : MonoBehaviour {
	private float charMode = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		
		
		if (Input.GetKeyDown ("z") && charMode != 1f) {
			//offset = offset*5;
			charMode += 1f;	
			transform.localScale = transform.localScale * 5;
		}
		
		
		if (Input.GetKeyDown ("x") && charMode != -1f ) {
			//offset = offset/5;
			charMode -= 1f;	
			transform.localScale = transform.localScale * 5;
		}
		
		
	}
}
