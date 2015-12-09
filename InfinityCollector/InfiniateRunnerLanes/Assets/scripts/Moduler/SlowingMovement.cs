using UnityEngine;
using System.Collections;

public class SlowingMovement : MonoBehaviour {
    private GameObject player;

    private Vector3 rot;
    private Vector3 pos;
    private float speed;
    private float playerHealth;

    private int world;

    private float decay;
    // Use this for initialization
    void Start()
    {

        player = GameObject.Find("player");
        world = player.transform.GetComponent<playercontroller>().world;
    }

    // Update is called once per frame
    void Update () {
        speed = player.GetComponent<playercontroller>().forwardSpeed;


        playerHealth = player.GetComponent<playercontroller>().health;

        //////////// Move the object:
        Vector3 pos = transform.position;
        if (world == 1)
        {
            decay = decay + .01f;
            pos.z -= speed * Time.deltaTime - decay;
            Debug.Log("Speed: " + speed);
            Debug.Log(" Time:  " + Time.deltaTime);
            Debug.Log("Decay= " + decay);
            Debug.Log("equals" + (speed * Time.deltaTime - decay));

            if (pos.z < -8)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (player.transform.position.z >= transform.position.z + 5f)
            {
                Destroy(gameObject);
            }
        }


        if (playerHealth >= .1f)
        {
            transform.position = pos;
        }
        else
        {//if health is under 0
            transform.position = transform.position;
        }
    }
}
