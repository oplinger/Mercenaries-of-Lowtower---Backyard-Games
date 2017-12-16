using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerClass : EntityClass
{
    public int CTRLID;
    protected GameObject controllerThing;
    protected ControllerThing controller;
    protected PlayerAbilityController abilities;
    protected PlayerCDController cooldowns;
    protected Collider[] colliders;
    protected Animator anim;

    protected Hashtable buttons;

    protected float walkspeed;
    protected float jumpHeight;
    protected LayerMask groundMask;
    protected LayerMask enemyMask;
    protected Material playerMat;
    protected float reviveRadius;
    protected float reviveCastTime;

    protected delegate void ButtonA();
    protected delegate void ButtonB();
    protected delegate void ButtonX();
    protected delegate void ButtonY();
    protected delegate void ButtonRB();
    protected delegate void ButtonLB();
    protected delegate void ButtonRT();
    protected delegate void ButtonLT();
    protected delegate void ButtonStart();
    protected delegate void ButtonBack();

    protected delegate void Ability1();
    protected delegate void Ability2();
    protected delegate void Ability3();

    protected ButtonA buttonA;
    protected ButtonB buttonB;
    protected ButtonX buttonX;
    protected ButtonY buttonY;

    protected Ability1 ability1;
    protected Ability2 ability2;
    protected Ability3 ability3;




    // Use this for initialization
    void Start() {



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

    void AssignButtons()
    {

    }
}
