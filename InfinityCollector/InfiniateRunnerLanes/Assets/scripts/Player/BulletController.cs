using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public float speed = 750;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		speed = speed + 1;
		transform.position = new Vector3( pos.x, pos.y ,pos.z + (speed* Time.deltaTime));
	}



    void Oncollision(Collider collider)
    {
        if (collider.tag == "wall")
        {
            Destroy(this.gameObject);

        }


    }
}
