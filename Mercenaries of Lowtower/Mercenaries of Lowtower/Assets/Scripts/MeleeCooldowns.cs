using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCooldowns : MonoBehaviour {

    public Dictionary<string, float> cooldowns = new Dictionary<string, float>();
    public uint abilitynum;
    public float lungeCD;
    public float meleeCD;
    float[] CDvalues;
    List<string> keys;



    private void Awake()
    {
        abilitynum = 4;
        CDvalues = new float[abilitynum];


        cooldowns.Add("lungeCD", lungeCD);
        CDvalues[0] = cooldowns["lungeCD"];
        cooldowns.Add("meleeCD", meleeCD);
        CDvalues[1] = meleeCD;
        keys = new List<string>(cooldowns.Keys);



    }

    private void Update()
    {

        foreach (string key in keys)
        {
            if (cooldowns[key] >= 0)
            {
                cooldowns[key] -= Time.deltaTime;
                print(cooldowns[key]);
            }
            
        }

    }

}
