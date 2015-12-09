using UnityEngine;
using System.Collections;

public class fuelCellController : MonoBehaviour {
	private GameObject player;

	private Vector3 rot;
	private Vector3 pos;
	private float speed;
	private float playerHealth;

	public bool dropped;
    public bool clone;
	private int world;
	private int dir = 1;
	private float dirCounter;

    public float timer;
    public float difference;
    private int playerReset;
    private int initResets;
    // Use this for initialization
    void Start () {
        if (clone == false)
        {
            player = GameObject.Find("player");
            rot = transform.eulerAngles;
            world = player.transform.GetComponent<playercontroller>().world;
            initResets = player.transform.GetComponent<playercontroller>().playerReset;

            if (dropped)
            {

            }
            else
            {
                transform.position = new Vector3(Random.Range(-60f, 60f), Random.Range(-40f, 40f), 2000);
            }
            speed = player.GetComponent<playercontroller>().forwardSpeed;
        }


	}

    /// <summary>
    /// On collision with player, add 33 points of fuel
    /// </summary>
    /// <param name="col"></param>
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			player.GetComponent<playercontroller> ().fuel = player.GetComponent<playercontroller> ().fuel + 33f;
			Destroy (gameObject);
		}
	}
	// Update is called once per frame
    /// <summary>
    /// Update  position rotation direction 
    /// </summary>
	void Update () {
        
        if (clone == false)
        {
            timer = timer + 1 * Time.deltaTime;
            
            speed = player.GetComponent<playercontroller>().forwardSpeed;
            playerHealth = player.GetComponent<playercontroller>().health;
            playerReset = player.transform.GetComponent<playercontroller>().playerReset;
            difference = (playerReset -initResets);
            //////////// Move the object:
            Vector3 pos = transform.position;

            //rot.x += 50 * Time.deltaTime;
            //rot.y += 50 * Time.deltaTime;


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
                else
                {

                   // Debug.Log( "Difference " + (playerReset - initResets));

                }
                if (playerReset >= initResets + 2)
                {
                    Destroy(gameObject);
                }

            }


            if (playerHealth >= .1f)
            {
                //transform.rotation = Quaternion.Euler (rot);
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
            transform.localPosition = new Vector3(0, 0, 266.66f);
        }
		
		
	}//end Update
}//end mono
