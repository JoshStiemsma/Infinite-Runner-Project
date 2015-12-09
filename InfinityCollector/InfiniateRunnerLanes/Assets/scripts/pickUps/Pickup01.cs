using UnityEngine;
using System.Collections;

public class Pickup01 : MonoBehaviour {
	private GameObject player;
	public Vector3 rot;
	private Vector3 pos;
	public float speed;
	private float playerHealth;
	private bool picked;

	public bool dropped;
    public bool cloned;
	private int world;
	private int dir = 1;
	private float dirCounter;


    private int playerReset;
    private int initResets;



    // Use this for initialization
    void Start()
    {
        if (!cloned) { 
        player = GameObject.Find("player");
        rot = transform.eulerAngles;
        world = player.transform.GetComponent<playercontroller>().world;
        initResets = player.transform.GetComponent<playercontroller>().playerReset;

        if (dropped)
        {

        }
        else
        {
            transform.position = new Vector3(Random.Range(-40f, 40f), Random.Range(-35f, 35f), 2000);
        }

        speed = player.GetComponent<playercontroller>().forwardSpeed;
    }//end if not cloned
	}// End Start Function




    /// <summary>
    /// On collision with player add a pickup
    /// </summary>
    /// <param name="col"></param>
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player" && picked==false) {
			picked=true;
			Debug.Log ("GRABBED Pickup");
			player.GetComponent<playercontroller> ().pickUpCount++;
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
        if (cloned == false)
        {
            ////////////////////////////BOOOOOOOST//////////////////////////////
            speed = player.GetComponent<playercontroller>().forwardSpeed;
            playerHealth = player.GetComponent<playercontroller>().health;
            playerReset = player.transform.GetComponent<playercontroller>().playerReset;

            //////////// Move the object:
            Vector3 pos = transform.position;

           // rot.x += 50 * Time.deltaTime;
          //  rot.y += 50 * Time.deltaTime;


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

                if (player.transform.position.z >= transform.position.z  && playerReset >= initResets + 1)
                {
                    Destroy(gameObject);
                }
                if(playerReset >= initResets+2)
                {
                    Destroy(gameObject);
                }
            }


            if (playerHealth >= .1f)
            {
                transform.rotation = Quaternion.Euler(rot);
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
            transform.localPosition = new Vector3(0, 0, 160f);
        }

        }//endupdate
}
