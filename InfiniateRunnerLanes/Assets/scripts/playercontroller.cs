using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	/// get player object//


	private float Timer;

	private float charMode = 0;


	private Rigidbody rb;

    public float jumpHeight;
    private float distToground = 3f;
    public float speed;
	public float maxspeed = 5f;
	public float maxsjump = 15f;



	public float lane =0;
	private float laneVel;
	private float grabDist= .03f;

    /// Reset Testings//
    public float lastZ = 0f;
    public float deathCounter;
    private Vector3 pos;

	private bool laneDelay = false;
	public float laneDelayAmount = 5f;
	private float laneDelayTimer = 0f;
	float rotationSpeed=0.5f ;// This Must be less than 1 and greater than 0
    // Use this for initialization
    void Start () 
	{
		rb = GetComponent<Rigidbody> ();


    }




    void FixedUpdate ()
	{
		/////////////things to grab each fram////////
		
		Vector3 playerPosition=rb.transform.position;
		Vector3 targetPosition = new Vector3 (playerPosition.x, playerPosition.y, (playerPosition.z+1));
	
		// gives us vector to direction of target/
		Vector3 inverseVect=transform.InverseTransformPoint(targetPosition); 
		// calculate angle by which you have to rotate/
		float rotationAngle=Mathf.Atan2(inverseVect.x,inverseVect.z)*Mathf.Rad2Deg; 
		// Now calculate  rotationVelocity to be applied every frame
		Vector3 rotationVelocity=(Vector3.up*rotationAngle)*rotationSpeed*Time.deltaTime; 
		// Calaculate his delta velocity   i.e required - current 
		Vector3 deltavel=(rotationVelocity-rb.angularVelocity);

		// Apply the force to rotate
		rb.AddTorque(0,0, deltavel.z,ForceMode.Impulse);



		Timer += Time.deltaTime;







		/////Character Change/////
		if (Input.GetKeyDown ("z") && charMode != 1) {
			rb.transform.localScale = rb.transform.localScale * 9;
			rb.mass = rb.mass * 3;
            distToground = distToground * 5;
            jumpHeight = jumpHeight /1.5f;
			charMode += 1;
			grabDist = grabDist/5;
	
		}
		if (Input.GetKeyDown ("x") && charMode != -1) {
			rb.transform.localScale = rb.transform.localScale / 9;
			rb.mass = rb.mass / 3;
            distToground = distToground / 5;
            jumpHeight = jumpHeight *1.5f;
            charMode -= 1;
			grabDist = grabDist*5;
		}




		/// JUMP JUMP JUMP/// 
		/// Check for if player is grounded///
		Vector3 blw = transform.TransformDirection(Vector3.down);
		RaycastHit hit = new RaycastHit ();

		/////IF  ON  SOMETHING/////////////////
		if(Physics.Raycast(transform.position, blw, distToground)){	

			//////IF PLayer  PRESSED JUMP(space)//////
		if(Input.GetKeyDown("space")) {
			//rb.velocity += new Vector3(moveHorizontal,10,moveVertical);
			

////////////////////IF ON FLOOR TAG///////////////////////
				if(Physics.Raycast(transform.position, blw,out hit)){
					if (hit.transform.tag == "floor") {
						//rb.AddForce( new Vector3(0,jumpHeight ,0), ForceMode.Impulse);
						rb.velocity = new Vector3(0, jumpHeight, 0);
						Debug.Log ("Jump off floor");
					}
				}



			}
			
		}

		if(rb.velocity.z > maxsjump)
		{
			//rb.velocity.z = rb.velocity.z * maxsjump;
		}


										////////////////FORWARDS AND BACKWARDS MOVEMENT////////////////////
		/// 
		Vector3 pos = rb.transform.position;
		Vector3 vel = rb.velocity;
	

		
		float vertical = (Input.GetAxis("Vertical")*200) * speed * Time.deltaTime;

		
		if (Input.GetAxis("Vertical")>0) {
			maxspeed = 20f;
		} else {
			maxspeed = 15f;


		}

										////////////////////////////////LEFT and RIGHT/////////////////////////
		float horizontal = Input.GetAxis("Horizontal");

		if (laneDelay == false) { ///   false=Allowed to change lane   ////

			if(horizontal == 0 ){ ////no user input (horizontalInput=0)///				Debug.Log ("No input atm!");
			}

			if (horizontal >= 0.1) {////user input of horz is right (horizontalInput=0)///
				if(lane <= 0){ //// Not in far right lane///
	
					laneDelay = true;
					lane= lane+1;
					laneDelayTimer = 0;
				}
			}

			if (horizontal <= -0.1) {////user input of horz is left (horizontalInput=0)///
				if(lane >= 0){	////Not in Far Left Lane////
					Debug.Log ("left!");
					laneDelay = true;
					lane--;
					laneDelayTimer = 0;
				}
			}
			
		} 



		if (laneDelay = true){ ///   true= When not-allowed to change lane   ////
			laneDelayTimer = laneDelayTimer + Time.deltaTime; ////add to laneDelaytimer////
			if(laneDelayTimer >= laneDelayAmount){ ///// If timer reaches chosen amount of delay time/////
				laneDelay = false; ////  player now alowed to change lane///
				laneDelayTimer = laneDelayAmount; ///// timer sites at delayamount Cap////
			}
		}


		pos.x = Mathf.Round(pos.x * 100f) / 100f;

		if(pos.x != lane) {
			if(pos.x>=lane){
				laneVel = -15f;
			}
			if(pos.x<=lane){
				laneVel = 15f;
			}


		
			
		}
		//if (pos.x >= (lane-5f) && pos.x <= (lane+5f)) {///

		if (pos.x >= lane-grabDist && pos.x <= lane+grabDist) {
			laneVel =0;
			rb.transform.position = new Vector3 (lane, pos.y, pos.z);////////put in lane/////
			//////set Y rotation to forward and y rotation velocity to 0///
			///rb.rotation = new Vector3 (rot.x, 0, rot.z);///

		}
		Debug.Log ("lane=" + lane + " pos.x= " + pos.x + " lanevel= " + laneVel);

		Vector3 movement = new Vector3(laneVel, 0.1f,  (speed+ vertical));  ////Forward movement/////

		rb.AddForce (movement); /////Apply forward movement to velocity//////////////






	



		//////////////////////If in Lane Stay in Lane///////////////
















		/////////////speed caps//////////////////
		if(rb.velocity.x > maxspeed)
		{
			rb.velocity = new Vector3(maxspeed, vel.y, vel.z);
		}

		if(rb.velocity.z > maxspeed)
		 {
				rb.velocity = new Vector3(vel.x, vel.y, maxspeed);
		}
		if(rb.velocity.y > maxspeed)
		{
			rb.velocity = new Vector3(vel.x, maxspeed, vel.z);
		}
		
		
		


        ////////////////Death if player stops moving////////////////////
        if (rb.transform.position.z <= (lastZ+.005f)) {
            deathCounter = deathCounter + (1 * Time.deltaTime);
            if (deathCounter > 3)
            {
                rb.transform.position = new Vector3(0, 45, 0);
            }
        } else {
            deathCounter = 0;
		}
        ///Set Last frames z for next frame testing///
       lastZ = rb.transform.position.z;
    }



	void update(){

    }////close update/////



}	//////close all/////


