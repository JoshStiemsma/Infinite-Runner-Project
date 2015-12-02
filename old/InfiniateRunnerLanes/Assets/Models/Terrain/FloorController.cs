using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {
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
    void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {


//		firstPos = FirstFloor.transform.position;
//		secondPos = SecondFloor.transform.position;
//		thirdPos = ThirdFloor.transform.position;
//		fourthPos = FourthFloor.transform.position;
//
//		FirstFloor.transform.position = new Vector3 (firstPos.x, firstPos.y, firstPos.z + speed *Time.fixedDeltaTime);
//		SecondFloor.transform.position = new Vector3 (secondPos.x, secondPos.y, secondPos.z + speed*Time.fixedDeltaTime );
//		ThirdFloor.transform.position = new Vector3 (thirdPos.x, thirdPos.y, thirdPos.z + speed*Time.fixedDeltaTime);
//		FourthFloor.transform.position = new Vector3 (fourthPos.x, fourthPos.y, fourthPos.z + speed *Time.fixedDeltaTime);


		if (player.transform.position.z >=200f && firstSwitch==false)
        {
			Debug.Log("Switch First Floor");
			FirstFloor.transform.GetComponent<FloorSwitchController>().SwitchMesh();
			firstSwitch=true;
			fourthSwitch=false;
        }
		else if (player.transform.position.z >=400f && secondSwitch==false)
		{
			Debug.Log("Switch 2 Floor");
			SecondFloor.transform.GetComponent<FloorSwitchController>().SwitchMesh();
			secondSwitch=true;
		}
		else if (player.transform.position.z >=600f && thirdSwitch==false)
		{
			Debug.Log("Switch 3 Floor");
			thirdSwitch=true;
			ThirdFloor.transform.GetComponent<FloorSwitchController>().SwitchMesh();

		}
		else if (player.transform.position.z <=50f && fourthSwitch==false)
		{
			Debug.Log("Switch 4 Floor");
			fourthSwitch=true;
			firstSwitch=false;
			secondSwitch=false;
			thirdSwitch=false;
			FourthFloor.transform.GetComponent<FloorSwitchController>().SwitchMesh();
		
		}




    }
  



}
