using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCooldowns : MonoBehaviour {

    Hashtable cooldowns;
    float[] CDvalues;
    public uint abilitynum;
    public float lungeCD;
    int[,] intstuff;
    static int[][] intstuffinintstuff;
    

    private void Awake()
    {
        intstuff[1, 1] = 5;
        intstuff[1, 2] = 4;
        intstuffinintstuff[1][1] = 12;
        abilitynum = 1;
        CDvalues = new float[abilitynum];
        cooldowns = new Hashtable();
        
        cooldowns.Add("lungeCD", (float)lungeCD);
        CDvalues[0] = (float)cooldowns["lungeCD"];

    }

    private void Update()
    {
        for (int i = 0; i<CDvalues.Length; i++)
        {
            if(CDvalues[i]>=0)
            CDvalues[i] -= Time.deltaTime;
        }
    }

}
