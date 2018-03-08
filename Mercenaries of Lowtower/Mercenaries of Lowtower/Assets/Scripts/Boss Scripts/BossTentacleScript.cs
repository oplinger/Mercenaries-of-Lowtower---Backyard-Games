using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTentacleScript : BossClass {
    // The speed at which the tentacle elevates towards the endPoint
    public float elevationSpeed;
    // The speed at which the tentacle descends after slamming
    public float descendingSpeed;
    // Bool to track if the tentacle is currently raising
    public bool tentacleRaising;
    // Bool to track if the tentacle is currently slamming
    public bool tentacleSlamming;
    // Bool to track if the tentacle is currently lowering
    public bool tentacleLowering;
    public bool damageActive;
    // Bool to track if the attack is complete
    public bool attackComplete;
    // Original transform position
    Vector3 originPoint;
    // Transform for the waypoint of how high the tentacle will rise
    public Transform elevationEndPoint;
    // Holds a reference to the BossManager game object
    public GameObject BossManager;
    public GameObject Boss;
    public Animator anim;
    // Use this for initialization
    void Start () {
        // Sets the origin point to the position the tentacles are in when the play button is pressed
        originPoint = gameObject.transform.position;
        // Sets the values to the values in the BossControlScript 
        elevationSpeed = BossManager.GetComponent<BossControlScriptV2>().elevationSpeed;
        descendingSpeed = BossManager.GetComponent<BossControlScriptV2>().descendingSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if (tentacleRaising == true)
        {
            RaiseTentacle();
        }

        if (tentacleSlamming == true)
        {
            SlamTentacle();
        }

        if (tentacleLowering == true)
        {
            LowerTentacle();
        }

        if (attackComplete == true)
        {
            BossManager.GetComponent<BossControlScriptV2>().CheckIfReady();
            //print("Tentacle check!");
            attackComplete = false;
        }
    }

    void RaiseTentacle()
    {
        anim.SetBool("tentacleRaising", true);
        // Multiplies the elevation speed by time
        float upStep = elevationSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, elevationEndPoint.transform.position, upStep);

        if (transform.position == elevationEndPoint.transform.position)
        {
            tentacleSlamming = true;
            anim.SetBool("tentacleRaising", false);
            tentacleRaising = false;
        }
    }

    public void SlamTentacle()
    {
        anim.SetBool("tentacleSlamming", true);
    }

    public void RetreatTentacle()
    {
        DeactivateDamage();
        anim.SetBool("tentacleSlamming", false);
        tentacleSlamming = false;
        anim.SetBool("tentacleRetreating", true);
    }

    public void CompleteRetreat()
    {
        anim.SetBool("tentacleRetreating", false);
        anim.SetBool("tentacleLowering", true);
        tentacleLowering = true;
    }


    public void LowerTentacle()
    {
        // Multiplies the elevation speed by time
        float downStep = descendingSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, originPoint, downStep);

        if (transform.position == originPoint)
        {
            attackComplete = true;
            anim.SetBool("tentacleLowering", false);
            tentacleLowering = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(damageActive == true)
        {
            if (other.tag == "Player")
            {
                print("Collided with player");
                other.GetComponent<IDamageable<float>>().TakeDamage(50);
            }

            if (other.tag == "Enemy")
            {
                other.GetComponent<IDamageable<float>>().TakeDamage(50);
            }
        }
    }

    public void ActivateDamage()
    {
        if(damageActive == false)
        {
            damageActive = true;
        }
    }

    public void DeactivateDamage()
    {
        if(damageActive == true)
        {
            damageActive = false;
        }
    }

}
