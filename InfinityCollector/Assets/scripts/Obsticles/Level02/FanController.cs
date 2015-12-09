using UnityEngine;
using System.Collections;

public class FanController : MonoBehaviour {
	private GameObject player;
	public float speed;
	private float health;
	public bool shieldOn;

	

	public bool Left;
	public bool Right;
	public bool Up;
	public bool Down;

	public float force = 2000f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");




		health = player.GetComponent<playercontroller> ().health;
		if (health <= 0f) {
			Destroy(gameObject);
			
		} 
	}
	
	// Update is called once per frame
	void Update () {
		health = player.GetComponent<playercontroller> ().health;



    }

    void OnTriggerStay(Collider other) {
        if (other.attachedRigidbody)
            if (player.GetComponent<playercontroller>().charMode != 1)
            {
                if (Left)
                {
                    other.attachedRigidbody.AddForce(Vector3.left * force);
                }
                else if (Right)
                {
                    other.attachedRigidbody.AddForce(Vector3.right * force);
                }
                else if (Up)
                {
                    other.attachedRigidbody.AddForce(Vector3.up * force);
                }
                else if (Down)
                {
                    other.attachedRigidbody.AddForce(Vector3.down * force);
                }
            }
	}
}
