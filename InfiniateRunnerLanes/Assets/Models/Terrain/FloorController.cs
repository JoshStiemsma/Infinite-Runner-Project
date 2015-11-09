using UnityEngine;
using System.Collections;

public class FloorController : MonoBehaviour {
	public float resetPoint= -150f;
	public float resetDistance = 800f;
	private float speed = -50f;
     public GameObject FirstFloor;
     public GameObject SecondFloor;
     public GameObject ThirdFloor;
	public GameObject FourthFloor;

	private Vector3 firstPos;
	private Vector3 secondPos;
	private Vector3 thirdPos;
	private Vector3 fourthPos;
    // Use this for initialization
    void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {


		firstPos = FirstFloor.transform.position;
		secondPos = SecondFloor.transform.position;
		thirdPos = ThirdFloor.transform.position;
		fourthPos = FourthFloor.transform.position;

		FirstFloor.transform.position = new Vector3 (firstPos.x, firstPos.y, firstPos.z + speed *Time.fixedDeltaTime);
		SecondFloor.transform.position = new Vector3 (secondPos.x, secondPos.y, secondPos.z + speed*Time.fixedDeltaTime );
		ThirdFloor.transform.position = new Vector3 (thirdPos.x, thirdPos.y, thirdPos.z + speed*Time.fixedDeltaTime);
		FourthFloor.transform.position = new Vector3 (fourthPos.x, fourthPos.y, fourthPos.z + speed *Time.fixedDeltaTime);


		if (firstPos.z <= resetPoint)
        {
			FirstFloor.transform.position = new Vector3(firstPos.x,firstPos.y,firstPos.z+resetDistance);
			FirstFloor.transform.GetComponent<FloorSwitchController>().SwitchMesh();
        }
		if (secondPos.z <= resetPoint)
		{
			SecondFloor.transform.position = new Vector3(secondPos.x,secondPos.y,secondPos.z+resetDistance);
			SecondFloor.transform.GetComponent<FloorSwitchController>().SwitchMesh();

		}
		if (thirdPos.z <= resetPoint)
		{
			ThirdFloor.transform.position = new Vector3(thirdPos.x,thirdPos.y,thirdPos.z+resetDistance);
			ThirdFloor.transform.GetComponent<FloorSwitchController>().SwitchMesh();
		}
		if (fourthPos.z <= resetPoint)
		{
			FourthFloor.transform.position = new Vector3(fourthPos.x,fourthPos.y,fourthPos.z+resetDistance);
			FourthFloor.transform.GetComponent<FloorSwitchController>().SwitchMesh();
		}




    }
  



}
