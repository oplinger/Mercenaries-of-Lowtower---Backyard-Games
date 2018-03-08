using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour {

    public GameObject winScreen;
    public GameObject bossManager;
    public BossControlScript bossManagerScript;

    // Use this for initialization
    void Start () {

        winScreen.SetActive(false);

        bossManagerScript = bossManager.GetComponent<BossControlScript>();


    }

    // Update is called once per frame
    void Update () {


        if (bossManagerScript.bossPhase == 8)
        {
            winScreen.SetActive(true);

            if ((Input.GetKeyDown("joystick button 7")))
            {
                print("game restarted");
            }
        }

    }
}
