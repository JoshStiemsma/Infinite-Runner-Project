using UnityEngine;
using System.Collections;

public class OnCollideKill : MonoBehaviour {

	public GameObject player;

	void OnCollisionEnter(){
		Debug.Log ("hit floor");
		player.transform.GetComponent<playercontroller> ().health = 0;
	}
}
