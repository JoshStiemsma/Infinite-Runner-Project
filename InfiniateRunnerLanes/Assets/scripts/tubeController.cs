using UnityEngine;
using System.Collections;

public class tubeController : MonoBehaviour {
    public float speed;
    Vector3 angles = Vector3.zero;
	private float playerHealth;
    // Use this for initialization
    void Start () {
		playerHealth = GameObject.Find ("Main Camera").GetComponent<gameController> ().playerHealth;
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;
        transform.position = new Vector3( 0f, 6.42f, 4000f);
    }
	
	// Update is called once per frame
	void Update () {
		speed = GameObject.Find ("player").GetComponent<playercontroller> ().forwardSpeed;

        angles.x = transform.rotation.x;
        angles.y = transform.rotation.y;
        angles.z = transform.rotation.z;
		Vector3 pos = transform.position;

if (playerHealth <= .1f) {

			//////////// Move the object:

			pos.z -= speed * Time.deltaTime;
			transform.position = pos;
			angles.z += .5f * Time.deltaTime;
			transform.rotation = Quaternion.Euler (angles);
		}








        //////////// If off the bottom of the screen, destroy this object:
        if (pos.z < -1000) Destroy(gameObject);


    }
}
