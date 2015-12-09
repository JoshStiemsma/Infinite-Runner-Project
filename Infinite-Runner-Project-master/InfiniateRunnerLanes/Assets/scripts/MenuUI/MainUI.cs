using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MainUI : MonoBehaviour
{
    private GameObject player;

    void start()
    {
        player = GameObject.Find("player");

    }
    public void Reset()
    {
        player.GetComponent<playercontroller>().ResetLevel();

    }
}
