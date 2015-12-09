using UnityEngine;
using System.Collections;

public class DeathPanel : MonoBehaviour {
    private GameObject player;

    private float playerHealth;

    private bool playerAlive = true;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("player");
        playerHealth = player.GetComponent<playercontroller>().health;


    }
	
	// Update is called once per frame
	void Update () {
        playerHealth = player.GetComponent<playercontroller>().health;
        if (playerHealth <= 0)
        {
            GetComponent<CanvasGroup>().alpha = 1;
            GetComponent<CanvasGroup>().interactable = true;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = 0;
            GetComponent<CanvasGroup>().interactable = false;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
    public void Reset()
    {
        player.GetComponent<playercontroller>().ResetLevel();

    }


}
