using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	public float fieldOfView; 

	
	private GameObject player;
	public GameObject playerPrefab;
	public GameObject startPositionObj;
	public Vector3 startPos;
	public Rigidbody rb;
	public float health = 25f;
	public bool playerAlive;
	public bool shield = false;

	public GameObject gun;
	public GameObject bulletPrefab;
	public GameObject blueringPrefab;
	public float fireRate;
	private float nextFire;



	public bool launchedExplosion;
	private bool launchedStall;


	private float charMode = 0;

	//Barrel Roll double clic
	private int hzH = 0;//Axis
	private bool hzSwitch = false; //Switch
	private float pressedTime; //Time
	private float BarrelRollDegs = 0;
	private bool inRoll = false;
	private float rollAnimCounter;
	private float rollTimeCount;



    public float step = 3f;
    public float speed;
	public float forwardSpeed;
    public float lane = 0;
    public float laneTimer = 3f;
    private float direction;
    public Transform target;

    /// Reset Testings//
	public Vector3 initPos;
	public Quaternion initRot;

	private GameObject cloneExp;
	
	public float lastZ = 0f;
	public float lastX = 0f;
	public float lastY = 0f;
    public float deathCounter;
    private Vector3 pos;
	private Vector3 prevTransform;




	public float AngX = 0f;
	public float AngY = 0f;
	public float AngZ = 0f;

	private bool tilted = false;

	public GameObject prefabexplosion;


	private float boost = 0f;
	public float boostAmount = 5f;
	public bool inBoost;

	public float fuel;
	private float subBoost;


	public GameObject[] EnemyObjects;


	public float pickUpCount;


	private Animation playerRoll;



	// Use this for initialization
    void Start () 
	{
		fuel = 100f;
		forwardSpeed = 150f;
		shield = false;

	

		playerRoll = GetComponent<Animation> ();
		BarrelRollDegs = Mathf.Clamp(BarrelRollDegs, -10, 10);

		startPos = startPositionObj.transform.position;
		///instantiate player


		player = gameObject;
		rb = GetComponent<Rigidbody>();
		playerAlive = true;
		launchedExplosion = false;
		EnemyObjects = GameObject.FindGameObjectsWithTag ("enemy");
		initPos = player.transform.position;
		initRot = player.transform.localRotation;
    }



    void FixedUpdate ()
	{


		EnemyObjects = GameObject.FindGameObjectsWithTag ("enemy");
		pos = player.transform.position;
		rb.velocity = new Vector3(0, 0, 0);
		/////Character Change/////
		/// 
		/// 


		//Shrink on z Button
		if (Input.GetKeyDown ("z") && charMode != 1) {
			prevTransform.y = pos.y;
            player.transform.localScale = player.transform.localScale * 7;
			pos.y = pos.y-1.5f;
			charMode = 1;
		} 


		//Unshrink when Z-Button releases
		if (Input.GetKeyUp ("z")&& charMode == 1){
			player.transform.localScale = player.transform.localScale/7;
			pos.y = pos.y+1.5f;
			charMode = 0;
		}


		//Grow on X Button
		if (Input.GetKeyDown ("x") && charMode != -1) {
			prevTransform.y = pos.y;
            player.transform.localScale = player.transform.localScale / 7;
			pos.y = pos.y +1.5f;
            charMode = -1;
		}
		//Ungron when x-button is released
		if (Input.GetKeyUp ("x") && charMode == -1) {
			prevTransform.y = pos.y;
			player.transform.localScale = player.transform.localScale * 7;
			pos.y = pos.y -1.5f;
			charMode = 0;			
		}
		
		///////LEFT and RIGHT////////////////////////////////////////
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");




		///if verticle input rotate ship/////////////////////////
		if (Mathf.Round(vertical * 100f) / 100f >= .1 )
		{
			AngX = -15f;
		}else if (Mathf.Round(vertical * 100f) / 100f <= -.1 )
		{
			AngX = 15f;
		}else if(inRoll==false) {
			AngX = 0f;
		}

		//////////////////if horizontal input rotate ship////////////////////////////////////////////
		if (Mathf.Round(horizontal * 100f) / 100f >= .1 && inRoll==false )
		{
			AngZ = -20f;
			AngY = 20f;
		}else if (Mathf.Round(horizontal * 100f) / 100f <= -.1 && inRoll==false )
		{
			AngZ = 20f;
			AngY = -20f;
		}else if(inRoll==false)  {
			AngZ = 0.0f;
			AngY = 0f;
		}   





		if(horizontal>=-.2f && horizontal<=.2f && vertical==0 && inRoll==false && playerAlive){
			player.transform.localRotation = initRot;

		//	Debug.Log("At Rest");
		}
		/////////////////////////////double tap testers
		if(hzH == 2)
		{
			//transform.RotateAround(Vector3.zero, Vector3.up, 360.0f * Time.deltaTime / 3);
			//transform.RotateAround (Vector3.zero, Vector3.up, 360 * Time.deltaTime/300);

			//transform.Rotate(Vector3.up * Time.deltaTime * speed);
			//GetComponent<Animation>().Play ("BarrelRoll");
			Debug.Log("HE PRESSED IT TWICE "); 
			pressedTime = 0; //Return time value
			hzH = 0; //Return press value
			inRoll = true;
		}
		if(hzH == 1)
		{ //If we pressed once count down seconds
			pressedTime += Time.deltaTime;    
		}
		//We pressed anything?
		if (Input.GetAxis ("Horizontal") >= .1f) {       
		if (Input.GetAxis ("Horizontal") >= .1f && hzH < 2) {
			
				hzSwitch = true; //We preseed horinzontal
			}
		}
			else if (hzSwitch && pressedTime <= 2)
			{ //Time is not up? We must press again that axis to turn on hzSwitch
				if(hzH == 0)
				{
					hzH = 1;
					hzSwitch = false;
				}
				else if(hzH == 1)
				{
					hzH = 2;
					hzSwitch = false;				
			}
		}
		if(hzH == 1 && pressedTime >= 2)
		{ //We only pressed it once and time is up
			pressedTime=0;
			hzH=0;
		}


		if (inRoll) {
			rollTimeCount++;
			if(AngZ>360){
				AngZ++;
			}
			if(rollTimeCount>=50f){
				rollTimeCount=0f;
				inRoll=false;
			}
		}
	/////////////////////////fuel/////////////////
		
		/////Shooting/////
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(bulletPrefab, gun.transform.position ,Quaternion.identity);
			Instantiate(blueringPrefab, gun.transform.position ,Quaternion.identity);
		}

