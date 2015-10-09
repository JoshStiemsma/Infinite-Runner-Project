using UnityEngine;
using System.Collections;

public class resetGui : MonoBehaviour {

	private bool playerAlive;
    // Use this for initialization
    void Start()
    {
        GameObject.Find("resetText").active = false;
		playerAlive = GameObject.Find ("player").GetComponent<playercontroller> ().playerAlive;

    }




    // Update is called once per frame
    void Update()
    {


        GameObject resetText = GameObject.Find("resetText");
        GameObject thePlayer = GameObject.Find("player");



        playercontroller playercontroller = thePlayer.GetComponent<playercontroller>();
		if (playerAlive=false)
        {
            GameObject.Find("resetText").active = true;

        }
    }
}
