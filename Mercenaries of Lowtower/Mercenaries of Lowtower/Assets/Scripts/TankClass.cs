using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TankAbilities))]
[RequireComponent(typeof(TankCooldowns))]

public class TankClass : PlayerClass
{
    public TankAbilities abilities;
    public TankCooldowns abilityCooldowns;

    [SerializeField]
    int grounded;
    public LayerMask enemyMask;
    public LayerMask lMask;
    public LayerMask shieldMask;
    [Header("Shield Settings")]
    [Range(0, 10)]
    public float shieldSize;
    public float shieldDuration;
    [Header("Magnet Settings")]
    public float magnetDistance;
    public float magnetDiameter;
    public float pullSpeed;




    // Use this for initialization
    void Start () {

        abilities = GetComponent<TankAbilities>();
        abilityCooldowns = GetComponent<TankCooldowns>();
        //Hashtable tButtons = new Hashtable(buttons);
        //buttons.Add("Abutton", 0);
        jumpheight = 10;
        ability1 = Jump;
        ability2 = abilities.TankShield;
        ability3 = abilities.TankMagnet;
        CTRLID = 1;
        shieldSize = 5;
    }

    // Update is called once per frame
    void Update () {
        grounded = JumpCheck();
        print("Tank Class: "+shieldSize);
        Movement();

        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Abutton"]))
        {
            buttonA();
            
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Bbutton"]))
        {
            buttonB();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Xbutton"]))
        {
            buttonX();
        }
        if (Input.GetKeyDown("joystick " + CTRLID + " button " + buttons["Ybutton"]))
        {
            buttonY();
        }


    }

}
