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
		if (player.GetComponent<playercontroller> ().level == 1.1f) {
			Application.LoadLevel("Level02World01");
		}
		if (player.GetComponent<playercontroller> ().level == 1.2f) {
			Application.LoadLevel("Level03World01");
		}
		if (player.GetComponent<playercontroller> ().level == 1.3f) {
			Application.LoadLevel("Level01World02");
		}


		if (player.GetComponent<playercontroller> ().level == 2.1f) {
			Application.LoadLevel("Level02World02");
		}
		if (player.GetComponent<playercontroller> ().level == 2.2f) {
			Application.LoadLevel("Level03World02");
		}
		if (player.GetComponent<playercontroller> ().level == 2.3f) {
			Application.LoadLevel("Level01World03");
		}

		if (player.GetComponent<playercontroller> ().level == 3.1f) {
			Application.LoadLevel("Level02World03");
		}
		if (player.GetComponent<playercontroller> ().level == 2.2f) {
			Application.LoadLevel("Level03World03");
		}


	}
	public void LevelSelect(){
		Application.LoadLevel("MainMenu");

		
	}


}
