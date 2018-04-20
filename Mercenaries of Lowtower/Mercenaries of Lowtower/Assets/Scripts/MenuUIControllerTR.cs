using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIControllerTR : MonoBehaviour {
    
    public GameObject gamePaused;
    public GameObject startToResume;
    public GameObject quitGameImage;

    public bool gameIsPaused;
    public bool pauseDisabled;

    // Use this for initialization
    void Start () {
        
        
        gameIsPaused = false;

        gamePaused.SetActive(false);
        startToResume.SetActive(false);

        pauseDisabled = false;

    }

    // Update is called once per frame
    void Update () {

        //CHEAT TO RETURN TO LOBBY
        if (gameIsPaused && Input.GetKey("joystick button 4") && Input.GetKey("joystick button 5") && Input.GetKey("joystick button 0"))
        {

            Application.Quit();
            Time.timeScale = 1;
            //SceneManager.LoadScene(1);
        }

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
                quitGameImage.SetActive(true);
            }

            else
            {
                print("game unpaused");
                gameIsPaused = false;
                Time.timeScale = 1;
                gamePaused.SetActive(false);
                startToResume.SetActive(false);
                quitGameImage.SetActive(false);
            }

            
        }

    }
}
