using UnityEngine;
using System.Collections;

public class Tube_spin : MonoBehaviour {
	private GameObject player;
    private GameObject tube;
    private Vector3 rotateDirection = new Vector3(0, 0, 1);
    public float rotateSpeed = -1f;
	private float health;
    // Use this for initialization
    void Start () {
		player = GameObject.Find ("player");
        tube = gameObject;
	
    }
	
	// Update is called once per frame
	void Update () {
		health = player.GetComponent<playercontroller> ().health;

		if (health >= .1f) {
			transform.Rotate (rotateDirection * Time.deltaTime, rotateSpeed);
		}
		}
}
