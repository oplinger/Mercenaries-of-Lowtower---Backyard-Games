using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour {
    float timer;
    public int targetslot;
    //public GameObject target;
    public GameObject controller;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    public int layer;

     void Start()
    {
        abilities = controller.GetComponent<PlayerAbilityController>();
        cooldowns = controller.GetComponent<PlayerCDController>();

    }
    // Update is called once per frame
    void Update () {

    }
}
