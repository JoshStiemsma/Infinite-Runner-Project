using UnityEngine;
using System.Collections;

public class BombMaterialController : MonoBehaviour {
	private float delayTimer;
	private float stage;


		void Start(){
		stage = 1;
		delayTimer = 0;
		}
		
		
		void Update () {
		Renderer renderer = GetComponent<Renderer> ();
		Material[] mats = renderer.materials;
		delayTimer = delayTimer + 1 * Time.deltaTime;

		if (delayTimer <= .3f) {
			stage = 1;
		}
		if (delayTimer >= .4f) {
			stage = 2;
		}
		if(delayTimer >= .7f) {
			stage = 3;
		}
		if(delayTimer >= 1f) {
			delayTimer = 0f;
		}


		if (stage == 1f) {
			mats [1].SetColor ("_Color", Color.yellow);
			mats [4].SetColor ("_Color", Color.white);
			mats [5].SetColor ("_Color", Color.red);
		}
		if (stage == 2f) {
			mats [1].SetColor ("_Color", Color.white);
			mats [4].SetColor ("_Color", Color.red);
			mats [5].SetColor ("_Color", Color.yellow);
		}
		if (stage == 3f) {
			mats [1].SetColor ("_Color", Color.red);
			mats [4].SetColor ("_Color", Color.yellow);
			mats [5].SetColor ("_Color", Color.white);
		}

			
	}


}
