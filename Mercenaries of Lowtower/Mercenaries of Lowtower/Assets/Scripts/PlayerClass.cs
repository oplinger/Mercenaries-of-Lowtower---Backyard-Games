using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour 
{
    public int CTRLID;
    public GameObject controllerThing;
     public Vector3 playermovement;
    public ControllerThing controller;
    public PlayerAbilityController abilities;
    public PlayerCDController cooldowns;
    public Collider[] colliders;
    public Animator anim;
    public Health health;
    public float currentHealth;
    public float lastFrameHealth;

    public float walkspeed;
    public float jumpHeight;
    public LayerMask groundMask;
    public LayerMask magnetMask;
    public Material playerMat;
    public float reviveRadius;
    public float reviveCastTime;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    public int JumpCheck()
    {
        Debug.DrawRay(transform.position, Vector3.up * -1f);
        colliders = Physics.OverlapCapsule(transform.position, transform.position + (Vector3.up * -2f), .25f, groundMask, QueryTriggerInteraction.Ignore);
       // print(colliders[0]);
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

    public void Death()
    {

    }


}
