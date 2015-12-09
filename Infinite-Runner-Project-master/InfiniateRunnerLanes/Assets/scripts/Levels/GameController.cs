using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public bool gameWon;
    public float endTime;
    /// <summary>
    /// The player.
    /// </summary>
    private GameObject player;
    private float health;
    public float playerHealth;
    private bool playerAlive = true;
    private bool inBoost;
    private float fuel;

    private float level;
    private float world;
    public GameObject Floor;

    private float pickupCount;

    public float enemyCount;//REALLY OBSTICALES 

    private float delayTimer;//Maim Delay Timer//


    private float pause = 1000000000000000000000000000000000.0f;


    private float Rand;


    void Awake()
    {
        player = GameObject.Find("player");
        Time.timeScale = 1;
        gameWon = false;
    }


    void Start()
    {
        Time.timeScale = 1;
        player = GameObject.Find("player");
       level = player.GetComponent<playercontroller>().level;
       world = player.GetComponent<playercontroller>().world;
        delayTimer = 0f;

        health = player.GetComponent<playercontroller>().health;
        pickupCount = player.GetComponent<playercontroller>().pickUpCount;

    }

   
    void FixedUpdate()
    {
        //firstFrame = true;
        if (Input.GetButtonDown("Jump") && health >= .1f && inBoost == false)
        {
            inBoost = true;
        }
        if (Input.GetButtonUp("Jump") && health >= .1f && inBoost == true)
        {
            inBoost = false;
        }

    }



    void Update()
    {

        delayTimer = delayTimer + (4 * Time.deltaTime);

        health = player.GetComponent<playercontroller>().health;
        pickupCount = player.GetComponent<playercontroller>().pickUpCount;
        playerHealth = health;

        if (health <= 0)
        {
            playerAlive = false;
            inBoost = false;
        }

        if (playerAlive == false)
        {
            if (health >= .1f && Input.GetButtonDown("Submit"))
            {
                Debug.Log("Resume enemies");
                delayTimer = 0f;
                playerAlive = true;
                Time.timeScale = 1;
            }
        }

        if (pickupCount >=4)
        {
            endTime = Time.deltaTime;
            SetLevelReached();
            PlayerData.playerData.Save();
            gameWon = true;
            Time.timeScale = 0;
            player.GetComponent<playercontroller>().gameWon = true;
        }

    }

    /// <summary>
    /// Set level reached based off the world and level
    /// </summary>
    void SetLevelReached()
    {
        if (world == 2)
        {
            if (level == 1)
            {
                if (PlayerData.playerData.levelReached <= 4)
                {
                    PlayerData.playerData.levelReached = 5;
                }
            }
            else if (level == 2)
            {
                if (PlayerData.playerData.levelReached <= 5)
                {
                    PlayerData.playerData.levelReached = 6;
                }
            }
            else if (level == 3)
            {
                if (PlayerData.playerData.levelReached <= 6)
                {
                    PlayerData.playerData.levelReached = 7;
                }
            }

        }
        else if (world == 3)
        {
            if (level == 1)
            {
                if (PlayerData.playerData.levelReached <= 7)
                {
                    PlayerData.playerData.levelReached = 8;
                }
            }
            else if (level == 2)
            {
                if (PlayerData.playerData.levelReached <= 8)
                {
                    PlayerData.playerData.levelReached = 9;
                }
            }
            else if (level == 3)
            {
                if (PlayerData.playerData.levelReached <= 9)
                {
                    PlayerData.playerData.levelReached = 10;
                }
            }

        }
    }


}