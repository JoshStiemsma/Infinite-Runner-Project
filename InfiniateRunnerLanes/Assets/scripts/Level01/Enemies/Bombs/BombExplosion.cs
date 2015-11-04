using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {
	private GameObject player;
	private float delayTimer;
	private float stage;
	private Vector3 scales;

	private bool gotHit;
	private bool shieldOn;
	// Use this for initialization
	void Start () {
		shieldOn = player.GetComponent<playercontroller> ().shield;
		scales = new Vector3 (1, 1, 1);
		delayTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (delayTimer);
		delayTimer = delayTimer + 1 * Time.deltaTime;

		Renderer renderer = GetComponent<Renderer> ();
		Material[] mats = renderer.materials;



		if (delayTimer <= .04f) {
			stage = 1;
			scales = new Vector3 (1, 1, 1);
		
		}

		if (delayTimer >= .07f) {
			stage = 2;
			scales = new Vector3 (5, 5, 5);

		}

		if (delayTimer >= .1f) {
			stage = 3;
			scales = new Vector3 (10, 10, 10);

		}

		if (delayTimer >= .13f) {
			delayTimer = 0f;
		} 
			
		

		if (stage == 1) {
			GetComponent<Renderer> ().material.SetColor ("_Color", Color.cyan);
			GetComponent<Renderer> ().material.SetColor ("_EmmisionColor", new Color(0f,.7f,1f));
		}else if (stage == 2) {
			GetComponent<Renderer> ().material.SetColor ("_Color", Color.red);
			GetComponent<Renderer> ().material.SetColor ("_EmmisionColor", new Color(.3f,0f,0f));
		}else if (stage == 3) {
			GetComponent<Renderer> ().material.SetColor ("_Color", Color.yellow);
			GetComponent<Renderer> ().material.SetColor ("_EmmisionColor", new Color(.5f,.7f,0f));
		}
	

		transform.localScale = scales;
	}


	void OnCollisionEnter(Collision col){
		if (gotHit == false) {
			if (col.gameObject.tag == "Player" && shieldOn == false) {	
				player.GetComponent<playercontroller> ().health -= 75.0f;
			} else if (col.gameObject.tag == "Player" && shieldOn == true) {
				player.GetComponent<playercontroller> ().shield = false;
			} 
			gotHit = true;
		}
	}

}
