using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    public List<int> PID;
    public GameObject[] players; 
    SOcontrols controls;


    // Use this for initialization
    void Awake () {
        players[0] = GameObject.Find("Tank Character(Clone)");
        players[1] = GameObject.Find("Healer Character(Clone)");
        players[2] = GameObject.Find("Melee Character(Clone)");
        players[3] = GameObject.Find("Ranged Character(Clone)");

    }

    // Update is called once per frame
    void Update () {
        if (PID.Contains(9))
        {
            for (int i = 1; i < 4; i++)
            {
                if (Input.GetKeyDown("joystick " + i + " button 7"))
                {
                    print("joystick " + i + " button 7");
                    AssignIDsToArray(i);
                }
            }
        }
    }

    // PID = controller ID, index of PID=player ID
    // ex: joystick 1 button 0, 1 is the controller ID use that for inputs. 1 is at index 2, so controller 1 is player 3.
   void AssignIDsToArray(int ID)
    {
        //targets = IDs;
        for (int i = 0; i < 4; i++)
        {
            if (PID[i] == ID)
            {
                break;
            }
            else if (PID[i] == 9)
            {

                PID[i] = ID;
                // Andrew says look here for input bug
                //PID[i] = ID;

                //PID.Insert(i, ID);
                //PID.RemoveAt(PID.Count - 1);

                break;
            }
        }
    }

    //public void AssignIDsToArray(int ID)
    //{
    //    //targets = IDs;
    //    for (int i = 0; i < 4; i++)
    //    {
    //        if (PID[i] == ID)
    //        {
    //            break;
    //        }
    //        else if (PID[i] == 9)
    //        {
    //            // Andrew says look here for input bug
    //            PID[i] = ID;

    //            //PID.Insert(i, ID);
    //            //PID.RemoveAt(PID.Count - 1);

    //            break;
    //        }
    //    }
    //    //PID.Add(ID);
    //}
}
