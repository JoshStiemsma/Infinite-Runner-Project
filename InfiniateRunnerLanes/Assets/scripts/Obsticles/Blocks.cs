using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {
	private GameObject player;
	
	/// <summary>
	/// The velocity (meters per second) the enemy should move down the screen.
	/// </summary>
	public float speed;
	private float health;
	Vector3 scales = Vector3.zero;

	public bool shieldOn;
	
	public GameObject collisionPrefab;
	
	private bool gotHit;

	public bool Clone = false;

	void Start () {
		player = GameObject.Find ("player");
		health = player.GetComponent<playercontroller> ().health;
		speed = player.GetComponent<playercontroller> ().forwardSpeed;
		if (health <= 0f) {
			Destroy(gameObject);

		} else {
			speed = player.GetComponent<playercontroller> ().forwardSpeed;
			/////////// Random starting angles:
		
			if(Clone==false){
			if(player.GetComponent<playercontroller> ().level==1){
					scales.x = Random.Range (10f, 30f);
					scales.y = Random.Range (75f, 100f);
					scales.z = Random.Range (10f, 100f);
			} else if (player.GetComponent<playercontroller> ().level==2){
				scales.y = Random.Range (10f, 30f);
				scales.x = Random.Range (75f, 100f);
				scales.z = Random.Range (10f, 100f);
			} else if (player.GetComponent<playercontroller> ().level==3){
				float rand;
				rand = Random.Range (1, 100);
				if(rand<=49){
				scales.y = Random.Range (10f, 30f);
				scales.x = Random.Range (75f, 100f);
				scales.z = Random.Range (10f, 100f);
				}else if(rand >= 50){
					scales.x = Random.Range (10f, 30f);
					scales.y = Random.Range (75f, 100f);
					scales.z = Random.Range (10f, 100f);

				}
				
			}
				transform.localScale = scales;
			}else if(Clone==true){
				transform.localScale = transform.parent.localScale;
				transform.position = new Vector3(transform.parent.position.x,transform.parent.position.y,transform.parent.position.z+800);

			}
		
			/////////// Spawn off the top of the screen in a random x position:
		

		
		}

		

	}
	
	void OnCollisionEnter(Collision col)
	{
		
		if (gotHit == false) {
			if (col.gameObject.tag == "Player" && shieldOn == false) {	
				player.GetComponent<playercontroller> ().health -= 25.0f;
				Debug.Log("Player Hit Block");
				//Instantiate (collisionPrefab, transform.position, Quaternion.identity);
			} else if (col.gameObject.tag == "Player" && shieldOn == true) {
				player.GetComponent<playercontroller> ().shield = false;
				//Instantiate (collisionPrefab, transform.position, Quaternion.identity);
			} 



			if (col.gameObject.tag == "Bullet") {
				Debug.Log ("Hit by bullet");
			}else{
				destroy ();
			}
			gotHit=true;
			
		}
		//GameObject.Find ("player").GetComponent<playercontroller> ().shield = false;

	}
	
	void destroy(){
		Debug.Log ("DESTROY");
		
	//	Destroy (this.gameObject);
		Destroy (gameObject);
		
		
	}
	
	

}
