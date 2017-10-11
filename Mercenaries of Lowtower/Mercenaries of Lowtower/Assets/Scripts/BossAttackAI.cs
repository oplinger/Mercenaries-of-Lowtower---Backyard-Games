using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackAI : MonoBehaviour {
    public float[] attackCDs;
    BossTargetingAI targeting;
    BossMovementAI range;
   public float currentGCD;
    float maxGCD;

    //Reference to the animator for the boss
    Animator anim;

    //Int to change the animators bossPhase parameter
    // bossPhase = 0 is the default phase
    // bossPhase = 1 is the PrepPunch phase
    // bossPhase = 2 is the ReleasePunch phase
    // bossPhase = 3 is the PrepSpin phase
    // bossPhase = 4 is the ReleaseSpin phase
    // bossPhase = 5 is the prepSlam phase
    // bossPhase = 6 is the ReleaseSlam phase
    public int bossPhase;


    // At the start, initializes an array for each attack to have their own Cooldowns(CDs)
    // Also pulls targeting and movement information.
    // Hardcoded coodlown values for testing. Change or make variables (see below)
    void Start () {
        attackCDs = new float[4];
        targeting = GetComponent<BossTargetingAI>();
        range = GetComponent<BossMovementAI>();
        anim = GetComponent<Animator>();

        attackCDs[0] = 10;
        attackCDs[1] = 8;
        attackCDs[2] = 5;
        attackCDs[3] = 2;
    }

    // Each CD ticks down every frame.
    void Update () {
        currentGCD += Time.deltaTime;

        for (int i = 0; i < attackCDs.Length; i++)
        {
            attackCDs[i] -= Time.deltaTime;
        }


        // If the Global Cool Down (GCD) is finished, boss loops through attack priority
        if (currentGCD >= maxGCD)
        {
            checkAttacks();
            
        }

        // Sets the boss phase parameter in the animator equal to the bossPhase integer
        anim.SetInteger("bossPhase", bossPhase);
    }
    // attack one, use this as a template. When attack1 happens, it needs a target passed into it.
    // Finds the health script of the target, sends damage and ID I gave the boss an ID of 9, but the ID doesn't matter as it has no threat.
    // Then it resets the CD of the attack, and triggers the GCD so the boss will not attack for whatever value is placed there. For cinematic attacks, or waits for animations.
    void Storm(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(20, 9);
        attackCDs[0] = 10;
        triggerGCD(2);
    }

    void Slam(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(10, 9);
        attackCDs[1] = 8;
        triggerGCD(2);
    }

    void Swipe(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(5, 9);
        attackCDs[2] = 5;
        triggerGCD(2);
    }
    
    void Punch(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(1, 9);
        attackCDs[3] = 1;
        triggerGCD(1);

        /*
         
        **********QUESTION**********:
         Takes awhile for the punch to go off is that because the CD or GCD?
         It takes a while because once it is in range it starts in phase 2. It also is in the "punch" method, so it is only called when punch is (the CD). Swapped the stack and adjusted the CDs.
         */

               // If the player is out of range, the boss will go into the preparing to punch animation
        if (range.inRange && bossPhase != 1)
        {
            bossPhase = 1;
        }
        // If the player is within range, the punch animation will be triggered
        else if (range.inRange && bossPhase != 2)
        {
            bossPhase = 2;
        }
 

    }
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    // Method that loops through each attack and checks if they are on cooldown. //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    // since it checks in order, if they aren't in order of priority, it will use whatever attack has the faster CD. //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    void checkAttacks()
    {
        //if (attackCDs[0] <= 0 && range.inRange)
        //{
        //    Storm(targeting.currentTarget);

        //} else if (attackCDs[1] <= 0 && range.inRange)
        //{
        //    Slam(targeting.currentTarget);
        //}
        // else if (attackCDs[2] <= 0 && range.inRange)
        //{
        //    Swipe(targeting.currentTarget);
        //}
        // else 
        if (attackCDs[3] <= 0 && range.inRange)
        {
            Punch(targeting.currentTarget);
        }
    }
    // triggers the GCD, this method can be triggered with any value to wait for animations or anything else.
    void triggerGCD(float cooldownTime)
    {
        currentGCD = 0;
        maxGCD = cooldownTime;
    }
}

