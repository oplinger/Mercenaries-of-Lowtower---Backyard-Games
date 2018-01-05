using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerCooldowns : MonoBehaviour
{

    public Dictionary<string, float> cooldowns = new Dictionary<string, float>();
    public uint abilitynum;
    public float healCD;
    public float teleportCD;
    float[] CDvalues;
    List<string> keys;



    private void Awake()
    {
        abilitynum = 4;
        CDvalues = new float[abilitynum];


        cooldowns.Add("healCD", healCD);
        CDvalues[0] = cooldowns["healCD"];
        cooldowns.Add("teleportCD", teleportCD);
        CDvalues[1] = cooldowns["teleportCD"];
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
