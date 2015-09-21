using UnityEngine;
using System.Collections;

public class Tube_spin : MonoBehaviour {

    private GameObject tube;
    private Vector3 rotateDirection = new Vector3(0, 0, 1);
    public float rotateSpeed = -1f;

    // Use this for initialization
    void Start () {
        tube = gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(rotateDirection * Time.deltaTime, rotateSpeed);
    }
}
