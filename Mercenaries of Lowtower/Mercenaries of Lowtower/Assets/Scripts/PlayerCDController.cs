using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCDController : MonoBehaviour {
   public float[] activeCooldowns;
    public float[] abilityCooldowns;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < activeCooldowns.Length; i++)
        {
            if (activeCooldowns[i] >= 0)
            {
                activeCooldowns[i] -= Time.deltaTime;
            }
        }

    }
    public void triggerCooldown(int AttackID, float cooldown)
    {
        activeCooldowns[AttackID] = cooldown;
    }

}
