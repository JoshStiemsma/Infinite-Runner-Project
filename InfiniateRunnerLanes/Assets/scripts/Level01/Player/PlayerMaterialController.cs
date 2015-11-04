using UnityEngine;
using System.Collections;

public class PlayerMaterialController : MonoBehaviour {
	private bool inBoost;
	private GameObject player;
	void Start(){
		player = GameObject.Find ("player");
		inBoost = player.GetComponent<playercontroller> ().inBoost;
	}


	void Update () {
		inBoost = player.GetComponent<playercontroller> ().inBoost;

		Renderer renderer = GetComponent<Renderer> ();
		Material[] mats = renderer.materials;
		
		float emission = 1f;
		Color baseColor = mats [2].color; //Replace this with whatever you want for your base color at emission level '1'
		
		Color finalColor = baseColor * Mathf.LinearToGammaSpace (emission);
		//Debug.Log (inBoost);

		if (inBoost) {
			mats [2].SetColor ("_EmissionColor", new Color(1f,0f,0f));

		} else {
			mats [2].SetColor ("_EmissionColor", new Color(1f,1f,1f));
		}
	


	}
}
