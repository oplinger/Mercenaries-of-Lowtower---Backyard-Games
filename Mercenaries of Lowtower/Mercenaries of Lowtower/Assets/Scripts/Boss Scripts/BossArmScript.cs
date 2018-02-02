using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArmScript : EntityClass, IDamageable<float> {

    // Original transform position
    Vector3 originPoint;
    // Transform position after the tentacle moves up to slam
    Vector3 endPoint;
    // The amount the tentacle will move up from the originPoint before slamming
    public float elevationAmount;
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

    // Use this for initialization
    void Start () {
        // Sets the origin point to the position the tentacles are in when the play button is pressed
        originPoint = gameObject.transform.position;
        // Sets the end point by adding on the elevation amount to the originPoint
        endPoint = new Vector3(originPoint.x, originPoint.y + elevationAmount, originPoint.z);
	}
	
	// Update is called once per frame
	void Update () {
        /*if ()
        {
            armRaising = true;
        }
        */

        if(armRaising == true)
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
            print("Arm check!");
            attackComplete = false;
        }
	}

    void RaiseArm()
    {
        // Multiplies the elevation speed by time
        float upStep = elevationSpeed * Time.deltaTime;
        // Moves the arm up towards the endPoint at a set speed
        transform.position = Vector3.MoveTowards(transform.position, endPoint, upStep);

        if(transform.position == endPoint)
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
        if (Mathf.Abs(transform.eulerAngles.x - 270f) <1)
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

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
    }
}
