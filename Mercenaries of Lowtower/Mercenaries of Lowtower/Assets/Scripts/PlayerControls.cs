using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    public List<int> PID;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (PID.Count < 5)
        {
            for (int i = 1; i < 5; i++)
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
            else 
            {

                PID.Add(i);
                // Andrew says look here for input bug
                //PID[i] = ID;

                //PID.Insert(i, ID);
                //PID.RemoveAt(PID.Count - 1);

                break;
            }
        }
    }
}
