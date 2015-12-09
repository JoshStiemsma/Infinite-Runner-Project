using UnityEngine;
using System.Collections;

public class enSpinningController : MonoBehaviour {
	private GameObject player;
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private bool gotHit;
	private bool shieldOn;
	/// <summary>
	/// A helper for storing euler angles. We store this to avoid gimbal lock.
	/// </summary>
	Vector3 angles = Vector3.zero;

	private float spinspeed;
	private float playerHealth;

	void Start () {
		player = GameObject.Find ("player");
		shieldOn = player.GetComponent<playercontroller> ().shield;
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		playerHealth = player.GetComponent<playercontroller> ().health;
		
		if (player.GetComponent<playercontroller> ().level == 1) {
			spinspeed = 50;
		} else if (player.GetComponent<playercontroller> ().level == 2) {
			spinspeed = 75;
		} else if (player.GetComponent<playercontroller> ().level == 3) {
			spinspeed = 100;
		} 
		
		/////////// Spawn off the top of the screen in a random x position:
		transform.position = new Vector3 (0, 0, 1500);
	}

    void OnCollisionExit(Collision col)
    {
        if (gotHit == false)
        {
            if (col.gameObject.tag == "Player")
            {
                if (player.GetComponent<playercontroller>().charMode != 1)
                {
                    if (shieldOn == true)
                    {
                        player.GetComponent<playercontroller>().shield = false;  //costed shield
                    }
                    else
                    {
                        player.GetComponent<playercontroller>().health -= 25.0f;    //cost damage
                    }
                }
                else
                { //No effect on player in hulk mode
                }
                Debug.Log("DESTROY via player");
                gotHit = true;
            }
        }

    }


    void Update () {
		////////////////////////////BOOOOOOOST//////////////////////////////
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		shieldOn = player.GetComponent<playercontroller> ().shield;
		playerHealth = player.GetComponent<playercontroller> ().health;

		//////////// Spin the object:
		//angles.x += 20 * Time.deltaTime;
		angles.z += spinspeed * Time.deltaTime;

		
		//////////// Move the object:
		Vector3 pos = transform.position;
	if (playerHealth >= .1f) {
			transform.rotation = Quaternion.Euler (angles);
			pos.z -= speed * Time.deltaTime;
			transform.position = pos;
		} else {
			Destroy (gameObject);
		}
		//////////// If off the bottom of the screen, destroy this object:
		if (pos.z < -8) Destroy (gameObject);
	}


}
