﻿using UnityEngine;
using System.Collections;

public class OnCollideKill : MonoBehaviour {



	public GameObject player;

	private bool shieldOn;


	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start(){
		shieldOn = player.GetComponent<playercontroller> ().shield;
	}



	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	void OnCollisionEnter(Collision  collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shieldOn = player.GetComponent<playercontroller>().shield;
            Debug.Log("hit floor" + transform.name);

            if (shieldOn == false)
            {
                player.transform.GetComponent<playercontroller>().health = 0;
            }
            else if (shieldOn == true)
            {
                player.GetComponent<playercontroller>().shield = false;

            }
        }

}




}