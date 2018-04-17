using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Dummy : AIControllerNavMesh
{
	
	void Update () {
        
        if (rb.velocity.magnitude < .05)
        {
            rb.velocity = Vector3.zero;
        }

        if (rb.velocity.magnitude > 0)
        {
            GetComponent<Animator>().SetInteger("AnimState", 1);
        }
        if (currentHealth < currenthealth2)
        {
            GetComponent<Animator>().SetInteger("AnimState", 2);

        }

        if (isStunned)
        {
            stunTimer++;
            foreach (Renderer item in enemyRenderer)
            {
                item.material.SetTexture("_MainTex", stunnedTex);
                item.material.SetTexture("_EmissionMap", stunnedTex);

            }
            GetComponent<Animator>().enabled = false;

            if (stunTimer / 60 >= 5)
            {
               isStunned = false;
               stunTimer = 0;

                foreach (Renderer item in enemyRenderer)
                {
                    item.material.SetTexture("_MainTex", defaultTex);
                    item.material.SetTexture("_EmissionMap", defaultTex);
                }

                GetComponent<Animator>().enabled = true;

            }

        }
        
        if (currentHealth <= 0)
        {
            addSpawnerScript.addCounter -= 1;
            GetComponent<Animator>().SetInteger("AnimState", 3);
            Destroy(this.gameObject);

        }
    }

    public override void StunThis()
    {
        isStunned = true;
    }

    public override void Death()
    {
        Debug.Log("killed");
    }
}
