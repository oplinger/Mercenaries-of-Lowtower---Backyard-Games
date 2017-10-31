using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoystickPollingScript : MonoBehaviour {

    public GameObject controller;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        for (int i = 1; i < 5; i++)
        {
            if (Input.GetKeyDown("joystick " + i + " button 7"))
            {

                print("joystick " + i + " button 7");
               ControllerThing CT = controller.GetComponent<ControllerThing>();
                CT.AssignIDsToArray(i);


            }
        }

    }
}
