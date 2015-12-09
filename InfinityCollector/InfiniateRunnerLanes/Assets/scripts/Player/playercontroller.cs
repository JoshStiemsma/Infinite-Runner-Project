using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {



	public float enemyCount;
	public bool paused; 
	public GameObject MainCamera;
	public bool gameWon;

	public float level;
	public int world;

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
    public int playerReset;


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
	//public RaycastHit hit;
	private int tapCount;
	private float lastTap;
	private float leeway = 0.7f; // how fast you have to tap
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
	private float boostMult = 1f;

    public float step = 3f;
    public float speed;
	public float forwardSpeed;
    public float chosenSpeed;
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
    /// pub
    public float chosenPitch;
    public float initPitch;
    public float boostedPitch;



    public GameObject FloorContainer;




    void Start () 
	{

		fuel = 100f;

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
	
		UpdateplayerSpeed();
		Debug.Log (level);

        initPitch = GetComponent<AudioSource>().pitch;
        chosenPitch = initPitch;
        boostedPitch = initPitch + 2;
    }




    /// <summary>
    /// Update player speed based off of the level
    /// </summary>
	void UpdateplayerSpeed()
    {
        if (world == 1)
        {
            if (level == 1)
            {
                forwardSpeed = PlayerClass.W01_L01_Speed;
                chosenSpeed = PlayerClass.W01_L01_Speed;
            }
            else if (level == 2)
            {
                forwardSpeed = PlayerClass.W01_L02_Speed;
                chosenSpeed = PlayerClass.W01_L02_Speed;
            }
            else if (level == 3)
            {
                forwardSpeed = PlayerClass.W01_L03_Speed;
                chosenSpeed = PlayerClass.W01_L03_Speed;
            }
        }//end first world speed
        else if (world == 2)
        {
            if (level == 1)
            {
                forwardSpeed = PlayerClass.W02_L01_Speed;
                chosenSpeed = PlayerClass.W02_L01_Speed;
            }
            else if (level == 2)
            {
                forwardSpeed = PlayerClass.W02_L02_Speed;
                chosenSpeed = PlayerClass.W02_L02_Speed;
            }
            else if (level == 3)
            {
                forwardSpeed = PlayerClass.W02_L03_Speed;
                chosenSpeed = PlayerClass.W02_L03_Speed;
            }
        }//End second world speeds
        else if (world == 3)
        {
            if (level == 1)
            {
                forwardSpeed = PlayerClass.W03_L01_Speed;
                chosenSpeed = PlayerClass.W03_L01_Speed;
            }
            else if (level == 2)
            {
                forwardSpeed = PlayerClass.W03_L02_Speed;
                chosenSpeed = PlayerClass.W03_L02_Speed;
            }
            else if (level == 3)
            {
                forwardSpeed = PlayerClass.W03_L03_Speed;
                chosenSpeed = PlayerClass.W03_L03_Speed;
            }
        }


    }///End Update Speed via level




    void Update()
    {
        CheckPause();
    }



    void FixedUpdate ()
	{
		Enemies = GameObject.FindGameObjectsWithTag ("enemy");
		Obsticals = GameObject.FindGameObjectsWithTag ("obstical");
		Pickups = GameObject.FindGameObjectsWithTag ("Pickup");


        if (playerAlive)
        {
            ShrinkGrow();
            CheckRollRight();
            CheckRollLeft();
            CheckJoystickRollRight();
            CheckJoystickRollLeft();
            CheckforFire();
            CheckforBoost();
            GetXYInputandApply();
            Checkboundaries();
        }


        CheckHealth();
        CheckFuel();

        SetPitch();
        SetVol();
		///CheckFor Reset
		if (playerAlive==false && Input.GetButtonDown("Submit")){
			ResetLevel();
		}

	}//End Fixed Update





    /// <summary>
    /// Check user inpout for shrink or grow and apply mode change
    /// </summary>
    void ShrinkGrow()
    {
        if (playerAlive == false)
        {
            charMode = 0;
        }
        /////Character Change/////
        //Shrink on Q Button
        if (Input.GetButtonDown("Grow") && Input.GetButtonDown("Shrink") == false)
        {
            charMode = 1;
        }
        //Grow on E Button
        if (Input.GetButtonDown("Shrink") && Input.GetButtonDown("Grow") == false)
        {
            charMode = -1;
        }
        //Ungron/unshrink when q/e-button is released
        if (Input.GetButtonUp("Shrink") || Input.GetButtonUp("Grow"))
        {
            charMode = 0;
        }
        if (Input.GetButton("Shrink") ==false && Input.GetButton("Grow") == false)
        {
            charMode = 0;
        }

        if (shrinkCounter >= 4f || growCounter >= 4f)
        {
            charMode = 0;
        }


        if (charMode == 1)
        {
            growCounter = growCounter + 1 * Time.deltaTime;
            prevTransform.y = pos.y;
            player.transform.localScale = initPlayerScale * 10;
        }

        if (charMode == 0)
        {
            prevTransform.y = pos.y;
            player.transform.localScale = initPlayerScale;
        }
        if (charMode == -1)
        {
            shrinkCounter = shrinkCounter + 1 * Time.deltaTime;
            prevTransform.y = pos.y;
            player.transform.localScale = initPlayerScale / 10;
        }
        if (charMode != -1 && shrinkCounter >= .1f)
        {
            shrinkCounter = shrinkCounter - .5f * Time.deltaTime;
        }
        if (charMode != 1 && growCounter >= .1f)
        {
            growCounter = growCounter - .5f * Time.deltaTime;
        }

    }


    /// <summary>
    /// Get player input for X and Y and then apply it
    /// </summary>
    void GetXYInputandApply()
    {

        pos = transform.position;

        rb.velocity = new Vector3(0, 0, 0);
        ///////LEFT and RIGHT////////////////////////////////////////
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        ///////////////////Update Position//////////////////
        pos.y = (pos.y + (vertical * Time.deltaTime * speed));
        pos.x = (pos.x + (horizontal * Time.deltaTime * speed));


    }

    /// <summary>
    /// Check for Right Barrel roll with joystick
    /// </summary>
    void CheckJoystickRollRight()
    {
        if (Input.GetAxis("Horizontal")==1)
        {
            // we're on a One input
            // if we WERE on a Zero input, this is an 'edge' - a 'tap'
            if (rightReleased)
            {
                if (!lastRightInput)
                {
                    lastTap = Time.time;
                    lastRightInput = true;
                    rightReleased = false;
                    tapCount++;
                    //Debug.Log ("firstTap");
                    if (tapCount == 1)
                    {

                    }
                    if (tapCount == 2)
                    {
                        CheckRight();
                    }
                    if (tapCount == maxtaps)
                        tapCount = 0;
                }
            }//End if not last right input
        }//End if Right has been released
        else//If right is beieng held down
        {
            lastRightInput = false; // we're on a Zero input
            if (Time.time - lastTap > leeway) tapCount = 0; // clear taps if it's been too long
        }


        if (Input.GetAxis("Horizontal") <=.5f)
        {
            rightReleased = true;
        }



        if (inRightRoll)
        {
            rollTimeCount++;
            pos.x = pos.x + 1.5f;
            if (rollTimeCount >= 30f)
            {
                rollTimeCount = 0f;
                inRightRoll = false;
                inRoll = false;
            }
        }

    }
    /// <summary>
    /// Check for Left Barrel roll with joystick
    /// </summary>
    void CheckJoystickRollLeft()
    {
            if (Input.GetAxis("Horizontal") ==-1)
            {
                // we're on a One input
                // if we WERE on a Zero input, this is an 'edge' - a 'tap'
                if (leftReleased)
                {
                    if (!lastLeftInput)
                    {
                        lastTap = Time.time;
                        lastLeftInput = true;
                        leftReleased = false;
                        tapCount++;
                        //Debug.Log ("firstTap");
                        if (tapCount == 1)
                        {
                        }
                        if (tapCount == 2)
                        {
                        CheckLeft();
                        }
                        // etc.
                        if (tapCount == maxtaps)
                            tapCount = 0;
                    }
                }
            }
            else
            {
                lastLeftInput = false; // we're on a Zero input
                if (Time.time - lastTap > leeway) tapCount = 0; // clear taps if it's been too long
            }

            if (Input.GetAxis("Horizontal") >= -.5f)
            {
                leftReleased = true;
            }

            if (inLeftRoll)
            {
                rollTimeCount++;
                pos.x = pos.x + -1.5f;
                if (rollTimeCount >= 30f)
                {
                    rollTimeCount = 0f;
                    inLeftRoll = false;
                    inRoll = false;
                }
            }
        

    }



    /// <summary>
    /// Check for Right Barrel roll (double tap right)
    /// </summary>
    void CheckRollRight()
    {


        if (Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D))
        {
            // we're on a One input
            // if we WERE on a Zero input, this is an 'edge' - a 'tap'
            if (rightReleased)
            {
                if (!lastRightInput)
                {
                    lastTap = Time.time;
                    lastRightInput = true;
                    rightReleased = false;
                    tapCount++;
                    //Debug.Log ("firstTap");
                    if (tapCount == 1)
                    {

                    }
                    if (tapCount == 2)
                    {
                        CheckRight();

                    }
                    if (tapCount == maxtaps)
                        tapCount = 0;
                }
            }//End if not last right input
        }//End if Right has been released
        else//If right is beieng held down
        {
            lastRightInput = false; // we're on a Zero input
            if (Time.time - lastTap > leeway) tapCount = 0; // clear taps if it's been too long
        }


        if (Input.GetKeyUp("right") || Input.GetKeyUp(KeyCode.D))
        {
            rightReleased = true;
        }



      
    }


    /// <summary>
    /// Check for Left Barrel roll (double tap left)
    /// </summary>
    void CheckRollLeft()
    {
        if (Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.A))
        {
            // we're on a One input
            // if we WERE on a Zero input, this is an 'edge' - a 'tap'
            if (leftReleased)
            {
                if (!lastLeftInput)
                {
                    lastTap = Time.time;
                    lastLeftInput = true;
                    leftReleased = false;
                    tapCount++;
                    //Debug.Log ("firstTap");
                    if (tapCount == 1)
                    {
                        //Debug.Log ("Tap" + horizontal);
                    }
                    if (tapCount == 2)
                    {
                        CheckLeft();
                    }
                    // etc.
                    if (tapCount == maxtaps)
                        tapCount = 0;
                }
            }
        }
        else
        {
            lastLeftInput = false; // we're on a Zero input
            if (Time.time - lastTap > leeway) tapCount = 0; // clear taps if it's been too long
        }

        if (Input.GetKeyUp("left") || Input.GetKeyUp(KeyCode.A))
        {
            leftReleased = true;
        }


    }

    /// <summary>
    /// Make sure player doesnt roll left into a wall
    /// </summary>
    void CheckRight()
    {
        Debug.Log("Call RollRight");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 50))         
        {
            Debug.Log("Hit something");
        }else
        {
            Debug.Log("roll right");
            Rollright();

        }

    }

    /// <summary>
    /// Make sure player doesnt roll into a wall
    /// </summary>
    void CheckLeft()
    {
        //	Debug.Log ("DoubleTap" + horizontal);
        Debug.Log("Call RollLeft");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 50))
        {
            Debug.Log("cant roll left");
        }
        else
        {
            Rollleft();
        }
    }

    /// <summary>
    /// Check for Fire
    /// </summary>
    void CheckforFire()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && playerAlive == true)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            Instantiate(blueringPrefab, gun.transform.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Set pitch of engine when boosted
    /// </summary>
    void SetPitch()
    {
       if(GetComponent<AudioSource>().pitch >= chosenPitch + .1f)
        {
            float pitch = GetComponent<AudioSource>().pitch;
            GetComponent<AudioSource>().pitch = pitch - .05f;      
        }
        else if (GetComponent<AudioSource>().pitch <= chosenPitch - .1f)
        {
            float pitch = GetComponent<AudioSource>().pitch;
            GetComponent<AudioSource>().pitch = pitch + .05f;
        }

       

    }

    void SetVol()
    {
        float chosenVol;
        if (playerAlive) {
            chosenVol = .2f;
        }
        else
        {
            chosenVol = 0f;
        }


        if (GetComponent<AudioSource>().volume >= chosenVol + .01f)
        {
            float volume = GetComponent<AudioSource>().volume;
            GetComponent<AudioSource>().volume = volume - .01f;
        }
        else if (GetComponent<AudioSource>().volume <= chosenVol - .01f)
        {
            float volume = GetComponent<AudioSource>().volume;
            GetComponent<AudioSource>().volume = volume + .01f;
        }



    }


    /// <summary>
    /// Check for inport for boost
    /// </summary>
    void CheckforBoost()
    {
        if (Input.GetButtonDown("Jump") && playerAlive == true)
        {
            subBoost = 3f;
            if (world == 1)
            {
                forwardSpeed = chosenSpeed * 2;
            }

            boostMult = 2f;
            boost = boostAmount;
            inBoost = true;
            chosenPitch = boostedPitch;

        }
        if (Input.GetButton("Jump") && playerAlive == true)
        {
            subBoost = 3f;
            if (world == 1)
            {
                forwardSpeed = chosenSpeed * 2;
            }

            boostMult = 2f;
            boost = boostAmount;
            inBoost = true;
            chosenPitch = boostedPitch;

        }
        else
       
            {
            boost = 0f;
            subBoost = 0f;
            boostMult = 1f;
            if (world == 1)
            {
                forwardSpeed = chosenSpeed / 2;
            }
            inBoost = false;
            chosenPitch = initPitch;
        }


        if (Input.GetButtonUp("Jump") && playerAlive == true)
        {
            boost = 0f;
            subBoost = 0f;
            boostMult = 1f;
            if (world == 1)
            {
                forwardSpeed = chosenSpeed / 2;
            }
            inBoost = false;
            chosenPitch = initPitch;
        }
    }
    
    /// <summary>
     /// Check Fuel
     /// </summary>
    void CheckFuel()
    {
        if (playerAlive == true)
        {
            fuel = fuel - (1 * Time.deltaTime) - (subBoost * Time.deltaTime);
        }
        //////////////////Out Of Fuel//////////////////////
        if (fuel <= 0f)
        {
            OutOfFuel();
        }
        if (fuel >= 100f)
        {
            fuel = 100f;
        }

    }
    /// <summary>
    /// Outs the of fuel.
    /// </summary>
    void OutOfFuel()
    {
        fuel = 0f;
        playerAlive = false;
        Debug.Log("player out of fuel");
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + 1, transform.eulerAngles.y + 1, transform.eulerAngles.z + 1);
        pickUpCount = 0;
        health = 0;
    }



    /// <summary>
    /// Check Health
    /// </summary>
    void CheckHealth()
    {
        if (health >= .1f && fuel >= .1f)
        {
            player.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
        //////OUT OF HEALTH
        if (health <= 0f && fuel >= .1f)
        {
            health = 0f;
            playerAlive = false;
            pickUpCount = 0;
        }

        if (playerAlive == false && launchedExplosion == false)
        {
            ExplosionParticle();
        }
    }


	/// <summary>
	/// Rollright this instance.
	/// </summary>
	void Rollright(){
		Debug.Log ("RollRight");
		inRoll = true;
		inRightRoll = true;
		GetComponent<Animation>().Play("RollRight");
        if (inRightRoll)
        {
            rollTimeCount++;
            pos.x = pos.x + 1.5f;
            if (rollTimeCount >= 30f)
            {
                rollTimeCount = 0f;
                inRightRoll = false;
                inRoll = false;
            }
        }
    }
    /// <summary>
    ///  Rollleft this instance.
    /// </summary>
	void Rollleft(){
		Debug.Log ("Rollleft");
		inRoll = true;
		inLeftRoll = true;
		GetComponent<Animation>().Play("RollLeft");
        if (inLeftRoll)
        {
            rollTimeCount++;
            pos.x = pos.x + -1.5f;
            if (rollTimeCount >= 30f)
            {
                rollTimeCount = 0f;
                inLeftRoll = false;
                inRoll = false;
            }
        }
    }

    /// <summary>
    /// spawn ExplosionParticle
    /// </summary>
    void ExplosionParticle(){
		var cloneExp = Instantiate (prefabexplosion, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f), gameObject.transform.rotation);
		Destroy(cloneExp, 1f);
		Debug.Log ("played explosion");
		launchedExplosion = true;
		
	}
	
    /// <summary>
    /// Check for pause
    /// </summary>
	void CheckPause()
    {
        if (Input.GetButtonDown("pause"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                player.GetComponent<AudioSource>().volume = player.GetComponent<AudioSource>().volume / .75f;
                player.GetComponent<AudioSource>().pitch = player.GetComponent<AudioSource>().pitch * 2;
                player.GetComponent<playercontroller>().paused = false;
            }
            else
            {
                Time.timeScale = 0;
                player.GetComponent<AudioSource>().volume = player.GetComponent<AudioSource>().volume * .75f;
                player.GetComponent<AudioSource>().pitch = player.GetComponent<AudioSource>().pitch / 2;
                player.GetComponent<playercontroller>().paused = true;
            }
        }
    }
	
	
	/// <summary>
	/// Resets the level.
	/// </summary>
	public void ResetLevel(){
		Debug.Log ("resetPLAy");
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
        pickUpCount = 0;
		playerAlive = true;
        Time.timeScale = 1;
        gameWon = false;
        playerReset = 0;
        if (world == 3)
        {
            FloorContainer.GetComponent<W3_FloorController>().ResetFirstMesh();
        }
		
	}
	
	/// <summary>
	/// Checkboundaries this instance.
	/// </summary>
	void Checkboundaries(){

		if (world ==1) {
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
			pos.z=0f;
		}

        if (world ==2) {
            if (pos.y >= 60)
            {//usualy 35
                pos.y = 60;
            }
            if (pos.y <= -23)
            {//usualy 35
                pos.y = -23;
            }
            if (pos.x >= 47)
            {
                pos.x = 47;
            }
            else if (pos.x <= -47)
            {
                pos.x = -47;
            }
            pos.z = (pos.z + forwardSpeed * boostMult * Time.deltaTime);
            if (pos.z >= 800)
            {
                playerReset = playerReset + 1;
                Debug.Log("number of resets " + playerReset);
                pos.z = 0f;
            }

        }


        if (world == 3)
        {
            if (pos.y >= 35f)
            {//usualy 35
                pos.y = 35;
            }
            if (pos.x >= 47)
            {
                pos.x = 47;
            }
            else if (pos.x <= -47)
            {
                pos.x = -47;
            }
            pos.z = (pos.z + forwardSpeed * boostMult * Time.deltaTime);
            if (pos.z >= 799)
            {
                playerReset = playerReset + 1;
                Debug.Log("number of resets " + playerReset);
                pos.z = 0f;
            }

        }

	}





}//End Mono


