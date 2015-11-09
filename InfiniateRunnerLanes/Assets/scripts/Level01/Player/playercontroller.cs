using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	public float enemyCount;
	public bool paused; 
	public GameObject MainCamera;
	public bool gameWon;

	public float level;
	/// <summary>
	/// The player.
	/// </summary>
	private GameObject player;
	public GameObject playerPrefab;
	public GameObject startPositionObj;
	public Transform target;
	public Rigidbody rb;
	public Vector3 initPos;
	private Vector3 initPlayerScale;
	private Vector3 pos;
	private Vector3 prevTransform;
	public Vector3 startObjPos;
	public Quaternion initRot;
	public float health = 100f;
	public bool playerAlive;


	/// <summary>
	/// Gun
	/// </summary>
	public GameObject gun;
	public GameObject bulletPrefab;
	public GameObject blueringPrefab;
	public float fireRate;
	private float nextFire;


	/// <summary>
	/// The shield.
	/// </summary>
	public bool shield = false;


	/// <summary>
	/// Sepcial Ability
	/// </summary>
	public float growCounter;
	public float shrinkCounter;
	public float charMode = 0;

	/// <summary>
	/// Barrel Role .
	/// </summary>
	private bool lastRightInput;
	private bool lastLeftInput;
	private bool rightReleased = true;
	private bool leftReleased = true;
	private int tapCount;
	private float lastTap;
	private float leeway = 0.4f; // how fast you have to tap
	private int maxtaps = 2;
	public bool inRoll = false;
	private bool inLeftRoll = false;
	private bool inRightRoll = false;
	private float rollAnimCounter;
	private float rollTimeCount;

	/// <summary>
	/// The boost.
	/// </summary>
	private float boost = 0f;
	public float boostAmount = 5f;
	public bool inBoost;
	public float fuel;
	private float subBoost;


    public float step = 3f;
    public float speed;
	public float forwardSpeed;
    private float direction;
	private bool tilted = false;

	/// <summary>
	/// Explosion Particle.
	/// </summary>
	private GameObject cloneExp;
	public GameObject prefabexplosion;
	public bool launchedExplosion;

	/// <summary>
	/// The enemies.
	/// </summary>
	public GameObject[] Enemies;
	public GameObject[] Obsticals;

	/// <summary>
	/// The pickups.
	/// </summary>
	public GameObject[] Pickups;
	public float pickUpCount;


	/// <summary>
	/// audio.
	/// </summary>
	public AudioClip BoostAudio;
	public AudioClip EngineAudio;






    void Start () 
	{
		Debug.Log ("Start playerController");
		fuel = 100f;
		forwardSpeed = 150f;
		shield = false;
		paused = false;
		startObjPos = startPositionObj.transform.position;

		///instantiate player


		player = gameObject;
		rb = GetComponent<Rigidbody>();
		playerAlive = true;
		launchedExplosion = false;
		Enemies = GameObject.FindGameObjectsWithTag ("enemy");
		Obsticals = GameObject.FindGameObjectsWithTag ("obstical");
		Pickups = GameObject.FindGameObjectsWithTag ("Pickup");


		initPos = player.transform.position;
		initRot = player.transform.localRotation;
		initPlayerScale = player.transform.localScale;
    }



    void FixedUpdate ()
	{
		Enemies = GameObject.FindGameObjectsWithTag ("enemy");
		Obsticals = GameObject.FindGameObjectsWithTag ("obstical");
		Pickups = GameObject.FindGameObjectsWithTag ("Pickup");


		pos = transform.position;


		rb.velocity = new Vector3 (0, 0, 0);


		/////Character Change/////
		//Shrink on z Button
		if (Input.GetKeyDown ("z") && Input.GetKeyDown ("x") == false) {		
			charMode = 1;
		} 
		//Grow on X Button
		if (Input.GetKeyDown ("x") && Input.GetKeyDown ("z") == false) {
			charMode = -1;
		}
		//Ungron when x-button is released
		if (Input.GetKeyUp ("x") || Input.GetKeyUp ("z")) {
			charMode = 0;	
		}


		if (shrinkCounter >= 4f || growCounter >= 4f) {
			charMode = 0;	
		}


		if (charMode == 1 && playerAlive) {
			growCounter = growCounter + 1*Time.deltaTime;
			prevTransform.y = pos.y;
			player.transform.localScale = initPlayerScale * 10;
		}

		if (charMode == 0 && playerAlive) {
			prevTransform.y = pos.y;
			player.transform.localScale = initPlayerScale;
		}
		if (charMode == -1 && playerAlive) {
			shrinkCounter = shrinkCounter + 1*Time.deltaTime;
			prevTransform.y = pos.y;
			player.transform.localScale = initPlayerScale / 10;
		}
		if (charMode != -1 && shrinkCounter >= .1f) {
			shrinkCounter = shrinkCounter - .5f*Time.deltaTime;
		}
		if (charMode != 1 && growCounter >= .1f) {
			growCounter = growCounter - .5f*Time.deltaTime;
		}

		
		///////LEFT and RIGHT////////////////////////////////////////
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");



		//Debug.Log(horizontal);
		/////////////////////////////double tap testers////////////////
		/// Double Tape Right/////
		if (Input.GetKeyDown ("left")||Input.GetKeyDown (KeyCode.A) ) {
			// we're on a One input
			// if we WERE on a Zero input, this is an 'edge' - a 'tap'
			if (leftReleased) {
				if (!lastLeftInput) {
					lastTap = Time.time;
					lastLeftInput = true;
					leftReleased=false;
					tapCount++;
					//Debug.Log ("firstTap");
					if (tapCount == 1) {
						//Debug.Log ("Tap" + horizontal);

					}
					if (tapCount == 2) {
					//	Debug.Log ("DoubleTap" + horizontal);
						inRoll = true;
						inLeftRoll = true;
							GetComponent<Animation>().Play("RollLeft");
					}
					// etc.
					if (tapCount == maxtaps)
						tapCount = 0;
				}
			}
			} else {
				lastLeftInput = false; // we're on a Zero input
				if (Time.time - lastTap > leeway) tapCount = 0; // clear taps if it's been too long
			}
		
		if (Input.GetKeyUp ("left")||Input.GetKeyUp (KeyCode.A) ) {
			leftReleased=true;
		}
		if (Input.GetKeyDown ("right") ||Input.GetKeyDown (KeyCode.D)) {
			// we're on a One input
			// if we WERE on a Zero input, this is an 'edge' - a 'tap'
			if (rightReleased) {
				if (!lastRightInput) {
					lastTap = Time.time;
					lastRightInput = true;
					rightReleased=false;
					tapCount++;
					Debug.Log ("firstTap");
					if (tapCount == 1) {
						Debug.Log ("Tap" + horizontal);
						
					}
					if (tapCount == 2) {
						Debug.Log ("DoubleTap" + horizontal);
						inRoll = true;
						inRightRoll = true;
						GetComponent<Animation>().Play("RollRight");
					}
					// etc.
					if (tapCount == maxtaps)
						tapCount = 0;
				}
			}
		} else {
			lastRightInput = false; // we're on a Zero input
			if (Time.time - lastTap > leeway) tapCount = 0; // clear taps if it's been too long
		}
		
		if (Input.GetKeyUp ("right")||Input.GetKeyDown (KeyCode.D) ) {
			rightReleased=true;
		}

		if (inRightRoll) {
			rollTimeCount++;
			pos.x = pos.x + 1.5f;
			if(rollTimeCount>=30f){
				rollTimeCount=0f;
				inRightRoll=false;
				inRoll=false;
			}
		}
		if (inLeftRoll) {
			rollTimeCount++;
			pos.x = pos.x + -1.5f;
			if(rollTimeCount>=30f){
				rollTimeCount=0f;
				inLeftRoll=false;
				inRoll=false;
			}
		}
	/////////////////////////fuel/////////////////
		
		/////Shooting/////
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(bulletPrefab, gun.transform.position ,Quaternion.identity);
			//bulletPrefab.GetComponent<AudioSource>().Play();
			Instantiate(blueringPrefab, gun.transform.position ,Quaternion.identity);
		}

