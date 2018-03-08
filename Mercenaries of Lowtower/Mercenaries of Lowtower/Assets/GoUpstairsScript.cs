using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoUpstairsScript : MonoBehaviour {

    public int playerCount;
    public Text text;
    public int playersReady;

	// Use this for initialization
	void Start () {
        playerCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        playersReady = 4 - playerCount;
        print(playersReady);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            playerCount += 1;
            if (playerCount == 4)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //print("something has entered" + playerCount + "more players needed");
        text.text = playersReady + " more players needed to start the game.";
    }
    private void OnTriggerExit(Collider other)
    {
        text.text = playersReady + " more players needed to start the game.";
        if (other.tag=="Player")
        {
            playerCount -= 1;
        }
    }
}
