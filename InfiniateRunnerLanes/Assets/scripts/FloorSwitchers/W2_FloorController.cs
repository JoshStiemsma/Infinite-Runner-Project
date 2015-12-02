using UnityEngine;
using System.Collections;

public class W2_FloorController : MonoBehaviour {
	public GameObject player;

     public GameObject FirstFloor;
     public GameObject SecondFloor;
     public GameObject ThirdFloor;
	public GameObject FourthFloor;
    public GameObject FifthFloor;
    public GameObject SixthFloor;
    public GameObject SeventhFloor;
    public GameObject EigthFloor;





    private Vector3 firstPos;
	private Vector3 secondPos;
	private Vector3 thirdPos;
	private Vector3 fourthPos;
    private Vector3 fifthPos;
    private Vector3 sixthPos;
    private Vector3 seventhPos;
    private Vector3 eigthPos;



    public bool firstSwitch;
	public bool secondSwitch;
	public bool thirdSwitch;
    public bool fourthSwitch;
    public bool fifthSwitch;
    public bool sixthSwitch;
    public bool seventhSwitch;
    public bool eigthSwitch = true;




    // Use this for initialization
    void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {




		if (player.transform.position.z >=100 && firstSwitch==false)
        {
			Debug.Log("Switch First Floor");
			FirstFloor.transform.GetComponent<W2_FloorSwitch>().SwitchMesh();
			firstSwitch=true;
			eigthSwitch=false;
        }
		else if (player.transform.position.z >=200 && secondSwitch==false)
		{
			Debug.Log("Switch 2 Floor");
			SecondFloor.transform.GetComponent<W2_FloorSwitch>().SwitchMesh();
			secondSwitch=true;
		}
		else if (player.transform.position.z >=300 && thirdSwitch==false)
		{
			Debug.Log("Switch 3 Floor");
			thirdSwitch=true;
			ThirdFloor.transform.GetComponent<W2_FloorSwitch>().SwitchMesh();

		}
        else if (player.transform.position.z >= 400 && fourthSwitch == false)
        {
            Debug.Log("Switch 4 Floor");
            fourthSwitch = true;
            FourthFloor.transform.GetComponent<W2_FloorSwitch>().SwitchMesh();

        }
        else if (player.transform.position.z >= 500 && fifthSwitch == false)
        {
            Debug.Log("Switch 5 Floor");
            fifthSwitch = true;
            FifthFloor.transform.GetComponent<W2_FloorSwitch>().SwitchMesh();

        }
        else if (player.transform.position.z >= 600 && sixthSwitch == false)
        {
            Debug.Log("Switch 6 Floor");
            sixthSwitch = true;
            SixthFloor.transform.GetComponent<W2_FloorSwitch>().SwitchMesh();

        }
        else if (player.transform.position.z >= 700 && seventhSwitch == false)
        {
            Debug.Log("Switch 7 Floor");
            seventhSwitch = true;
            SeventhFloor.transform.GetComponent<W2_FloorSwitch>().SwitchMesh();

        }
        else if (player.transform.position.z <=25 && eigthSwitch==false)
		{
			Debug.Log("Switch 8 Floor");
			eigthSwitch=true;
			firstSwitch=false;
			secondSwitch=false;
			thirdSwitch=false;
            fourthSwitch = false;
            fifthSwitch = false;
            sixthSwitch = false;
            seventhSwitch = false;
            EigthFloor.transform.GetComponent<W2_FloorSwitch>().SwitchMesh();
		
		}




    }
  



}
