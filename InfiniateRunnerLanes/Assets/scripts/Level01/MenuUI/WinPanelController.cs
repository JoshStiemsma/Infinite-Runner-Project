using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinPanelController : MonoBehaviour {
	private GameObject player;
	private bool gameWon;
	private float time;
	public Text timeText;


	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		gameWon = player.GetComponent<playercontroller> ().gameWon;

	}
	
	// Update is called once per frame
	void Update () {
		gameWon = player.GetComponent<playercontroller> ().gameWon;


		if (gameWon == true) {

			GetComponent<CanvasGroup> ().alpha = 1;
			GetComponent<CanvasGroup> ().interactable = true;
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
			timeText.text = time.ToString();
		} else {
			GetComponent<CanvasGroup> ().alpha = 0;
			GetComponent<CanvasGroup> ().interactable = false;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;


		}
	}

	public void NextLevel(){
		if (player.GetComponent<playercontroller> ().level == 1f) {
			Application.LoadLevel("L02_W01");
		}
		if (player.GetComponent<playercontroller> ().level == 2f) {
			Application.LoadLevel("L03_W01");
		}
		if (player.GetComponent<playercontroller> ().level == 3f) {
			Application.LoadLevel("L01_W02");
		}


		if (player.GetComponent<playercontroller> ().level == 4f) {
			Application.LoadLevel("L02_W02");
		}
		if (player.GetComponent<playercontroller> ().level == 5f) {
			Application.LoadLevel("L03_W02");
		}
		if (player.GetComponent<playercontroller> ().level == 6f) {
			Application.LoadLevel("L01_W03");
		}

		if (player.GetComponent<playercontroller> ().level == 7f) {
			Application.LoadLevel("L02_W03");
		}
		if (player.GetComponent<playercontroller> ().level == 8f) {
			Application.LoadLevel("L03_W03");
		}


	}
	public void LevelSelect(){
		Application.LoadLevel("MainMenu");

		
	}


}
