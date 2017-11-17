using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedController : MonoBehaviour
{
    #region Variables
    [HideInInspector]    
    public int CTRLID;
    GameObject controllerThing;
    Vector3 playermovement;
    ControllerThing controller;
    PlayerAbilityController abilities;
    PlayerCDController cooldowns;
    bool visual;    
    Collider[] colliders;
    float damageMult = 1;
    bool altBuild;
    float timer1;


    [Header("General")]
    [Range(1,50)]
    public float walkspeed;
    public LayerMask groundMask;
    public LayerMask enemyMask;
    public Material rangedMat;
    public float reviveRadius;




    [Space(10)]
    [Header("Damage")]
    public float damageMultCap =3;
    public float arrowDamage = 5;
    public float boltDamage = 25;

    [Space(10)]
    [Header("Cooldowns")]
    [Range(0, 10)]
    public float sniperAttackCD;
    [Range(0, 10)]
    public float archerAttackCD;
    [Range(0, 10)]
    public float smokeBombCD;
    [Range(0, 10)]
    public float KnockbackCD;
    public float reviveCastTime;


    Animator anim;
    Health health;
    float h1;
    float h2;
    #endregion
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        controllerThing = GameObject.Find("Controller Thing");
        controller = controllerThing.GetComponent<ControllerThing>();
        abilities = controllerThing.GetComponent<PlayerAbilityController>();
        cooldowns = controllerThing.GetComponent<PlayerCDController>();
        LineOfFireVisual line = GetComponent<LineOfFireVisual>();
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
        h2 = health.health;
    }

    /*
     AnimStates
     0 = idle
     1 = Walk
     2 = Attack
     3= Jump
     4 = GetHurt
     5= Death
         */
    void Update()
    {
        if (altBuild)
        {
            rangedMat.color = Color.HSVToRGB(.216f, .517f, .5f);


        }
        else
        {
            rangedMat.color = Color.HSVToRGB(.216f, .517f, .95f);
            
        }
        anim.SetInteger("AnimState", 0);

        // colliders is for grounding the player, for jumping purposes.
        colliders = Physics.OverlapCapsule(transform.position, transform.position-(Vector3.up*2), .25f, groundMask, QueryTriggerInteraction.Ignore);
        h1 = health.health;
        #region Controls
        if (walkspeed >= 0 && CTRLID != 0 && !health.isDead)
        {
            playermovement = new Vector3(Input.GetAxis("J" + CTRLID + "Horizontal"), 0, Input.GetAxis("J" + CTRLID + "Vertical"));
            if (playermovement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(playermovement);
                transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
                anim.SetInteger("AnimState", 1);
            }
            else
            {
            }
        }
        

        if (CTRLID != 0 && colliders.Length>0 && Input.GetKeyDown("joystick " + CTRLID + " button 0") && !health.isDead)
        {
            abilities.Jump(CTRLID, gameObject);
            anim.SetInteger("AnimState", 3);
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 3") && !health.isDead)
        {
            timer1 += Time.deltaTime;
            if (timer1 > reviveCastTime)
            {
                abilities.Revive(1, gameObject, reviveRadius);

            }
        }
        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 3") && !health.isDead)
        {
            reviveCastTime = 0;
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[11] <= 0 && altBuild && !health.isDead)
        {
            abilities.BluntTipArrow(3, 3, gameObject, KnockbackCD);
            anim.SetInteger("AnimState", 2);
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[10] <= 0 && !altBuild && !health.isDead)
        {
            abilities.SmokeBomb(0, 3, gameObject, smokeBombCD);
            anim.SetInteger("AnimState", 2);
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[9] <= 0 && !health.isDead)
        {
            visual = true;
            GetComponent<LineOfFireVisual>().OnBool(visual);

        }

        if (CTRLID != 0 && Input.GetKey("joystick " + CTRLID + " button 2" ) && altBuild && !health.isDead)
        {
            
            damageMult = Mathf.Clamp(damageMult+=(Time.deltaTime*2), 1, damageMultCap);

        }





        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[9] <= 0 && altBuild && !health.isDead)
        {
            visual = false;
            GetComponent<LineOfFireVisual>().OnBool(visual);
            abilities.RangedArrow(5 * damageMult, 3, gameObject, archerAttackCD);
            anim.SetInteger("AnimState", 2);
            damageMult = 1;
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[9] <= 0 && !altBuild && !health.isDead)
        {
            visual = false;
            GetComponent<LineOfFireVisual>().OnBool(visual);
            abilities.RangedBolt(25, 3, gameObject, sniperAttackCD);
            anim.SetInteger("AnimState", 2);
        }
        else
        {
        }



        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 5"))
        {
            altBuild = !altBuild;
        }
        #endregion
        #region Health and Death

        if (h1 < h2)
        {
            anim.SetInteger("AnimState", 1);
            h2 = h1;
        }
        else
        {
        }

        if (health.isDead)
        {
            anim.SetInteger("AnimState", 5);
            walkspeed = 0;
            playermovement *= 0;
        }
        else
        {
            walkspeed = 10;

        }
        #endregion
    }
}