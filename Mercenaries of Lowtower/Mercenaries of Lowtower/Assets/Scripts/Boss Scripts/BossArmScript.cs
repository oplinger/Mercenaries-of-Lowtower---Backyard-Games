using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArmScript : BossClass {

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
    public GameObject Boss;
    //
    public bool armRotatingBackwardRetreat;
    public bool armLoweringRetreat;
    public bool armRetreating;

    // Use this for initialization
    void Start () {
        // Sets the origin point to the position the tentacles are in when the play button is pressed
        originPoint = gameObject.transform.position;

        // Sets the values to the values in the BossControlScript 
        elevationSpeed = BossManager.GetComponent<BossControlScript>().elevationSpeed;
        descendingSpeed = BossManager.GetComponent<BossControlScript>().descendingSpeed;
        rotationSpeed = BossManager.GetComponent<BossControlScript>().rotationSpeed;
        downTime = BossManager.GetComponent<BossControlScript>().downTime;
    }
	
	// Update is called once per frame
	void Update () {
        /*if ()
        {
            armRaising = true;
        }
        */
        /*// Sets the values to the values in the BossControlScript 
        elevationSpeed = BossManager.GetComponent<BossControlScript>().elevationSpeed;
        descendingSpeed = BossManager.GetComponent<BossControlScript>().descendingSpeed;
        rotationSpeed = BossManager.GetComponent<BossControlScript>().elevationSpeed;
        downTime = BossManager.GetComponent<BossControlScript>().downTime;
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

        if(armRotatingBackward == true)
        {
            RotateArmBackward();
        }

        if(attackComplete == true)
        {
            BossManager.GetComponent<BossControlScript>().CheckIfReady();
            //print("Arm check!");
            attackComplete = false;
        }
        
        if (armRetreating == true)
        {
            armRotatingBackwardRetreat = true;
            armRetreating = false;
        }

        if (armRotatingBackwardRetreat == true)
        {
            RotateArmBackward();
        }

        if (armLoweringRetreat == true)
        {
            LowerArmRetreat();
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

    void LowerArmRetreat()
    {
        // Multiplies the elevation speed by time
        float downStep = descendingSpeed * Time.deltaTime;
        // Moves the arm down towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, originPoint, downStep);

        if (transform.position == originPoint)
        {
            armLoweringRetreat = false;
        }
    }

    void RotateArmForward()
    {
        transform.Rotate(-rotationSpeed, 0, 0, Space.World);
        if (Mathf.Abs(transform.eulerAngles.x - 270f) <1)
        {
            armDown = true;
            StartCoroutine("ArmDown");
            armRotatingForward = false;
        }
    }

    IEnumerator ArmDown()
    {
        yield return new WaitForSeconds(downTime);
        armDown = false;
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

    void RotateArmBackwardRetreat()
    {
        transform.Rotate(rotationSpeed, 0, 0, Space.World);
        if (Mathf.Abs(transform.eulerAngles.x - 0f) < 1)
        {
            armLoweringRetreat = true;
            armRotatingBackwardRetreat = false;
        }
    }
    void ArmRetreat()
    {
        StopCoroutine("ArmDown");
        armDown = false;
        armRotatingBackward = true;
    }
    public override void TakeDamage(float damageTaken)
    {
        if(armDown == true)
        {
            Boss.GetComponent<BossClass>().currentHealth -= damageTaken;
        }
    }


    public void OnCollisionEnter( Collision other)
    {

        if (other.collider.gameObject.tag == "Player" && armRotatingForward == true)
        {
            other.collider.gameObject.GetComponent<IDamageable<float>>().TakeDamage(50);


        }

        if (other.collider.gameObject.tag == "Enemy" && armRotatingForward == true)
        {
            print("jhfuyj");
            other.collider.gameObject.GetComponent<IDamageable<float>>().TakeDamage(50);

        }
    }
}
