using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THICCBossArmScript : EntityClass {

    // Original transform position
    Vector3 originPoint;
    // Transform for the waypoint of how high the tentacle will rise
    public Transform elevationEndPoint;
    // The speed at which the tentacle elevates towards the endPoint
    public float elevationSpeed;
    // The speed at which the tentacle descends after slamming
    public float descendingSpeed;
    // The amount the tentacle rotates per frame while slamming
    public float rotationSpeed;
    // Bool to track if the arm is currently raising
    public bool armRaising;
    // Bool to track if the arm is currently lowering
    public bool armLowering;
    // Bool to track if the arm is currently rotating forward
    public bool armRotatingForward;
    // Bool to track if the arm is currently rotating backward
    public bool armRotatingBackward;
    // Bool to track if the arm is currently down on the deck
    public bool armDown;
    // Float to control how long the arm is down
    public float downTime;
    // Bool to track if the attack is complete
    public bool attackComplete;
    // Holds a reference to the BossManager game object
    public GameObject BossManager;
    //Reference to the phase-changing script
    public PhaseControllerScript phaseScript;

    // Use this for initialization
    void Start()
    {
        // Sets the origin point to the position the tentacles are in when the play button is pressed
        originPoint = gameObject.transform.position;
        currentHealth = maxHealth;
        //phaseScript = GetComponent<PhaseControllerScript>();

    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /*if ()
        {
            armRaising = true;
        }
        */

        if (armRaising == true)
        {
            RaiseArm();
        }

        if (armLowering == true)
        {
            LowerArm();
        }

        if (armRotatingForward == true)
        {
            RotateArmForward();
        }

        if (armRotatingBackward == true)
        {
            RotateArmBackward();
        }

        if (attackComplete == true)
        {
            BossManager.GetComponent<THICCBossControlScript>().CheckIfReady();
            print("Arm check!");
            attackComplete = false;
        }


        //disables arm if health runs out
        if (currentHealth <= 0)
        {
            phaseScript.armIsDead = true;
            gameObject.SetActive(false);
        }
    }

    void RaiseArm()
    {
        // Multiplies the elevation speed by time
        float upStep = elevationSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        //transform.position = Vector3.MoveTowards(transform.position, endPoint, upStep);
        transform.position = Vector3.MoveTowards(transform.position, elevationEndPoint.transform.position, upStep);

        if (transform.position == elevationEndPoint.transform.position)
        {
            armRotatingForward = true;
            armRaising = false;
        }
    }

    void LowerArm()
    {
        // Multiplies the elevation speed by time
        float downStep = descendingSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, originPoint, downStep);

        if (transform.position == originPoint)
        {
            attackComplete = true;
            armLowering = false;
        }
    }

    void RotateArmForward()
    {
        transform.Rotate(-rotationSpeed, 0, 0, Space.World);
        if (Mathf.Abs(transform.eulerAngles.x - 270f) < 1)
        {
            StartCoroutine("ArmDown");
            armRotatingForward = false;
        }
    }

    IEnumerator ArmDown()
    {
        yield return new WaitForSeconds(downTime);
        armRotatingBackward = true;
    }

    void RotateArmBackward()
    {
        transform.Rotate(rotationSpeed, 0, 0, Space.World);
        if (Mathf.Abs(transform.eulerAngles.x - 0f) < 1)
        {
            armLowering = true;
            armRotatingBackward = false;
        }
    }

    //public void TakeDamage(float damageTaken)
    //{
    //    print("boss arm should be taking damage");
    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            armDown = true;

        }

        //if (other.tag == "Player"&& armDown)
        //{
        //    other.GetComponent<IDamageable<float>>().TakeDamage(20);
        //}
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            armDown = false;
        }
    }
}

