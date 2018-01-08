using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedCooldowns : MonoBehaviour
{

    public Dictionary<string, float> cooldowns = new Dictionary<string, float>();
    public uint abilitynum;
    public float boltCD;
    public float knockbackCD;
    float[] CDvalues;
    List<string> keys;



    private void Awake()
    {
        abilitynum = 4;
        CDvalues = new float[abilitynum];


        cooldowns.Add("boltCD", boltCD);
        CDvalues[0] = cooldowns["boltCD"];
        cooldowns.Add("knockbackCD", knockbackCD);
        CDvalues[1] = cooldowns["knockbackCD"];
        keys = new List<string>(cooldowns.Keys);



    }

    private void Update()
    {

        foreach (string key in keys)
        {
            if (cooldowns[key] >= 0)
            {
                cooldowns[key] -= Time.deltaTime;
               // print(cooldowns[key]);
            }

        }

    }

}
