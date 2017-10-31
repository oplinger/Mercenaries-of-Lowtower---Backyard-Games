using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCDController : MonoBehaviour {
   public float[] activeCooldowns;
    public float[] abilityCooldowns;
	// Use this for initialization
	void Start () {
	}

    /*Tracks all cooldowns from all characters in an array and sends that data to the character controllers, putting it all in one place helps us track and manipulate CDs on the fly
     
        POSSIBLY TRY DICTIONARIES INSTEAD OF ARRAYS. CAN NAME INDEX VALUES TO BETTER TRACK WHAT ABILITY IS WHAT

        0-2 Tank abilities
        3-5 Healer abilities
        6-8 Melee abilities
        9-11 Ranged abilities


        Ability Cooldowns are the static CD value of the ability. Active cooldowns are the current cooldown that ticks down after use.
         
         */

       
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
