using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoystickPollingScript : MonoBehaviour {

    public GameObject controllerThing;

    // Use this for initialization
    void Start () {
        controllerThing = GameObject.Find("Controller Thing");

    }

    // Update is called once per frame
    void Update () {

        for (int i = 1; i < 5; i++)
        {
            if (Input.GetKeyDown("joystick " + i + " button 7"))
            {

                print("joystick " + i + " button 7");
               ControllerThing CT = controllerThing.GetComponent<ControllerThing>();
                CT.AssignIDsToArray(i);


            }
        }

    }
}
