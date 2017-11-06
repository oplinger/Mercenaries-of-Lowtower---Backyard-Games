using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    #region Variables
    GameObject controllerThing;
    Vector3 playermovement;
    public float walkspeed;
    ControllerThing controller;
    public int CTRLID;
    PlayerAbilityController abilities;
    PlayerCDController cooldowns;
    LayerMask lMask;
    Collider[] colliders;
    bool visual;
    GameObject hitbox;
    MeleeTargetList mTarList;
    int attacknum;
    float timer;
    bool altBuild;
    [Space(10)]
    [Header("Cooldowns")]
    [Range(0,10)]
    public float berserkerMeleeAttackCD;
    [Range(0, 10)]
    public float rogueMeleeAttackCD;
    [Range(0, 10)]
    public float lungeCD;
    [Range(0, 10)]
    public float CycloneCD;

    Animator anim;
    Health health;
    float h1;
    float h2;
    #endregion

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (controllerThing == null)
        {
            controllerThing = GameObject.Find("Controller Thing");
        }

        controller = controllerThing.GetComponent<ControllerThing>();
        abilities = controllerThing.GetComponent<PlayerAbilityController>();
        cooldowns = controllerThing.GetComponent<PlayerCDController>();
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
        h2 = health.health;
        hitbox = GameObject.Find("Cone");

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
        anim.SetInteger("AnimState", 0);
        timer += Time.deltaTime;
        if (timer > 2)
        {
            attacknum = 0;
            
        }

        // colliders is for grounding the player, for jumping purposes.
        colliders = Physics.OverlapCapsule(transform.position, transform.position - (Vector3.up * 2), .25f, lMask, QueryTriggerInteraction.Ignore);
        h1 = health.health;
        #region Controls
        if (walkspeed >= 0 && CTRLID != 0)
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

        if (CTRLID != 0 && colliders.Length > 0 && Input.GetKeyDown("joystick " + CTRLID + " button 0"))
        {
            abilities.Jump(CTRLID, gameObject);
            anim.SetInteger("AnimState", 3);
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[7] <= 0 && altBuild)
        {
            abilities.MeleeLunge(5, 2, gameObject, lungeCD);
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 1") && cooldowns.activeCooldowns[7] <= 0)
        {
            abilities.Whirlwind(5, 2, gameObject, lungeCD);
        }

        if (CTRLID != 0 && Input.GetKeyDown("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[6] <= 0)
        {
            visual = true;
            GetComponent<MeleeVisualization>().OnBool(visual);
        }

        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[6] <= 0)
        {

            visual = false;
            GetComponent<MeleeVisualization>().OnBool(visual);
            attacknum++;
            if (hitbox.GetComponent<MeleeTargetList>().mTar.Count > 0)
            {
                timer = 0;
            }
            abilities.MeleeStrikeBerserker(5, 2, gameObject, hitbox.GetComponent<MeleeTargetList>().mTar, attacknum, berserkerMeleeAttackCD);
            anim.SetInteger("AnimState", 2);
        }
        else
        {
        }

        if (CTRLID != 0 && Input.GetKeyUp("joystick " + CTRLID + " button 2") && cooldowns.activeCooldowns[6] <= 0 && altBuild)
        {

            visual = false;
            GetComponent<MeleeVisualization>().OnBool(visual);
            attacknum++;
            if (hitbox.GetComponent<MeleeTargetList>().mTar.Count > 0)
            {
                timer = 0;
            }
            abilities.MeleeStrikeRogue(5, 2, gameObject, hitbox.GetComponent<MeleeTargetList>().mTar, attacknum, rogueMeleeAttackCD);
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
            anim.SetInteger("AnimState", 4);
            h2 = h1;
        }
        else
        {
        }

        if (h1 <= 0)
        {
            anim.SetInteger("AnimState", 5);
            walkspeed = 0;
        }
        else
        {
        }
        #endregion
    }
}
