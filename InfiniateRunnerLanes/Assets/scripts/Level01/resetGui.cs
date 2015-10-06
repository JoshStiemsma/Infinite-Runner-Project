using UnityEngine;
using System.Collections;

public class resetGui : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        GameObject.Find("resetText").active = false;
  

    }




    // Update is called once per frame
    void Update()
    {


        GameObject resetText = GameObject.Find("resetText");
        GameObject thePlayer = GameObject.Find("player");



        playercontroller playercontroller = thePlayer.GetComponent<playercontroller>();
        if (playercontroller.deathCounter >= 3)
        {
            GameObject.Find("resetText").active = true;

        }
    }
}
