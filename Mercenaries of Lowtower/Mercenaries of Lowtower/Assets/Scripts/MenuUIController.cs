using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour {

    public GameObject winScreen;
    public GameObject restartButton;
    public GameObject gamePaused;
    public GameObject startToResume;

    public GameObject loseScreen;
    public GameObject startToRetry;

    public GameObject bossManager;
    public BossControlScriptV2 bossManagerScript;

    public bool gameIsPaused;
    public bool pauseDisabled;

    public TankClass tankScript;
    public HealerClass healerScript;
    public MeleeClass meleeScript;
    public RangedClass rangedScript;

    // Use this for initialization
    void Start () {

        //winScreen.SetActive(false);

        bossManagerScript = bossManager.GetComponent<BossControlScriptV2>();
        gameIsPaused = false;

        gamePaused.SetActive(false);
        startToResume.SetActive(false);
        
        loseScreen.SetActive(false);
        startToRetry.SetActive(false);

        pauseDisabled = false;

        //tankScript = GameObject.Find("Tank Character(Clone)").GetComponent<TankClass>();
        //healerScript = GameObject.Find("Healer Character(Clone)").GetComponent<HealerClass>();
        //meleeScript = GameObject.Find("Melee Character(Clone)").GetComponent<MeleeClass>();
        //rangedScript = GameObject.Find("Ranged Character(Clone)").GetComponent<RangedClass>();


    }

    // Update is called once per frame
    void Update () {

        //PAUSE GAME
        if (Input.GetKeyDown("joystick button 7") && !pauseDisabled)
        {

            if (!gameIsPaused)
            {
                print("game paused");
                gameIsPaused = true;
                Time.timeScale = 0;
                gamePaused.SetActive(true);
                startToResume.SetActive(true);
            }

            else
            {
                print("game unpaused");
                gameIsPaused = false;
                Time.timeScale = 1;
                gamePaused.SetActive(false);
                startToResume.SetActive(false);
            }

            
        }

        //restarts boss scene if Back button is pressed while pause menu is up
        if (gameIsPaused && Input.GetKeyDown("joystick button 6"))
        {

            Time.timeScale = 1;
            print("restart scene");
            SceneManager.LoadScene(1);
        }





        //WIN THE GAME 

        if (bossManagerScript.bossPhase == 7)
        {
            winScreen.SetActive(true);
            restartButton.SetActive(true);
            float scale = .22f + Mathf.PingPong(Time.time/18, .15f);
            winScreen.transform.localScale = new Vector3(scale,scale,scale);

            pauseDisabled = true;

            if ((Input.GetKeyDown("joystick button 7")))
            {
                print("game restarted");
            }

       
        }

        //LOSE THE GAME

        if (tankScript.currentHealth<=0 && healerScript.currentHealth<=0 && meleeScript.currentHealth<=0 && rangedScript.currentHealth<=0)
        {
            loseScreen.SetActive(true);
            startToRetry.SetActive(true);
            float scale = .22f + Mathf.PingPong(Time.time / 18, .15f);
            loseScreen.transform.localScale = new Vector3(scale, scale, scale);

            pauseDisabled = true;

            if ((Input.GetKeyDown("joystick button 7")))
            {
                print("game restarted");
            }
        }

    }
}
