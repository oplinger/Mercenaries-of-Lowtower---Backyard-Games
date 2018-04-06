using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoUpstairsScript : MonoBehaviour {

    public int playerCount;
    public Text text;
    public int playersReady;
    private float timeRemaining = 10;
    public bool timer = false;
    public int counter = 0;
 
	// Use this for initialization
	void Start () {
        playerCount = 0;
                       
	}

   
	// Update is called once per frame
	void Update () {
        //timeRemaining -= Time.deltaTime;
        playersReady = 4 - playerCount;
        print(playersReady);
        if (playerCount == 0)
        {
            text.text = "ALL 4 PLAYERS PLEASE STAND" + Environment.NewLine + "ON THE STAIRS TO START";
        }
      }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            playerCount += 1;
            /*
            if (playerCount == 1 && timeRemaining > 0) //playerCount ==4
            {
              text.text = "Starting in : " +(int)timeRemaining;
                if (timeRemaining <= 0)
                {
                    SceneManager.LoadScene(1);
                    }
                 }
               }
            }
            */
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //print("something has entered" + playerCount + "more players needed");
        //text.text = playersReady + " MORE PLAYERS NEEDED" + Environment.NewLine + "TO START THE GAME.";

        if(playerCount == 4) //playerCount == 4
        {
            timeRemaining -= Time.deltaTime;
            text.text = "STARTING IN  " + (int)timeRemaining/2;
            if (timeRemaining <= 0)
            {
                BossControlScriptV2.gameRestarted = false;
                SceneManager.LoadScene(2);
            }
        }
        else
        {
            text.text = playersReady + " MORE PLAYERS NEEDED" + Environment.NewLine + "TO START THE GAME.";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        text.text = playersReady + " MORE PLAYERS NEEDED" + Environment.NewLine + "TO START THE GAME.";
        if (other.tag=="Player")
        {
            timeRemaining = 10;
            playerCount -= 1;

           
        }
    }
}
