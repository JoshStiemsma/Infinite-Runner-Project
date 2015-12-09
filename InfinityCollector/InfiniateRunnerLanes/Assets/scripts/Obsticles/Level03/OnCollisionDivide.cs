using UnityEngine;
using System.Collections;

public class OnCollisionDivide : MonoBehaviour {

    public GameObject rockPrefab;
    private GameObject splitRock01;
    private GameObject splitRock02;

    void OnCollisionEnter(Collision collision)
    {
 
        if (collision.gameObject.tag == "Bullet")
        {
            CallSplit();
         

        }//end if collision is bullet


        }//End collision




    void CallSplit()
    {
        transform.parent.GetComponent<SplitChildren>().Split();
    }



    public void SplitRock()
    {
        Vector3 pos = transform.position;
        Vector3 scale = transform.localScale;
        Quaternion RandQuat = new Quaternion(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100));
        Debug.Log("my scale is" + transform.localScale);
        splitRock01 = Instantiate(rockPrefab, new Vector3(pos.x + 1, pos.y + 1, pos.z + 1), RandQuat) as GameObject;
        splitRock02 = Instantiate(rockPrefab, new Vector3(pos.x - 1, pos.y - 1, pos.z - 1), RandQuat) as GameObject;
        splitRock01.transform.localScale = new Vector3(scale.x / 2, scale.y / 2, scale.z / 2);
        splitRock02.transform.localScale = new Vector3(scale.x / 2, scale.y / 2, scale.z / 2);
        splitRock01.transform.parent = transform.parent;
        splitRock02.transform.parent = transform.parent;

        Destroy(this.gameObject);

    }


    }//end Mono
