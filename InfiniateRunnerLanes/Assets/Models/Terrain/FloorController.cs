using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {
    new public Vector3 pos;

     public GameObject BendFloor;
     public GameObject LongFloor;
     public GameObject tunnelFloor;
     public GameObject bumpFloor;
     public GameObject DropFloor;
     public GameObject fissureFloor;

    new public float Rand;
    new public GameObject nextFloor;
    private float startTime;
    private float aliveTime;
    private bool instid;

    private int dir = 1;
    public bool longFloor;

    // Use this for initialization
    void Start () {
        transform.localRotation = new Quaternion(0, 180, 0, 0);
        // transform.position = new Vector3(0, 0, 299);


        Rand = Random.Range(0, 4);
        Debug.Log("Rand: " + Rand);
        if (Rand <= 1f)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
        if (longFloor == true)
        {
            transform.localScale = new Vector3(10*dir, 10, 20);
        }
        else
        {
            transform.localScale = new Vector3(10*dir, 10, 10);
        }
        startTime = Time.fixedTime;
    }
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;

        transform.position = new Vector3(pos.x, pos.y, pos.z - 50 * Time.deltaTime);

            if (pos.z <= 200f && instid == false)
            {
                CreateNewFloor();
                instid = true;
            }

       

        if (pos.z <= -150)
        {
            Destroy(gameObject);

        }

    }
    private void CreateNewFloor() { 
    Rand = Random.Range(0, 5);
            if (Rand <= 1)
            {
                nextFloor = BendFloor;
            }
            else if (Rand <= 2 && Rand >= 1.1f)
            {
                nextFloor = LongFloor;
            }
            else if (Rand <= 3 && Rand >= 2.1f)
            {
                nextFloor = tunnelFloor;
            }
            else if (Rand <= 4 && Rand >= 3.1f)
            {
                nextFloor =  fissureFloor;
            }
            else if (Rand <= 5 && Rand >= 4.1f)
            {
                nextFloor = DropFloor;
            }
            else 
            {
                nextFloor = bumpFloor;
            }


        if (longFloor == true)
        {
            Instantiate(nextFloor, pos + transform.forward * -199f, transform.rotation);
        }
        else
        {
            Instantiate(nextFloor, pos + transform.forward * -99f, transform.rotation);
        }
       // Instantiate(nextFloor);

}



}
