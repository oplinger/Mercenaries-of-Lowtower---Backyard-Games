using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DelegateControlsTEST : MonoBehaviour {
    public delegate void ButtonA(int button);
    public delegate void ButtonAAbility();
    public Text buttonID;
    public Image buttonimage;
    public int buttonAnumber;
    public int buttonBnumber;

    bool remap;

    ButtonA buttonA;
    ButtonAAbility buttonAability;

    public delegate void ButtonB(int button);
    public delegate void ButtonBAbility(string message);

    ButtonB buttonB;
    ButtonBAbility buttonBability;

    public PersonThingWithAbilitiesScript personthing;
    public GameObject personthingwithabilities;

    float timer;
    // Use this for initialization
    void Start () {
        buttonAnumber = 0;
        buttonBnumber = 1;

        buttonA = buttonAfunction;
        buttonB = buttonBfunction;
        buttonAability = Ability1;
        buttonBability = Ability2;
        personthing = personthingwithabilities.GetComponent<PersonThingWithAbilitiesScript>();

    }

    // Update is called once per frame
    void Update () {

        buttonID.text = buttonAnumber.ToString();

		if(Input.GetKey("joystick 1 button 0"))
        {
            buttonA(0);
        }
        if (Input.GetKey("joystick 1 button 1"))
        {
            buttonB(1);
        }
        if (Input.GetKey("joystick 1 button 3"))
        {
            remap = true;
        }

        if (remap)
        {
           timer += Time.deltaTime;
            if (timer < 10)
            {
                for(int i =0; i<3; i++)
                {
                    if (Input.GetKey("joystick 1 button " + i))
                    {
                        if (i == 1)
                        {
                            buttonA = buttonBfunction;
                        }


                        timer = 0;
                        remap = false;
                    }
                }
            }
        }

    }

    public void buttonAfunction(int button)
    {

        if (!remap)
        {
            //buttonID.text = button.ToString();
            buttonAability();
        }
    }

    public void buttonBfunction(int button)
    {
        //buttonID.text = button.ToString();
        if (!remap)
        {
            buttonBability("horse");
        }
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
        buttonimage.color = new Color(1, 0, 0);
    }
}
