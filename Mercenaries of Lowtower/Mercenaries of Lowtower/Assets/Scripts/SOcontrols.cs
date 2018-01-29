using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOcontrols : ScriptableObject {

    public string[,] ControlArrays;


    public void Init()
    {
        ControlArrays[0,0] = "button 0";
        ControlArrays[0,1] = "button 1";
        ControlArrays[0,2] = "button 2";
        ControlArrays[0,3] = "button 3";
        ControlArrays[1,0] = "button 0";
        ControlArrays[1,1] = "button 1";
        ControlArrays[1,2] = "button 2";
        ControlArrays[1,3] = "button 3";
        ControlArrays[2,0] = "button 0";
        ControlArrays[2,1] = "button 1";
        ControlArrays[2,2] = "button 2";
        ControlArrays[2,3] = "button 3";
        ControlArrays[3,0] = "button 0";
        ControlArrays[3,1] = "button 1";
        ControlArrays[3,2] = "button 2";
        ControlArrays[3,3] = "button 3";

    }
}
