using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	public float fieldOfView; 


	private float charMode = 0;


    private GameObject player;

    public float step = 3f;
    public float speed;
    public float lane = 0;
    public float laneTimer = 3f;
    private float direction;
    public Transform target;

    /// Reset Testings//
    public float lastZ = 0f;
	public float lastX = 0f;
	public float lastY = 0f;
    public float deathCounter;
    private Vector3 pos;
	private Vector3 prevTransform;


	public float AngX = 90f;
	public float AngY = 180f;
	public float AngZ = 0f;


	public GameObject prefabexplosion;


	private float boost = 0f;
	public float boostAmount = 5f;

    // Use this for initialization
    void Start () 
	{
		player = gameObject;

	

    }




    void FixedUpdate ()
	{
        pos = player.transform.position;
	;
		/////Character Change/////
		/// 
		/// 



		if (Input.GetKeyDown ("z") && charMode != 1) {
			prevTransform.y = pos.y;
            player.transform.localScale = player.transform.localScale * 3;
			pos.y = pos.y-1.5f;
			charMode += 1;

		}
		if (Input.GetKeyDown ("x") && charMode != -1) {
			prevTransform.y = pos.y;
            player.transform.localScale = player.transform.localScale / 3;
			pos.y = pos.y +1.5f;
            charMode -= 1;

		}

		///////LEFT and RIGHT////////
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

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

		////move charachter to choz
        if (Mathf.Round(pos.x * 100f) / 100f != lane*30 && pos.x > lane*30)
        {
           
            pos.x = pos.x - step * Time.deltaTime;
			AngY = 160f;

        }
        else if (Mathf.Round(pos.x* 100f) / 100f != lane*30 && pos.x < lane*30)
        {
            pos.x = pos.x + step*Time.deltaTime;		
			//tilt player here
			AngY = 200f;
        }
        else {
            pos.x = pos.x;
			//tilt back player here
			AngY = 180f;
        }


	

		///if verticle input rotate ship///
		if (Mathf.Round(vertical * 100f) / 100f >= .1 )
		{
			AngX = 110f;
		}else if (Mathf.Round(vertical * 100f) / 100f <= -.1 )
		{
			AngX = 70f;
		}else {
			AngX = 90f;
		}

       ////Movement stuff///
		/// 
	
       
////////////////////////////BOOOOOOOST//////////////////////////////
		if (Input.GetButtonDown ("Jump")) {
			boost = boostAmount;
			Camera.main.fieldOfView = 65f;
		}

		if (Input.GetButtonUp("Jump")){
			boost = 0f;
			Camera.main.fieldOfView = 60f;
		}



		//pos.z = (pos.z + (speed* Time.deltaTime)+boost);





		pos.y = (pos.y + (vertical * Time.deltaTime* speed));
		if (pos.y >= 20f) {
			pos.y = 20;
		} else if (pos.y <= 0f) {
			pos.y = 0f;
		} else {
		}
		transform.eulerAngles = new Vector3(AngX,AngY,AngZ);
        player.transform.position = new Vector3(pos.x, pos.y, pos.z);


        /////laneTimer
        if (laneTimer <= 4) {
            laneTimer = laneTimer + (1 * Time.deltaTime);
       
        }


		lastZ = player.transform.position.z;
		lastX = player.transform.position.x;
		lastY = player.transform.position.y;




	}


	void OnTriggerStay(Collider target)
	{
		if(target.tag == "wall")
		{
			Destroy(this.gameObject);
			Instantiate(prefabexplosion, new Vector3(gameObject.transform.position.x , gameObject.transform.position.y,gameObject.transform.position.z+1f), gameObject.transform.rotation);
			Destroy(prefabexplosion, .2f);

		}
	}















	void update(){
    


    
    }



}


