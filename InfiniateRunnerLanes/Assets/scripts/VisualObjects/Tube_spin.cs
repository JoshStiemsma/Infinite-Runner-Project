using UnityEngine;
using System.Collections;

public class Tube_spin : MonoBehaviour {

    private GameObject tube;
    private Vector3 rotateDirection = new Vector3(0, 0, 1);
    public float rotateSpeed = -1f;
	private float health;
    // Use this for initialization
    void Start () {
        tube = gameObject;
	
    }
	
	// Update is called once per frame
	void Update () {
		health = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;

		if (health >= .1f) {
			transform.Rotate (rotateDirection * Time.deltaTime, rotateSpeed);
		}
		}
}
