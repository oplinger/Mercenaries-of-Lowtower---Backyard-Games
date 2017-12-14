using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerClass : EntityClass
{
    public int CTRLID;
    public GameObject controllerThing;
    public ControllerThing controller;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    public Collider[] colliders;
    public Animator anim;

    public float walkspeed;
    public float jumpHeight;
    public LayerMask groundMask;
    public LayerMask enemyMask;
    public Material playerMat;
    public float reviveRadius;
    public float reviveCastTime;

    delegate void ButtonA();
    delegate void ButtonB();
    delegate void ButtonX();
    delegate void ButtonY();
    delegate void ButtonRB();
    delegate void ButtonLB();
    delegate void ButtonRT();
    delegate void ButtonLT();
    delegate void ButtonStart();
    delegate void ButtonBack();

    public delegate void Ability1();
    public delegate void Ability2();
    public delegate void Ability3();

    ButtonA buttonA;
    ButtonA buttonB;
    ButtonA buttonX;
    ButtonA buttonY;

    public Ability1 ability1;
    public Ability2 ability2;
    public Ability3 ability3;




    // Use this for initialization
    void Start() {
        buttonA = buttonAfunction;
        buttonB = buttonBfunction;
        buttonX = buttonXfunction;
        buttonY = buttonYfunction;


    }

    // Update is called once per frame
    void Update() {

    }
    public int JumpCheck()
    {
        Debug.DrawRay(transform.position, Vector3.up * -1f);
        colliders = Physics.OverlapCapsule(transform.position, transform.position + (Vector3.up * -2f), .25f, groundMask, QueryTriggerInteraction.Ignore);
        int length;
        length = colliders.Length;
        return length;
    }

    public void Jump(float jumpheight)
    {
        GetComponent<Rigidbody>().AddForce(0, jumpheight, 0, ForceMode.Impulse);
    }

    public void Movement()
    {

    }

    public void Revive()
    {

    }

    public void buttonAfunction()
    {
        ability1();
    }

    public void buttonBfunction()
    {
        ability2();
    }

    public void buttonXfunction()
    {
        ability3();
    }

    public void buttonYfunction()
    {
        Revive();
    }
}
