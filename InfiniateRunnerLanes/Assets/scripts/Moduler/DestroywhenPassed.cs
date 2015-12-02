using UnityEngine;
using System.Collections;

public class DestroywhenPassed : MonoBehaviour {
    //if self is less then player.z destroy

    private GameObject player;

    public bool reset;


    void Start()
    {
        player = GameObject.Find("player");
        reset = false;
    }


    void Update()
    {

        if (player.transform.position.z <= 5f)
        {
            reset = true;
        }

        if (player.transform.position.z >= transform.position.z && reset ==true)
        {
           // Debug.Log("DESSTROY SELF");
            Destroy(gameObject);


        }


    }




}
