using UnityEngine;
using System.Collections;

public class pickupShield : MonoBehaviour {
	private GameObject player;
	private Vector3 pos;
	public float speed;
	private float playerHealth;


	public bool dropped;
    public bool clone;
	private int world;
	private int dir = 1;
	private float dirCounter;

    private int playerReset;
    private int initResets;
    // Use this for initialization
    public float timer;
	void Start () {
        if (clone == false)
        {
            player = GameObject.Find("player");
            world = player.transform.GetComponent<playercontroller>().world;
            initResets = player.transform.GetComponent<playercontroller>().playerReset;
            Debug.Log(initResets);
            if (world != 3)
            {
                if (dropped)
                {

                }
                else
                {
                    transform.position = new Vector3(Random.Range(-60f, 60f), Random.Range(-40f, 40f), 2000);
                }
                speed = player.GetComponent<playercontroller>().forwardSpeed;
            }
        }//end if not clone
	}//end start


    /// <summary>
    /// On collision with player add player shield
    /// </summary>
    /// <param name="col"></param>
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			Debug.Log ("GRABBED SHIELD");
			player.GetComponent<playercontroller> ().shield = true;
			Destroy (gameObject);
		}
	
	}
	// Update is called once per frame
	void Update () {

        if (clone == false)
        {
            timer = timer + 1 * Time.deltaTime;
            ////////////////////////////BOOOOOOOST//////////////////////////////
            speed = player.GetComponent<playercontroller>().forwardSpeed;
            playerHealth = player.GetComponent<playercontroller>().health;
            playerReset = player.transform.GetComponent<playercontroller>().playerReset;

            //////////// Move the object:
            Vector3 pos = transform.position;
            if (world == 1)
            {
                pos.z -= speed * Time.deltaTime;

                if (pos.z < -8)
                {
                    Destroy(gameObject);
                }

            }
            else
            {
                pos.y = pos.y + 10 * dir * Time.deltaTime;

                if (dirCounter <= 2)
                {
                    dirCounter = dirCounter + 1 * Time.deltaTime;
                }
                else
                {
                    dirCounter = 0;
                    dir = dir * -1;
                }

                if (player.transform.position.z >= transform.position.z && playerReset >= initResets + 1)
                {
                    Destroy(gameObject);
                }
                if (playerReset >= initResets + 2)
                {
                    Destroy(gameObject);
                }

            }
            if (playerHealth >= .1f)
            {
                transform.position = pos;
            }
            else
            {//if health is under 0
                transform.position = transform.position;
            }
        }
        else
        {
            transform.position = Vector3.zero;
            transform.localPosition = Vector3.zero;
            transform.localPosition = new Vector3(0, 0, 80f);

        }//end if or if not clone

	}//end update
}// end Mono
