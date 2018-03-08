using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreenBoss : MonoBehaviour {

    public GameObject logo;
    int counter;

	// Use this for initialization
	void Start () {
        counter = 0;
		
	}
	
	// Update is called once per frame
	void Update () {

        counter++;

        float scale = 2 + Mathf.PingPong(Time.time/1.5f, 1);
        logo.transform.localScale = new Vector3(scale, scale, scale);

        if (counter >=120)
        {
            //print("scene done loading");
            SceneManager.LoadScene(1);
        }

    }
}
