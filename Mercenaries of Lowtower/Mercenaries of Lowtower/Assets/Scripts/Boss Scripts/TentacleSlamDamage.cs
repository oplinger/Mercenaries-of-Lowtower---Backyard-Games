using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSlamDamage : BossClass {
    public GameObject tentacle;
    public GameObject boss;
    public bool tentacleSlamming;
    public bool damageActiv;
    public bool tentDown;
    public bool tentRetreating;
    public bool damageToggled;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //tentacleSlamming = tentacle.GetComponent<BossTentacleScript>().tentacleSlamming;
        damageActiv = tentacle.GetComponent<BossTentacleScript>().damageActive;
        tentDown = tentacle.GetComponent<BossTentacleScript>().tentacleDown;
        tentRetreating = tentacle.GetComponent<BossTentacleScript>().tentacleRetreating;

        if (damageActiv == true && damageToggled == false)
        {
            //GetComponent<Collider>().enabled = false;
            GetComponent<Collider>().enabled = true;
            damageToggled = true;
        }

        if(damageActiv == false)
        {
            damageToggled = false;
        }

        if(tentRetreating == true)
        {
            GetComponent<Collider>().enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        /*
        if(tentacleSlamming == true)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<IDamageable<float>>().TakeDamage(50);
            }

            if (other.tag == "Enemy")
            {
                other.GetComponent<IDamageable<float>>().TakeDamage(50);
            }
        }
        */

        if (damageActiv == true)
        {
            if (other.tag == "Player")
            {
                other.GetComponent<IDamageable<float>>().TakeDamage(50);
            }

            if (other.tag == "Enemy")
            {
                other.GetComponent<IDamageable<float>>().TakeDamage(50);
            }
        }
    }
    public override void TakeDamage(float damageTaken)
    {
        if (tentDown)
        {
            StartCoroutine("Flash");
            boss.GetComponent<BossClass>().currentHealth -= damageTaken;
        }
    }

    public void PlayerColorFlash(Color playercolor)
    {
        StartCoroutine("IPlayerColorFlash", playercolor);

    }

    IEnumerator Flash()
    {
        tentacle.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.red);

        yield return new WaitForSeconds(.016f);
        tentacle.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }

    IEnumerator IPlayerColorFlash(Color playercolor)
    {
        tentacle.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", playercolor);

        yield return new WaitForSeconds(.016f);
        tentacle.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }
}
