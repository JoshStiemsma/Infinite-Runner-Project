using UnityEngine;
using System.Collections;

public class ObjectCopy : MonoBehaviour {
    private GameObject clone;

	// Use this for initialization
	void Start () {


    }
	
public void Destroy()
    {

        Destroy(clone);

    }
}
