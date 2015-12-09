using UnityEngine;
using System.Collections;

public class BackgroundMusicController : MonoBehaviour {
    private float volume;
    public bool mainmenu;

    private GameObject player;

    
    private bool playerAlive;
    public bool Damper;
    private Component audiosource;
    // Use this for initialization
    void Start () {
 
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        player = GameObject.Find("player");
        if (player != null)
        {
            playerAlive = player.GetComponent<playercontroller>().playerAlive;
            if (playerAlive == false)
            {
                Damper = true;
            }
            else
            {
                Damper = false;
            }
        }else
        {
            if (mainmenu == true)
            {
                Damper = true;

            }
            else
            {
                Damper = false;
            }
        }

        if (Damper == true)
        {
            float newVol = AudioListener.volume/2;
            audiosource.GetComponent<AudioSource>().volume = .5f;
        }
        else
        {
            audiosource.GetComponent<AudioSource>().volume = 1;

        }
    }
}