////////////////////////////BOOOOOOOST//////////////////////////////

		if (Input.GetButtonDown ("Jump") && playerAlive == true) {
			subBoost = 3f;
			forwardSpeed = 300;
			boost = boostAmount;
			inBoost=true;
			//Camera.main.fieldOfView = 65f;
		}

		if (Input.GetButtonUp("Jump")&& playerAlive==true){
			boost = 0f;
			subBoost = 0f;
			//Camera.main.fieldOfView = 60f;
			forwardSpeed = 150f;
			inBoost=false;
		}


		if (playerAlive== true) {
			fuel = fuel - (1*Time.deltaTime)-(subBoost*Time.deltaTime);
		}

		if (fuel >= 100f) {
			fuel = 100f;
		}




		pos.y = (pos.y + (vertical * Time.deltaTime* speed));
		pos.x = (pos.x + (horizontal * Time.deltaTime * speed));

		if (pos.y >= 35f) {
			pos.y = 35;
		} else if (pos.y <= -25f) {
			pos.y = -25f;
		} 
		if (pos.x >= 40f) {
			pos.x = 40;
		} else if (pos.x <= -40f) {
			pos.x = -40f;
		} 

		if (health >= .1f && fuel >= .1f) {
			transform.eulerAngles = new Vector3 (AngX, AngY, AngZ);

			player.transform.position = new Vector3 (pos.x, pos.y, 0);
		}
		if (fuel <= 0f) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x+1, transform.eulerAngles.y+1, transform.eulerAngles.z+1);
		}
    


		lastZ = player.transform.position.z;
		lastX = player.transform.position.x;
		lastY = player.transform.position.y;


		transform.Rotate(speed*Time.deltaTime,0, 0);



		if (playerAlive == false && launchedExplosion == false) {
			var cloneExp = Instantiate (prefabexplosion, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f), gameObject.transform.rotation);
			Destroy(cloneExp, 1f);
			Debug.Log ("played explosion");
			launchedExplosion = true;
		} 
		//////////////////Out Of Fuel//////////////////////
		if(fuel <= 0f)
		{
			fuel = 0f;
			playerAlive = false;
			Debug.Log("player out of fuel");

			pickUpCount = 0;
		}
		


		////////////////////if player dead and user pressed enter//////////////
		if (playerAlive==false && Input.GetButtonDown("Submit")){

			Debug.Log("player pressed enter");
			fuel = 100f;
			//Destroy enemies
			for(var i = 0 ; i < EnemyObjects.Length ; i ++)
			{
				Destroy(EnemyObjects[i]);
			}
			//Reorient player
				player.transform.position = initPos;
				player.transform.localRotation = initRot;
				GameObject.Find ("player").GetComponent<playercontroller> ().health = 100f;
				playerAlive = true;

		}
		
		//////OUT OF HEALTH
		if(health <= 0f && fuel >= .1f)
		{
			health = 0f;
			playerAlive = false;
			pickUpCount = 0;
		}

		
	}




	















	void update(){
    


    
    }



}


