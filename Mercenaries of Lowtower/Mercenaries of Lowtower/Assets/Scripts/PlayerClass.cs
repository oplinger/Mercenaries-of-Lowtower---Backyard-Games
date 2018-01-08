using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerClass : EntityClass
{
    public int CTRLID;
    protected GameObject controllerThing;
    public PlayerControls controller;
    protected Collider[] colliders;
    protected Animator anim;
    protected Vector3 _movement;
    protected SOcontrols controls;

    protected Hashtable buttons;

    protected float walkspeed;
    protected float jumpheight;
    protected LayerMask groundMask;
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
    void Awake() {

        buttonA = buttonAfunction;
        buttonB = buttonBfunction;
        buttonX = buttonXfunction;
        buttonY = buttonYfunction;

        walkspeed = 10;
        controller = GameObject.Find("Controller Thing").GetComponent<PlayerControls>();
        buttons = new Hashtable();
        AssignButtons();

    }
    private void Start()
    {
        controls.Init();
        print(controls.ControlArrays[0, 0]);
    }

    // Update is called once per frame

    public int JumpCheck()
    {
        Debug.DrawRay(transform.position, Vector3.up * -1f);
        colliders = Physics.OverlapCapsule(transform.position, transform.position + (Vector3.up * -2f), .25f, groundMask, QueryTriggerInteraction.Ignore);
        int length;
        length = colliders.Length;
        return length;
    }

    public void Jump()
    {
        GetComponent<Rigidbody>().AddForce(0, jumpheight, 0, ForceMode.Impulse);
    }

    public void Movement()
    {
        if (walkspeed >= 0 && CTRLID != 0)
        {
            _movement = new Vector3(Input.GetAxis("J" + CTRLID + "Horizontal"), 0, Input.GetAxis("J" + CTRLID + "Vertical"));
            if (_movement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(_movement);
                transform.Translate(_movement * walkspeed * Time.deltaTime, Space.World);
                //anim.SetInteger("AnimState", 1);
            }
            else
            {
            }
        }
    }

    public void Revive()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, reviveRadius, 1 << 8, QueryTriggerInteraction.Ignore);
        for (int i = 0; i < col.Length; i++)
        {
            print(col[i]);
        }
        Health colhealth = col[0].GetComponent<Health>();
        GameObject coltarget = col[0].gameObject;
        //PlayerID needs to change to some sort of classID
        if (colhealth.isDead)
        {
            colhealth.health = colhealth.maxHealth / 2;
            colhealth.isDead = false;
            if (coltarget.name == "Tank Character")
            {
                coltarget.GetComponent<TankController>().walkspeed = 10;
            }
            if (coltarget.name == "Melee Character")
            {
                coltarget.GetComponent<MeleeController>().walkspeed = 10;
            }
            if (coltarget.name == "Ranged Character")
            {
                coltarget.GetComponent<RangedController>().walkspeed = 10;
            }
            if (coltarget.name == "Healer Character")
            {
                coltarget.GetComponent<HealerController>().walkspeed = 10;
            }

        }
        //else if (playerID == 1 && colhealth.isDead)
        //{
        //    colhealth.health = colhealth.maxHealth;
        //    colhealth.isDead = false;
        //    if (coltarget.name == "Tank Character")
        //    {
        //        coltarget.GetComponent<TankController>().walkspeed = 10;
        //    }
        //    if (coltarget.name == "Melee Character")
        //    {
        //        coltarget.GetComponent<MeleeController>().walkspeed = 10;
        //    }
        //    if (coltarget.name == "Ranged Character")
        //    {
        //        coltarget.GetComponent<RangedController>().walkspeed = 10;
        //    }
        //    if (coltarget.name == "Healer Character")
        //    {
        //        coltarget.GetComponent<HealerController>().walkspeed = 10;
        //    }
        //}
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

     public void AssignButtons()
    {

        buttons.Add("Abutton", 0);
        buttons.Add("Bbutton", 1);
        buttons.Add("Xbutton", 2);
        buttons.Add("Ybutton", 3);
    }
}
