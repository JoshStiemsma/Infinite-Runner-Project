using UnityEngine;
using System.Collections;

public class ObjectCopy : MonoBehaviour {
    private GameObject clone;

	// Use this for initialization
	void Start () {
 /*
        Vector3 pos = transform.position;
        Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
        Material material = transform.GetComponent<MeshRenderer>().material;

        clone = new GameObject("Clone");
        clone.transform.position = new Vector3(pos.x, pos.y, pos.z + 800);
        clone.transform.rotation = Quaternion.EulerRotation(0,0,0);
        MeshFilter meshFilter = clone.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = clone.AddComponent<MeshRenderer>();
        meshFilter.mesh = mesh;
        meshRenderer.material = material;
      */

    }
	
public void Destroy()
    {

        Destroy(clone);

    }
}
