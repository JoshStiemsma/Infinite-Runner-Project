using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
	private int levelReached;
	//private int levelReached;
	public CanvasGroup startPanel;
	public CanvasGroup worldPanel;
	public CanvasGroup optionsPanel;


	public Button firstWorldButton;
	public Button secondWorldButton;
	public Button thirdWorldButton;


	public CanvasGroup firstLevelPanel;
	private Vector3 firstInit;
	private Vector3 firstDest;



	public CanvasGroup secondLevelPanel;
	private Vector3 secondInit;
	private Vector3 secondDest;


	public CanvasGroup thirdLevelPanel;
	private Vector3 thirdInit;
	private Vector3 thirdDest;

	
	private bool first;
	private bool second;
	private bool third;




	public float count;


	public void Start(){
		PlayerData.playerData.Load ();
		levelReached = PlayerData.playerData.levelReached;
		Debug.Log ("Started");
		Time.timeScale = 1;

		firstInit = firstWorldButton.transform.position;
		secondInit = secondWorldButton.transform.position;
		thirdInit = thirdWorldButton.transform.position;
		optionsPanel.GetComponent<CanvasGroup> ().alpha = 0;
		optionsPanel.GetComponent<CanvasGroup> ().interactable = false;
		optionsPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		worldPanel.GetComponent<CanvasGroup> ().alpha = 0;
		worldPanel.GetComponent<CanvasGroup> ().interactable = false;
		worldPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		startPanel.GetComponent<CanvasGroup> ().alpha = 1;
		startPanel.GetComponent<CanvasGroup> ().interactable = true;
		startPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

		firstLevelPanel.GetComponent<CanvasGroup> ().alpha = 0;
		firstLevelPanel.GetComponent<CanvasGroup> ().interactable = false;
		firstLevelPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		secondLevelPanel.GetComponent<CanvasGroup> ().alpha = 0;
		secondLevelPanel.GetComponent<CanvasGroup> ().interactable = false;
		secondLevelPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		thirdLevelPanel.GetComponent<CanvasGroup> ().alpha = 0;
		thirdLevelPanel.GetComponent<CanvasGroup> ().interactable = false;
		thirdLevelPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		
	
		
	}


	public void Update(){


		if (first == true) {
			firstDest = new Vector3 (firstInit.x - 320, firstInit.y, firstInit.z);
			Debug.Log ("First");
			firstLevelPanel.GetComponent<CanvasGroup> ().alpha = 1;
			firstLevelPanel.GetComponent<CanvasGroup> ().interactable = true;
			firstLevelPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

		} else {
			firstDest = firstInit;
			firstWorldButton.GetComponent<Button> ().interactable = true;
			firstLevelPanel.GetComponent<CanvasGroup> ().alpha = 0;
			firstLevelPanel.GetComponent<CanvasGroup> ().interactable = false;
			firstLevelPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}

		if (second == true) {
			secondDest = new Vector3 (secondInit.x - 320, secondInit.y, secondInit.z);
			secondLevelPanel.GetComponent<CanvasGroup> ().alpha = 1;
			secondLevelPanel.GetComponent<CanvasGroup> ().interactable = true;
			secondLevelPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		} else {
			secondDest = secondInit;
			secondLevelPanel.GetComponent<CanvasGroup> ().alpha = 0;
			secondLevelPanel.GetComponent<CanvasGroup> ().interactable = false;
			secondLevelPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
		if (third == true) {
			thirdDest = new Vector3 (thirdInit.x - 320, thirdInit.y, thirdInit.z);
			thirdLevelPanel.GetComponent<CanvasGroup> ().alpha = 1;
			thirdLevelPanel.GetComponent<CanvasGroup> ().interactable = true;
			thirdLevelPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		} else {
			thirdDest = thirdInit;
			thirdLevelPanel.GetComponent<CanvasGroup> ().alpha = 0;
			thirdLevelPanel.GetComponent<CanvasGroup> ().interactable = false;
			thirdLevelPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}

		if (firstWorldButton.transform.position.x != firstDest.x) {
			Debug.Log("Move Button");
			firstWorldButton.transform.position =  Vector3.MoveTowards (firstWorldButton.transform.position ,firstDest, 500*Time.deltaTime);
		}
		if (secondWorldButton.transform.position.x != secondDest.x) {
			secondWorldButton.transform.position =  Vector3.MoveTowards (secondWorldButton.transform.position ,secondDest, 500*Time.deltaTime);
		}
		if (thirdWorldButton.transform.position.x != thirdDest.x) {
			thirdWorldButton.transform.position =  Vector3.MoveTowards (thirdWorldButton.transform.position ,thirdDest, 500*Time.deltaTime);
		}
		


	}


	public void Play(){
		startPanel.GetComponent<CanvasGroup> ().alpha = 0;
		startPanel.GetComponent<CanvasGroup> ().interactable = false;
		startPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		worldPanel.GetComponent<CanvasGroup> ().alpha = 1;
		worldPanel.GetComponent<CanvasGroup> ().interactable = true;
		worldPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;



	}


	public void Options(){
		startPanel.GetComponent<CanvasGroup> ().alpha = 0;
		startPanel.GetComponent<CanvasGroup> ().interactable = false;
		startPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;


		optionsPanel.GetComponent<CanvasGroup> ().alpha = 1;
		optionsPanel.GetComponent<CanvasGroup> ().interactable = true;
		optionsPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;


	}

	public void Exit(){
//end game
		Application.Quit();
	}


	public void FirstLevelFirstWorld(){
		Application.LoadLevel("L01_W01");	
	}
	public void SecondLevelFirstWorld(){
		Application.LoadLevel("L02_W01");		
	}
	public void ThirdLevelFirstWorld(){
		Application.LoadLevel("L03_W01");		
	}

	public void FirstLevelSecondWorld(){
		Application.LoadLevel("L01_W02");	
	}
	public void SecondLevelSecondWorld(){
		Application.LoadLevel("L02_W02");		
	}
	public void ThirdLevelSecondWorld(){
		Application.LoadLevel("L03_W02");		
	}

	public void FirstLevelThirdWorld(){
		Application.LoadLevel("L01_W03");	
	}
	public void SecondLevelThirdWorld(){
		Application.LoadLevel("L02_W03");		
	}
	public void ThirdLevelThirdWorld(){
		Application.LoadLevel("L03_W03");		
	}


	public void FirstWorld(){
		Debug.Log ("first");
		if (first == false) {
			first = true;
			second = false;
			third = false;
			
		} else {
			first = false;
		}
	}


	public void SecondWorld(){
		Debug.Log ("seoond");
if (levelReached >= 3) {
			if (second == false) {
				first = false;
				second = true;
				third = false;
			} else {
				second = false;
			}
		}
	}
	public void ThirdWorld(){
		Debug.Log ("third");
		if (levelReached >= 6) {
			if (third == false) {
				first = false;
				second = false;
				third = true;
			} else {
				third = false;
			}

		}
	}















	public void WorldBack(){

		worldPanel.GetComponent<CanvasGroup> ().alpha = 0;
		worldPanel.GetComponent<CanvasGroup> ().interactable = false;
		worldPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		startPanel.GetComponent<CanvasGroup> ().alpha = 1;
		startPanel.GetComponent<CanvasGroup> ().interactable = true;
		startPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;

	}
	

	public void OptionsBack(){
		
		optionsPanel.GetComponent<CanvasGroup> ().alpha = 0;
		optionsPanel.GetComponent<CanvasGroup> ().interactable = false;
		optionsPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		
		
		startPanel.GetComponent<CanvasGroup> ().alpha = 1;
		startPanel.GetComponent<CanvasGroup> ().interactable = true;
		startPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}
}
