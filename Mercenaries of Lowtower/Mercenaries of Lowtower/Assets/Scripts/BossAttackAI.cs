using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackAI : MonoBehaviour
{
    #region Variables
    BossTargetingAI targeting;
    BossMovementAI range;
    Health health;
    float h1;
    float h2;
     float currentGCD;
    float maxGCD;
    float range1;
     GameObject shockwaveObj;
     GameObject tsunamiObj;
    public GameObject torso;

    GameObject[] tsunamiSpawns;
    LayerMask theground;
    GameObject scenelight;
    [Header("Attack Bools")]
    public bool shockwave;
    public bool tsunami;
    public bool hurricane;
    public bool lightningStorm;

    [Space(10)]
    [Header("Cooldowns")]
    public float[] attackCDs;
    public float[] specialAttackCDs;

    [Space(10)]
    [Header("Damages")]
    //public float stormDamage;
    public float slamDamage;
    //public float swipeDamage;
    public float punchDamage;
    
    [Header("Lightning Storm Settings")]
    public float lightningstormDamage;
    public float lightningWarningDuration;
    public float lightningSphereDuration;
    public float timeBetweenWarningAndDamage;

    [Header("Shockwave Settings")]
    public float shockwaveSpeed;
    public float shockwaveDuration;
    public float shockwaveStrength;
    public float shockwaveDamage;
    Vector3 shockwaveLocation;

    [Header("Tsunami Settings")]
    public float tsunamiSpeed;
    public float tsunamiDuration;

    [Header("Hurricane Settings")]
    public float hurricaneDamage;
    public float hurricaneInterval;







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
     int bossPhase;

#endregion
    // At the start, initializes an array for each attack to have their own Cooldowns(CDs)
    // Also pulls targeting and movement information.
    // Hardcoded coodlown values for testing. Change or make variables (see below)
    void Start()
    {
        attackCDs = new float[4];
        specialAttackCDs = new float[4];
        tsunamiSpawns = new GameObject[4];

        targeting = GetComponent<BossTargetingAI>();
        range = GetComponent<BossMovementAI>();
        anim = GetComponent<Animator>();

        torso = GameObject.Find("Torso");

        tsunamiObj = GameObject.Find("Mako Tsunami");
        shockwaveObj = GameObject.Find("Adobe Shockwave");

        tsunamiSpawns[0] = new GameObject("Tsunami Spawn");
        tsunamiSpawns[0].transform.position = new Vector3(100, 0, 0);
        tsunamiSpawns[0].transform.rotation = Quaternion.Euler(0, -90, -90);


        tsunamiSpawns[1] = new GameObject("Tsunami Spawn");
        tsunamiSpawns[1].transform.position = new Vector3(-100, 0, 0);
        tsunamiSpawns[1].transform.rotation = Quaternion.Euler(0, 90, -90);


        tsunamiSpawns[2] = new GameObject("Tsunami Spawn");
        tsunamiSpawns[2].transform.position = new Vector3(0, 0, 100);
        tsunamiSpawns[2].transform.rotation = Quaternion.Euler(0, 180, -90);


        tsunamiSpawns[3] = new GameObject("Tsunami Spawn");
        tsunamiSpawns[3].transform.position = new Vector3(0, 0, -100);
        tsunamiSpawns[3].transform.rotation = Quaternion.Euler(0, 0, -90);





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

        h2 = health.health;

    }

    // Each CD ticks down every frame.
    void Update()
    {

        if (scenelight == null)
        {
            scenelight = GameObject.Find("Directional Light");
        }
        currentGCD += Time.deltaTime;

        if (health.health/health.maxHealth < .25f)
        {
            tsunami = true;
        }
        else if (health.health / health.maxHealth < .5f)
        {
            lightningStorm = true;

        }
        else if (health.health / health.maxHealth < .75f)
        {
            hurricane = true;
        }
        else
        {

        }

        h1 = health.health;


        if (h1 < h2)
        {
            foreach(Transform child in transform)
            {
                child.GetComponent<Renderer>().material.color = Color.red;
            }
            foreach (Transform child in torso.transform)
            {
                child.GetComponent<Renderer>().material.color = Color.red;
            }
            //GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
            h2 = h1;
        }
         else if (h2 == h1)
        {
            print("oij");
            if (torso.GetComponent<Renderer>().material.color != Color.white)
            {
                foreach (Transform child in transform)
                {
                    child.GetComponent<Renderer>().material.color = Color.white;
                }
                foreach (Transform child in torso.transform)
                {
                    child.GetComponent<Renderer>().material.color = Color.white;
                }
            }

        }


        if (shockwave)
        {
            specialAttackCDs[0] += Time.deltaTime;
            if (specialAttackCDs[0] >= 10)
            {
                Shockwave(shockwaveSpeed, shockwaveDuration, shockwaveLocation);
            }

        }
        if (tsunami)
        {
            specialAttackCDs[1] += Time.deltaTime;
            if (specialAttackCDs[1] >= 15)
            {
                int r = Random.Range(0, 4);
                Tsunami(15, tsunamiSpawns[r].transform.position, tsunamiSpawns[r].transform.rotation);
                tsunamiObj.GetComponent<TsunamiScript>().SetTsunamiSpeed(tsunamiSpeed);
                tsunamiObj.GetComponent<TsunamiScript>().SetTsunamiDuration(tsunamiDuration);

                specialAttackCDs[1] = 0;
            }

        }
        if (hurricane)
        {
            Hurricane();
        }
        else
        {
            scenelight.GetComponent<Light>().color = Vector4.one;
            scenelight.GetComponent<Light>().intensity = 1;
        }

        if (lightningStorm)
        {
            specialAttackCDs[3] += Time.deltaTime;
            if (specialAttackCDs[3] >= 3)
            {
                StartCoroutine(LightningStormRoutine());
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
        //health.modifyHealth(stormDamage, 9);
        attackCDs[0] = 10;
        triggerGCD(2);
    }

    void Slam(GameObject target)
    {
        Collider[] col = Physics.OverlapSphere(new Vector3(transform.position.x + transform.forward.x * range.targetDistance, 0, transform.position.z + transform.forward.z * range.targetDistance), 10, 1 << 8, QueryTriggerInteraction.Ignore);

        for (int i = 0; i < col.Length; i++)
        {
            Health health = col[i].GetComponent<Health>();
            health.modifyHealth(slamDamage, 9);
        }
        shockwaveLocation = new Vector3(transform.position.x + transform.forward.x * range.targetDistance, 0, transform.position.z + transform.forward.z * range.targetDistance);
        shockwave = true;
        attackCDs[1] = 8;
        triggerGCD(2);
    }

    void Swipe(GameObject target)
    {
        Health health = target.GetComponent<Health>();
        //health.modifyHealth(swipeDamage, 9);
        attackCDs[2] = 5;
        triggerGCD(2);
    }

    void Punch(GameObject target)
    {
        Vector3 zeroY = new Vector3(1, 0, 1);
        //Collider[] col = Physics.OverlapSphere(((transform.position+((transform.forward.*range.targetDistance)-transform.forward))),2, 1<<8, QueryTriggerInteraction.Ignore);
        Collider[] col = Physics.OverlapSphere(new Vector3(transform.position.x+transform.forward.x * range.targetDistance, 0, transform.position.z+transform.forward.z * range.targetDistance), 2, 1 << 8, QueryTriggerInteraction.Ignore);


        GameObject markersphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Destroy(markersphere.GetComponent < SphereCollider>());
        markersphere.transform.position = new Vector3((transform.position.x + transform.forward.x * range.targetDistance)-transform.forward.x, 0, (transform.position.z + transform.forward.z * range.targetDistance)-transform.forward.z);
        markersphere.transform.localScale = new Vector3(2, 2, 2);
        //markersphere.transform.position = new Vector3(markersphere.transform.position.x, 0, markersphere.transform.position.z);
        Destroy(markersphere, 1);

        for (int i = 0; i < col.Length; i++)
        {
            Health health = col[i].GetComponent<Health>();
            health.modifyHealth(punchDamage, 9);
        }
        print(col.Length);

        attackCDs[3] = 3;
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
        shockwaveObj.GetComponent<ShockwaveScript>().ShockwaveStats(shockwaveStrength, shockwaveDamage);
        shockwaveObj.transform.position = position;
        shockwaveObj.transform.localScale += new Vector3(1 * speed, 0, 1 * speed) * Time.deltaTime;

        if (specialAttackCDs[0] >= 10 + range)
        {
            shockwaveObj.transform.position = new Vector3(0, -100, 0);
            shockwaveObj.transform.localScale = new Vector3(.001f, .25f, .001f);
            specialAttackCDs[0] = 0;

        }

    }

    void Hurricane()
    {


        if (hurricane == true)
        {
            specialAttackCDs[2] += Time.deltaTime;
            scenelight.GetComponent<Light>().color = new Vector4(1f, .8f, .8f, 1);
            scenelight.GetComponent<Light>().intensity = .9f;
            Collider[] col = Physics.OverlapSphere(transform.position, 1000, 1 << 8, QueryTriggerInteraction.Ignore);

            if (specialAttackCDs[2] >= hurricaneInterval)
            {
                for (int i = 0; i < col.Length; i++)
                {
                    col[i].GetComponent<Health>().modifyHealth(hurricaneDamage , 9);
                }
                specialAttackCDs[2] = 0;
            }
        }
        else
        {

        }

    }

    void Tsunami(float speed, Vector3 position, Quaternion rotation)
    {
        tsunamiObj.SetActive(true);
        tsunamiObj.transform.position = position;
        tsunamiObj.transform.rotation = rotation;
        tsunamiObj.GetComponent<TsunamiScript>().SetTsunamiSpeed(speed);

        //tsunami damage is in the "TsunamiScript" script

    }

    void Lightningstorm()
    {


        //GameObject lightning= new GameObject("LightningBolt");
        RaycastHit hit;
        //lightning.transform.position = new Vector3(transform.position.x + Random.Range(-50, 50), 100, transform.position.z + Random.Range(-50, 50));
        do
        {
            Physics.Raycast(new Vector3(Random.Range(-50, 50), 100, Random.Range(-50, 50)), Vector3.down, out hit, 120, 1, QueryTriggerInteraction.Ignore);

        } while ((Physics.Raycast(new Vector3(Random.Range(-50, 50), 100, Random.Range(-50, 50)), Vector3.down, out hit, 120, 1, QueryTriggerInteraction.Ignore) == false));

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
                col[i].GetComponent<Health>().modifyHealth(lightningstormDamage, 9);
            }
        }


        // lightning.transform.position = hit.point;



    }

    IEnumerator LightningStormRoutine()
    {

        RaycastHit hit;
        do
        {
            Physics.Raycast(new Vector3(Random.Range(-50, 50), 100, Random.Range(-50, 50)), Vector3.down, out hit, 120, 1, QueryTriggerInteraction.Ignore);

        } while ((Physics.Raycast(new Vector3(Random.Range(-50, 50), 100, Random.Range(-50, 50)), Vector3.down, out hit, 120, 1, QueryTriggerInteraction.Ignore) == false));

        if (Physics.Raycast(new Vector3(Random.Range(-50, 50), 100, Random.Range(-50, 50)), Vector3.down, out hit, 120, 1, QueryTriggerInteraction.Ignore) == true)
        {
            print("ewrgerg");

            GameObject cyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            Destroy(cyl.GetComponent<CapsuleCollider>());
            cyl.GetComponent<Renderer>().material.color = Color.red;
            cyl.transform.position = hit.point;
            cyl.transform.localScale = new Vector3(25, 1, 25);
            Destroy(cyl, lightningWarningDuration);
            yield return new WaitForSeconds(timeBetweenWarningAndDamage);

            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Destroy(sphere.GetComponent<SphereCollider>());
            sphere.GetComponent<Renderer>().material.color = Color.yellow;

            sphere.transform.position = hit.point;
            sphere.transform.localScale = new Vector3(25, 25, 25);
            Destroy(sphere, lightningSphereDuration);
            Collider[] col = Physics.OverlapSphere(hit.point, 25, 1 << 8, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < col.Length; i++)
            {
                col[i].GetComponent<Health>().modifyHealth(lightningstormDamage, 9);
            }
        }
        yield return new WaitForSeconds(.001f);
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
        /*else*/
        if (attackCDs[1] <= 0 && range.inRange)
        {
            Slam(targeting.currentTarget);
        }
        //else if (attackCDs[2] <= 0 && range.inRange)
        //{
        //    Swipe(targeting.currentTarget);
        //}
        else if (attackCDs[3] <= 0 && range.inRange)
        {
            //Punch(targeting.currentTarget);
        }
    }
    // triggers the GCD, this method can be triggered with any value to wait for animations or anything else.
    void triggerGCD(float cooldownTime)
    {
        currentGCD = 0;
        maxGCD = cooldownTime;
    }
}
