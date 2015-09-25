using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	public float fieldOfView; 

	public float health = 100f;




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

	private bool tilted = false;

	public GameObject prefabexplosion;


	private float boost = 0f;
	public float boostAmount = 5f;


	public Rigidbody rb;
	// Use this for initialization
    void Start () 
	{
		player = gameObject;
		rb = GetComponent<Rigidbody>();
	

    }




    void FixedUpdate ()
	{
        pos = player.transform.position;
		rb.velocity = new Vector3(0, 0, 0);
		/////Character Change/////
		/// 
		/// 



		if (Input.GetKeyDown ("z") && charMode != 1) {
			prevTransform.y = pos.y;
            player.transform.localScale = player.transform.localScale * 7;
			pos.y = pos.y-1.5f;
			charMode += 1;

		}
		if (Input.GetKeyDown ("x") && charMode != -1) {
			prevTransform.y = pos.y;
            player.transform.localScale = player.transform.localScale / 7;
			pos.y = pos.y +1.5f;
            charMode -= 1;

		}

		///////LEFT and RIGHT////////
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");




	

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

		///if horizontal input rotate ship///
		if (Mathf.Round(horizontal * 100f) / 100f >= .1 )
		{
			AngY = 210f;
		}else if (Mathf.Round(horizontal * 100f) / 100f <= -.1 )
		{
			AngY = 160f;
		}else {
			AngY = 180f;
		}
       
////////////////////////////BOOOOOOOST//////////////////////////////
		if (Input.GetButtonDown ("Jump")) {
			boost = boostAmount;
			Camera.main.fieldOfView = 65f;
		}

		if (Input.GetButtonUp("Jump")){
			boost = 0f;
			Camera.main.fieldOfView = 60f;
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

		if (health >= .1f) {
			transform.eulerAngles = new Vector3 (AngX, AngY, AngZ);
			player.transform.position = new Vector3 (pos.x, pos.y, 0);
		}

    


		lastZ = player.transform.position.z;
		lastX = player.transform.position.x;
		lastY = player.transform.position.y;







		if(health <= 0f)
		{
			Destroy(this.gameObject);
			Instantiate(prefabexplosion, new Vector3(gameObject.transform.position.x , gameObject.transform.position.y,gameObject.transform.position.z+1f), gameObject.transform.rotation);
			Destroy(prefabexplosion, .2f);
			
		}


	}




	















	void update(){
    


    
    }



}


