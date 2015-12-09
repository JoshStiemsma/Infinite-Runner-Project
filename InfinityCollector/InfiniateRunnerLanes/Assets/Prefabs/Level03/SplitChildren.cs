using UnityEngine;
using System.Collections;

public class SplitChildren : MonoBehaviour {




    public void Split()
    {
        transform.GetComponentInChildren<OnCollisionDivide>().SplitRock();

    }
}
