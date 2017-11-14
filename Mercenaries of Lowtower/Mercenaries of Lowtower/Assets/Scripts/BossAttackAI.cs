using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackAI : MonoBehaviour {
    public float[] attackCDs;
    public float[] specialAttackCDs;
    BossTargetingAI targeting;
    BossMovementAI range;
    Health health;
   public float currentGCD;
    float maxGCD;
    float range1;
    public GameObject shockwaveObj;
    public GameObject tsunamiObj;
    public bool shockwave;
    public bool tsunami;
    public bool hurricane;
    public bool lightningStorm;
   public GameObject[] tsunamiSpawns;
    public LayerMask theground;
    GameObject scenelight;




    //Reference to the animator for the boss
    Animator anim;

    //Int to change the animators bossPhase parameter
    // bossPhase = 0 is the default phase
    // bossPhase = 1 is the PrepPunch phase
    // bossPhase = 2 is the ReleasePunch phase
    // bossPhase = 3 is the PrepSpin phase
    // bossPhase = 4 is the ReleaseSpin phase
    // bossPhase = 5 is the prepSlam phase
    // bossPhase = 6 is the ReleaseSlam phase
    public int bossPhase;


    // At the start, initializes an array for each attack to have their own Cooldowns(CDs)
    // Also pulls targeting and movement information.
    // Hardcoded coodlown values for testing. Change or make variables (see below)
    void Start () {
        attackCDs = new float[4];
        specialAttackCDs = new float[4];

        targeting = GetComponent<BossTargetingAI>();
        range = GetComponent<BossMovementAI>();
        anim = GetComponent<Animator>();

        attackCDs[0] = 10;
        attackCDs[1] = 8;
        attackCDs[2] = 5;
        attackCDs[3] = 2;
        specialAttackCDs[0] = 10;
        specialAttackCDs[1] = 15;
        specialAttackCDs[2] = 10;
        specialAttackCDs[3] = .5f;

        scenelight = GameObject.Find("Directional Light");

        health = GetComponent<Health>();
    }

    // Each CD ticks down every frame.
    void Update () {
        currentGCD += Time.deltaTime;

        if (health.health < 25)
        {
            tsunami = true;
        }
        else if (health.health < 50)
        {
            lightningStorm = true;

        }
        else if (health.health < 75)
        {
            hurricane = true;
        }
        else
        {

        }

        if (shockwave)
        {
            specialAttackCDs[0] += Time.deltaTime;
            if (specialAttackCDs[0] >= 10)
            {
                Shockwave(200, 1.5f, new Vector3(transform.position.x, 0, transform.position.z));
            }

        }
        if (tsunami)
        {
            specialAttackCDs[1] += Time.deltaTime;
            if (specialAttackCDs[1] >= 15)
            {
                int r = Random.Range(0, 4);
                Tsunami(15, tsunamiSpawns[r].transform.position, tsunamiSpawns[r].transform.rotation);
                print(tsunamiSpawns[r].transform.rotation.eulerAngles);

                specialAttackCDs[1] = 0;
            }
        
        }
        if (hurricane)
        {
            Hurricane();
        } else
        {
            scenelight.GetComponent<Light>().color = Vector4.one;
            scenelight.GetComponent<Light>().intensity = 1;
        }
        if (lightningStorm)
        {
            specialAttackCDs[3] += Time.deltaTime;
            if (specialAttackCDs[3] >= 2)
            {
                Lightningstorm();
                specialAttackCDs[3] = 0;
            }

        }

        for (int i = 0; i < attackCDs.Length; i++)
        {
            attackCDs[i] -= Time.deltaTime;
        }




        // If the Global Cool Down (GCD) is finished, boss loops through attack priority
        if (currentGCD >= maxGCD)
        {
            checkAttacks();
            
        }

        // Sets the boss phase parameter in the animator equal to the bossPhase integer
        anim.SetInteger("bossPhase", bossPhase);
    }
    // attack one, use this as a template. When attack1 happens, it needs a target passed into it.
    // Finds the health script of the target, sends damage and ID I gave the boss an ID of 9, but the ID doesn't matter as it has no threat.
    // Then it resets the CD of the attack, and triggers the GCD so the boss will not attack for whatever value is placed there. For cinematic attacks, or waits for animations.
    void Storm(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(20, 9);
        attackCDs[0] = 10;
        triggerGCD(2);
    }

    void Slam(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(10, 9);
        attackCDs[1] = 8;
        triggerGCD(2);
    }

    void Swipe(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(5, 9);
        attackCDs[2] = 5;
        triggerGCD(2);
    }
    
    void Punch(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        health.modifyHealth(1, 9);
        attackCDs[3] = 1;
        triggerGCD(1);

        /*
         
        **********QUESTION**********:
         Takes awhile for the punch to go off is that because the CD or GCD?
         It takes a while because once it is in range it starts in phase 2. It also is in the "punch" method, so it is only called when punch is (the CD). Swapped the stack and adjusted the CDs.
         */

               // If the player is out of range, the boss will go into the preparing to punch animation
        if (range.inRange && bossPhase != 1)
        {
            bossPhase = 1;
        }
        // If the player is within range, the punch animation will be triggered
        else if (range.inRange && bossPhase != 2)
        {
            bossPhase = 2;
        }
 

    }

    void Shockwave(float speed, float range, Vector3 position)
    {
        
        shockwaveObj.transform.position = position;
        shockwaveObj.transform.localScale += new Vector3(1 * speed, 0, 1 * speed) * Time.deltaTime;

        if (specialAttackCDs[0] >= 10+range)
        {
            shockwaveObj.transform.position = new Vector3(0, -100, 0);
            shockwaveObj.transform.localScale = new Vector3(.001f, .25f, .001f);
            specialAttackCDs[0] = 0;

        }
        //attackCDs[2] = 5;
        //triggerGCD(2);
    }

    void Hurricane()
    {
        

        if (hurricane == true)
        {
            scenelight.GetComponent<Light>().color = new Vector4(1f, .8f, .8f, 1);
            scenelight.GetComponent<Light>().intensity = .9f;
            Collider[] col = Physics.OverlapSphere(transform.position, 1000, 1<<8);

            for (int i = 0; i < col.Length; i++)
            {
                print(col[i].name);
                col[i].GetComponent<Health>().modifyHealth(1*Time.deltaTime,9);
            }
        } else
        {

        }
        attackCDs[2] = 5;
        triggerGCD(2);
    }

    void Tsunami(float speed, Vector3 position, Quaternion rotation)
    {
        tsunamiObj.SetActive(true);
        tsunamiObj.transform.position = position;
        tsunamiObj.transform.rotation = rotation;
        tsunamiObj.GetComponent<TsunamiScript>().SetTsunamiSpeed(speed);


        attackCDs[2] = 5;
        triggerGCD(2);
    }

    void Lightningstorm()
    {


        //GameObject lightning= new GameObject("LightningBolt");
        RaycastHit hit;
        //lightning.transform.position = new Vector3(transform.position.x + Random.Range(-50, 50), 100, transform.position.z + Random.Range(-50, 50));
        do
        {
            Physics.Raycast(new Vector3(Random.Range(-50, 50), 100, Random.Range(-50, 50)), Vector3.down, out hit, 120, 1, QueryTriggerInteraction.Ignore);

        } while ((Physics.Raycast(new Vector3(Random.Range(-50, 50), 100,Random.Range(-50, 50)), Vector3.down, out hit, 120, 1, QueryTriggerInteraction.Ignore) == false));

        if (Physics.Raycast(new Vector3(Random.Range(-50, 50), 100, Random.Range(-50, 50)), Vector3.down, out hit, 120, 1, QueryTriggerInteraction.Ignore) == true)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Destroy(sphere.GetComponent<SphereCollider>());
            sphere.transform.position = hit.point;
            sphere.transform.localScale = new Vector3(25, 25, 25);
            Destroy(sphere, 2);
            Collider[] col = Physics.OverlapSphere(hit.point, 25, 1 << 8, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < col.Length; i++)
            {
                col[i].GetComponent<Health>().modifyHealth(10, 9);
            }
        }


        // lightning.transform.position = hit.point;


        attackCDs[2] = 5;
        triggerGCD(2);
    }

    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    // Method that loops through each attack and checks if they are on cooldown. //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    // since it checks in order, if they aren't in order of priority, it will use whatever attack has the faster CD. //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    //THE ATTACKS ARE IN ORDER OF PRIORITY. VERY IMPORTANT.
    void checkAttacks()
    {
        //if (attackCDs[0] <= 0 && range.inRange)
        //{
        //    Storm(targeting.currentTarget);

        //}
        /*else*/ if (attackCDs[1] <= 0 && range.inRange)
        {
            Slam(targeting.currentTarget);
        }
        //else if (attackCDs[2] <= 0 && range.inRange)
        //{
        //    Swipe(targeting.currentTarget);
        //}
        else if (attackCDs[3] <= 0 && range.inRange)
        {
            Punch(targeting.currentTarget);
        }
    }
    // triggers the GCD, this method can be triggered with any value to wait for animations or anything else.
    void triggerGCD(float cooldownTime)
    {
        currentGCD = 0;
        maxGCD = cooldownTime;
    }
}

