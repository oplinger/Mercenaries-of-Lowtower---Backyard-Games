using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetStats : MonoBehaviour {

    public GameObject characterObj;
    private float characterHealth;
    public bool isDead;
    public int characterNum;

	// Use this for initialization
	void Start () {
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (characterNum == 0)
        {
            characterHealth = characterObj.GetComponent<TankClass>().currentHealth;
        } else if (characterNum == 1)
        {
            characterHealth = characterObj.GetComponent<HealerClass>().currentHealth;
        } else if (characterNum == 2)
        {
            characterHealth = characterObj.GetComponent<MeleeClass>().currentHealth;
        } else if (characterNum == 3)
        {
            characterHealth = characterObj.GetComponent<RangedClass>().currentHealth;
        }

        if (characterHealth <= 0)
        {
            isDead = true;
        }
        else if(characterHealth > 0)
        {
            isDead = false;
        }
	}
}
