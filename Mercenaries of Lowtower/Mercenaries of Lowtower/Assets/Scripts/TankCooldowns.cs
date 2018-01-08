using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCooldowns : MonoBehaviour
{

    public Dictionary<string, float> cooldowns = new Dictionary<string, float>();
    public uint abilitynum;
    public float shieldCD;
    public float magnetCD;
    float[] CDvalues;
    List<string> keys;



    private void Awake()
    {
        abilitynum = 4;
        CDvalues = new float[abilitynum];


        cooldowns.Add("shieldCD", shieldCD);
        CDvalues[0] = cooldowns["shieldCD"];
        cooldowns.Add("magnetCD", magnetCD);
        CDvalues[1] = cooldowns["magnetCD"];
        keys = new List<string>(cooldowns.Keys);



    }

    private void Update()
    {

        foreach (string key in keys)
        {
            if (cooldowns[key] >= 0)
            {
                cooldowns[key] -= Time.deltaTime;
                //print(cooldowns[key]);
            }

        }

    }

}
