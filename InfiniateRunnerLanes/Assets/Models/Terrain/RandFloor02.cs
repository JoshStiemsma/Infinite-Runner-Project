using UnityEngine;
using System.Collections;

public class RandFloor02 : MonoBehaviour {
     private Vector3 pos;
	public int floorInLine;
	public GameObject FloorPrefab;
	public Mesh BendFloor;
	public Mesh LongFloor;
	public Mesh tunnelFloor;
	public Mesh bumpFloor;
	public Mesh DropFloor;
	public Mesh fissureFloor;

    private int Rand;
    private Mesh nextMesh;

    private float startTime;
    private float aliveTime;
    private bool instid;

    private int dir = 1;
    public bool longFloor;

	private float distToNextFloor;
	private float nudgeDist;
	private Vector3 leadFloor;
	private float counter;
    // Use this for initialization
    void Start () {


		pos = transform.position;
	
		RaycastHit hit;
		Vector3 bwd = transform.TransformDirection(Vector3.back);
		if (Physics.Raycast(new Vector3(pos.x, pos.y-15, pos.z), bwd, out hit, 300.0f)) {
			leadFloor = hit.transform.position;
			//transform.position = new Vector3 (leadFloor.x, leadFloor.y, leadFloor.z + 200f);
		}

//		if (pos.z != leadFloor.z + 200) {
//			Debug.Log(leadFloor.z);
//			float newZ = leadFloor.z+200;
//			Debug.Log(newZ);
//			transform.position = new Vector3 (0, 0, newZ);
//		}

		transform.localRotation = new Quaternion(0, 0, 0, 0);
        Rand = Random.Range(0, 4);
        if (Rand <= 1f)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }


//        if (longFloor == true)
//        {
//            transform.localScale = new Vector3(20*dir, 20, 40);
//        }
//        else
//        {
//            transform.localScale = new Vector3(20*dir, 20, 20);
//        }


        startTime = Time.fixedTime;
    }
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;

        transform.position = new Vector3(pos.x, pos.y, pos.z - 50*Time.deltaTime );


//		RaycastHit hit;
//		Vector3 bwd = transform.TransformDirection(Vector3.back);
//		if (Physics.Raycast(new Vector3(pos.x, pos.y-11, pos.z), bwd, out hit, 300.0f)) {
//			leadFloor = hit.transform.position;
//		}
//		if (pos.z != leadFloor.z + 200) {
//
//			float newZ = leadFloor.z+200;
//			transform.position = new Vector3 (leadFloor.x, leadFloor.y, newZ);
//		}


//		if(counter<=100 && instid==false){
//			counter = counter+1;
//
//	}else if(counter>=101 && instid==false){
//			CreateNewFloor();
//			instid = true;
//	}


//            if (pos.z <= 305 && instid == false)
//            {
//                CreateNewFloor();
//                instid = true;
//            }
       




        if (pos.z <= -10)
        {
			transform.position = new Vector3(pos.x, pos.y, pos.z+600);
			SwitchMesh();
        }

    }
	private void SwitchMesh(){
		Rand = Random.Range(0, 4);
		if (Rand == 0)
		{
			nextMesh = BendFloor;
		}
		else if (Rand == 1)
		{
			nextMesh = fissureFloor;
		}else if (Rand == 2)
		{
			nextMesh = DropFloor;
		}else if (Rand == 3)
		{
			nextMesh = tunnelFloor;
		}else  {
			nextMesh = bumpFloor;
		}
		
		
		transform.GetComponent<MeshFilter> ().mesh = nextMesh;

	}
    private void CreateNewFloor() { 



        if (longFloor == true)
        {
			//Instantiate(FloorPrefab, transform.position + transform.forward * 300, transform.rotation);
        }
        else
        {
			//Debug.Log ("Add Floor");
			//Instantiate(FloorPrefab, transform.position + transform.forward * 200, transform.rotation);
        }
       // Instantiate(nextFloor);

}



}
