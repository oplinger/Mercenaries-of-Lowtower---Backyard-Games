using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoUpstairsScript : MonoBehaviour {

    public int playerCount;

	// Use this for initialization
	void Start () {
        playerCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        print("something has entered");
        if (other.tag=="Player")
        {
            playerCount += 1;
            if (playerCount == 4)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            playerCount -= 1;
        }
    }
}
