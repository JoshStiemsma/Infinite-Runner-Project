using UnityEngine;
using System.Collections;

public class ApplyMaterialOnLoad : MonoBehaviour {

	public Material Mat;




	// Use this for initialization
	void Awake () {
	
		GetComponent<MeshRenderer> ().material = Mat;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
