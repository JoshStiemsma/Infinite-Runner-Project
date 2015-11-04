using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PausePanelController : MonoBehaviour {
	private GameObject player;
	private bool paused;
	public CanvasGroup PausePanel;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		paused = player.GetComponent<playercontroller> ().paused;

	}
	
	// Update is called once per frame
	void Update () {
		paused = player.GetComponent<playercontroller> ().paused;
		if (paused == true) {
			GetComponent<CanvasGroup> ().alpha = 1;
			GetComponent<CanvasGroup> ().interactable = true;
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
		} else {
			GetComponent<CanvasGroup> ().alpha = 0;
			GetComponent<CanvasGroup> ().interactable = false;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;

		}
	}
}
