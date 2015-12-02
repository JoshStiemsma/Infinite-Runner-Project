using UnityEngine;
using System.Collections;

public class W3_FloorController : MonoBehaviour
{
    public GameObject player;

    public GameObject FirstFloor;
    public GameObject SecondFloor;
    public GameObject ThirdFloor;
    public GameObject FourthFloor;

    private Vector3 firstPos;
    private Vector3 secondPos;
    private Vector3 thirdPos;
    private Vector3 fourthPos;




    public bool firstSwitch;
    public bool secondSwitch;
    public bool thirdSwitch;
    public bool fourthSwitch = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        if (player.transform.position.z >= 200f && firstSwitch == false)
        {
            Debug.Log("Switch First Floor");
            FirstFloor.transform.GetComponent<W3_FloorSwitch>().SwitchMesh();
            firstSwitch = true;
            fourthSwitch = false;
        }
        else if (player.transform.position.z >= 400f && secondSwitch == false)
        {
            Debug.Log("Switch 2 Floor");
            SecondFloor.transform.GetComponent<W3_FloorSwitch>().SwitchMesh();
            secondSwitch = true;
        }
        else if (player.transform.position.z >= 600f && thirdSwitch == false)
        {
            Debug.Log("Switch 3 Floor");
            thirdSwitch = true;
            ThirdFloor.transform.GetComponent<W3_FloorSwitch>().SwitchMesh();

        }
        else if (player.transform.position.z <= 50f && fourthSwitch == false)
        {
            Debug.Log("Switch 4 Floor");
            fourthSwitch = true;
            firstSwitch = false;
            secondSwitch = false;
            thirdSwitch = false;
            FourthFloor.transform.GetComponent<W3_FloorSwitch>().SwitchMesh();

        }




    }




}


