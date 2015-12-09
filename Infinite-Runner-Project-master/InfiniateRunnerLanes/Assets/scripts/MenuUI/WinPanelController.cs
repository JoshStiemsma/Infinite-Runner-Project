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
        Hide();
    }
	
	// Update is called once per frame
	void Update () {
		gameWon = player.GetComponent<playercontroller> ().gameWon;


		if (gameWon == true) {
            Show();

			timeText.text = Time.time.ToString();
		}
       // else {
       // Hide();
		//}
	}
    /// <summary>
    /// Next Level Button desicion
    /// </summary>
	public void NextLevel() {
        Time.timeScale = 1;
        if (player.GetComponent<playercontroller>().world == 1f)
        {
            if (player.GetComponent<playercontroller>().level == 1f)
            {
                Application.LoadLevel("W01_L02");
            }
            else if (player.GetComponent<playercontroller>().level == 2f)
            {
                Application.LoadLevel("W01_L03");
            }
            else if (player.GetComponent<playercontroller>().level == 3f)
            {
                Application.LoadLevel("W02_L01");
            }
        }
        else if (player.GetComponent<playercontroller>().world == 2f)
        {

            if (player.GetComponent<playercontroller>().level == 1f)
            {
                Application.LoadLevel("W02_L02");
            }
            if (player.GetComponent<playercontroller>().level == 2f)
            {
                Application.LoadLevel("W02_L03");
            }
            if (player.GetComponent<playercontroller>().level == 3f)
            {
                Application.LoadLevel("W03_L01");
            }
        }
        else if (player.GetComponent<playercontroller>().world == 3f)
        {
            if (player.GetComponent<playercontroller>().level == 1f)
            {
                Application.LoadLevel("W03_L02");
            }
            if (player.GetComponent<playercontroller>().level == 2f)
            {
                Application.LoadLevel("W03_L03");
            }
        }//End world

	}//End next level function

   /// <summary>
   /// Back to main menu  level selection
   /// </summary>
	public void LevelSelect(){
		Application.LoadLevel("MainMenu");

		
	}


    /// <summary>
    /// Reset by calling reset on playercontroller and hiding win panel
    /// </summary>
    public void Reset()
    {
        Debug.Log("reset via win");
        Hide();
        player.GetComponent<playercontroller>().ResetLevel();


    }
    /// <summary>
    /// Hide Win panel
    /// </summary>
    void Hide()
    {
        Debug.Log("HidePAnel");
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    /// <summary>
    /// Show Win Panel
    /// </summary>
    void Show()
    {
        Debug.Log("ShowPAnel");
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