////////////////////////////BOOOOOOOST//////////////////////////////

		if (Input.GetButtonDown ("Jump") && playerAlive == true) {
			subBoost = 3f;
			forwardSpeed = 300;
			boost = boostAmount;
			inBoost=true;
			GetComponent<AudioSource>().clip = BoostAudio; 
			GetComponent<AudioSource>().Play();
		}
		if (Input.GetButtonUp("Jump")&& playerAlive==true){
			boost = 0f;
			subBoost = 0f;
			//Camera.main.fieldOfView = 60f;
			forwardSpeed = 150f;
			inBoost=false;
			GetComponent<AudioSource>().clip = EngineAudio;
			GetComponent<AudioSource>().Play();
		}


		if (playerAlive== true) {
			fuel = fuel - (1*Time.deltaTime)-(subBoost*Time.deltaTime);
		}

		if (fuel >= 100f) {
			fuel = 100f;
		}



		///////////////////Update Position//////////////////
		pos.y = (pos.y + (vertical * Time.deltaTime* speed));
		pos.x = (pos.x + (horizontal * Time.deltaTime * speed));
		/////////////////////Boundaries///////// 
		if (pos.y >= 35f) {//usualy 35
			pos.y = 35;
		} else if (pos.y <= -25f) {
			pos.y = -25f;
		} 
		if (pos.x >= 40f) {//usuale 40
			pos.x = 40;
		} else if (pos.x <= -40f) {
			pos.x = -40f;
		} 

		if (health >= .1f && fuel >= .1f) {
			player.transform.position = new Vector3 (pos.x, pos.y, 0);
		}
	
    



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
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x+1, transform.eulerAngles.y+1, transform.eulerAngles.z+1);
			pickUpCount = 0;
			health = 0;
		}
		


		////////////////////if player dead and user pressed enter//////////////
		if (playerAlive==false && Input.GetButtonDown("Submit")){

			Debug.Log("player pressed enter");
			fuel = 100f;
			//Destroy enemies
			for(var i = 0 ; i < Obsticals.Length ; i ++)
			{
				Destroy(Obsticals[i]);
			}
			for(var i = 0 ; i < Enemies.Length ; i ++)
			{
				Destroy(Enemies[i]);
			}
			for(var i = 0 ; i < Pickups.Length ; i ++)
			{
				Destroy(Pickups[i]);
			}
			//Reorient player
				player.transform.position = initPos;
				player.transform.localRotation = initRot;
				health = 100f;
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


