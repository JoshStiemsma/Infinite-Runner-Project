using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {




	private float charMode = 0;


    private GameObject player;

    public float step = 1f;
    public float speed;
    public float lane = 0;
    public float laneTimer = 3f;
    private float direction;
    public Transform target;

    /// Reset Testings//
    public float lastZ = 0f;
    public float deathCounter;
    private Vector3 pos;


    // Use this for initialization
    void Start () 
	{
		player = gameObject;


    }




    void FixedUpdate ()
	{
        pos = player.transform.position;


		/////Character Change/////
		if (Input.GetKeyDown ("z") && charMode != 1) {
            player.transform.localScale = player.transform.localScale * 10;
			charMode += 1;
	
		}
		if (Input.GetKeyDown ("x") && charMode != -1) {
            player.transform.localScale = player.transform.localScale / 10;
            charMode -= 1;
		}

		///////LEFT and RIGHT////////
		float horizontal = Input.GetAxis("Horizontal");

        if (Mathf.Round(horizontal * 100f) / 100f >= .1 &&  lane !=1 && laneTimer >= .5f)
        {
            lane = lane + 1;
            laneTimer = 0f;

        }
        if (Mathf.Round(horizontal * 100f) / 100f <= -.1 && lane != -1 && laneTimer >= .5f)
        {
            lane = lane - 1;
            laneTimer = 0f;
        }

        if (Mathf.Round(pos.x * 100f) / 100f != lane*10 && pos.x > lane*10)
        {
            Debug.Log("input");
            pos.x = pos.x - step * Time.deltaTime;
            //target.position = new Vector3(lane*10, pos.y, pos.z); 
            //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else if (Mathf.Round(pos.x* 100f) / 100f != lane*10 && pos.x < lane*10)
        {
            pos.x = pos.x + step*Time.deltaTime;
        }
        else {
            pos.x = pos.x;
        }



        ///Forward Movement////
        pos.z = (pos.z + (speed* Time.deltaTime));

        player.transform.position = new Vector3(pos.x, pos.y, pos.z);


        /////laneTimer
        if (laneTimer <= 4) {
            laneTimer = laneTimer + (1 * Time.deltaTime);
            Debug.Log(laneTimer);
        }


        ///
        /// 
        /// 
        ////////////////Death if player stops moving////////////////////
       /// if (player.transform.position.z <= (lastZ+.005f)) {
          ///  deathCounter = deathCounter + (1 * Time.deltaTime);
           /// if (deathCounter > 3)
          ///  {
            ///    player.transform.position = new Vector3(0, 45, 0);

           /// }
       // } else {
          ///  deathCounter = 0;
		///}
        ///Set Last frames z for next frame testing///
      // lastZ = player.transform.position.z;
    }















	void update(){
    


    
    }



}


