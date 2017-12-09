using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateControlsTEST : MonoBehaviour {
    public delegate void ButtonA();
    public delegate void ButtonAAbility();

    ButtonA buttonA;
    ButtonAAbility buttonAability;

    public delegate void ButtonB();
    public delegate void ButtonBAbility(string message);

    ButtonB buttonB;
    ButtonBAbility buttonBability;

    public PersonThingWithAbilitiesScript personthing;
    public GameObject personthingwithabilities;


    // Use this for initialization
    void Start () {
        buttonA = buttonAfunction;
        buttonB = buttonBfunction;
        buttonAability = Ability1;
        buttonBability = Ability2;
        personthing = personthingwithabilities.GetComponent<PersonThingWithAbilitiesScript>();

    }

    // Update is called once per frame
    void Update () {

		if(Input.GetKey("joystick 1 button 0"))
        {
            buttonA();
        }
        if (Input.GetKey("joystick 1 button 1"))
        {
            buttonB();
        }
    }

    public void buttonAfunction()
    {
        buttonAability();
    }

    public void buttonBfunction()
    {
        buttonBability("horse");
    }

    public void Ability1()
    {
        print("lokoipj");
    }

    public void Ability2(string message)
    {
        buttonAability = Ability3;
        print(message);
    }
    public void Ability3()
    {
        print("Ability3 Fired!");
    }
}
