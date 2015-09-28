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

	public bool launchedExplosion;
	private bool launchedStall;


	private float charMode = 0;



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




	public float AngX = 90f;
	public float AngY = 180f;
	public float AngZ = 0f;

	private bool tilted = false;

	public GameObject prefabexplosion;


	private float boost = 0f;
	public float boostAmount = 5f;

	public float fuel;
	private float subBoost;


	public GameObject[] EnemyObjects;


	public float pickUpCount;


	// Use this for initialization
    void Start () 
	{
		fuel = 100f;
		forwardSpeed = 150f;

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
			AngX = 110f;
		}else if (Mathf.Round(vertical * 100f) / 100f <= -.1 )
		{
			AngX = 70f;
		}else {
			AngX = 90f;
		}

		///if horizontal input rotate ship////////////////////////////////////////////
		if (Mathf.Round(horizontal * 100f) / 100f >= .1 )
		{
			AngY = 210f;
		}else if (Mathf.Round(horizontal * 100f) / 100f <= -.1 )
		{
			AngY = 160f;
		}else {
			AngY = 180f;
		}
       
		/////////////////////////fuel/////////////////
		


////////////////////////////BOOOOOOOST//////////////////////////////

		if (Input.GetButtonDown ("Jump") && playerAlive == true) {
			subBoost = 3f;
			forwardSpeed = 300;
			boost = boostAmount;
			//Camera.main.fieldOfView = 65f;
		}

		if (Input.GetButtonUp("Jump")&& playerAlive==true){
			boost = 0f;
			subBoost = 0f;
			//Camera.main.fieldOfView = 60f;
			forwardSpeed = 150f;
		}
		if (playerAlive== true) {
			fuel = fuel - (1*Time.deltaTime)-(subBoost*Time.deltaTime);
		}

		if (fuel >= 100f) {
			fuel = 100f;
		}




		pos.y = (pos.y + (vertical * Time.deltaTime* speed));
		pos.x = (pos.x + (horizontal * Time.deltaTime * speed));

		if (pos.y >= 40f) {
			pos.y = 40;
		} else if (pos.y <= -25f) {
			pos.y = -25f;
		} 
		if (pos.x >= 50f) {
			pos.x = 50;
		} else if (pos.x <= -50f) {
			pos.x = -50f;
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





		//////OUT OF HEALTH
		if(health <= 0f && fuel >= .1f)
		{
			health = 0f;
			playerAlive = false;
			Debug.Log("player dead");
			//GetComponent<Renderer>().gameObject.active = false;
			pickUpCount = 0;
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
			//GetComponent<Renderer>().gameObject.active = false;
			pickUpCount = 0;
		}
		


		////////////////////if player dead and user pressed enter//////////////
		if (playerAlive==false && Input.GetButtonDown("Submit")){
			//GetComponent<Renderer>().gameObject.active = true;

			Debug.Log("player pressed enter");
			fuel = 100f;
			//Destroy enemies
			for(var i = 0 ; i < EnemyObjects.Length ; i ++)
			{
				Destroy(EnemyObjects[i]);
			}
				player.transform.position = initPos;
				player.transform.localRotation = initRot;
				GameObject.Find ("player").GetComponent<playercontroller> ().health = 100f;
				playerAlive = true;
				
			
			//Reorient player


		}
		
		
		
	}




	















	void update(){
    


    
    }



}


