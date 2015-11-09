using UnityEngine;
using System.Collections;

public class MovethenDelete : MonoBehaviour {


    public Vector3 pos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;

        transform.position = new Vector3(pos.x, pos.y, pos.z - 2);

        if (pos.z <= -150)
        {
            Destroy(gameObject);

        }



	}
}
