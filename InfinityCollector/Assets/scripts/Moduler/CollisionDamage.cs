using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour {
	private GameObject player;
	private float playerHealth;
	private bool shieldOn;
	public float Damage = 25f;
    private bool gotHit;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {
		player = GameObject.Find ("player"); 
		shieldOn = player.GetComponent<playercontroller> ().shield;
		playerHealth = player.GetComponent<playercontroller> ().health;
	}


    void Update()
    {

        shieldOn = player.GetComponent<playercontroller>().shield;
        playerHealth = player.GetComponent<playercontroller>().health;
    }


    /// <summary>
    /// Raises the collision enter event.
    /// </summary>
    void OnCollisionExit(Collision col)
    {
        if (gotHit == false)
        {
            if (col.gameObject.tag == "Player")
            {
                if (player.GetComponent<playercontroller>().charMode != 1)
                {
                    if (shieldOn == true)
                    {
                        player.GetComponent<playercontroller>().shield = false;  //costed shield
                    }
                    else
                    {
                        player.GetComponent<playercontroller>().health -= 25.0f;    //cost damage
                    }
                }
                else
                { //No effect on player in hulk mode
                }
                Debug.Log("DESTROY via player");
                destroy();
                gotHit = true;
            }
        }

    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
}
