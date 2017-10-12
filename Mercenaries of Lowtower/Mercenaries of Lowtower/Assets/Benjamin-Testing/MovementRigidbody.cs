using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody : MonoBehaviour
{
    public Rigidbody playerbody;
    public GameObject player;
    public float walkspeed;
    public Vector3 playermovement;
    PlayerID ID;
    public float jumpForce;

    ControllerThing controller;

    bool climbing;
    float testtime;
    public bool isGrounded;
    public bool isWalled;
    public float jumpspeed;
    int jumpcount;
    Vector3 wallDir;
    Vector3 jumpDir;

    public GameObject wall;

    public bool isDead;

    public float wallJumpForce;

    // Use this for initialization
    void Start()
    {
        ID = GetComponent<PlayerID>();
        playerbody = GetComponent<Rigidbody>();
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<ControllerThing>();
        player = this.gameObject;

        isDead = false;

        jumpDir = Vector3.up*- 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(gameObject.transform.position, transform.up * -10, Color.green);

        if (isGrounded)
        {
            isWalled = false;
            playerbody.velocity = new Vector3(0,0,0);
        }
        if (isGrounded && jumpDir == Vector3.zero)
        {
            //controller.CastRay(gameObject, transform.up * -10, 0, 1, "Jump");
        }
        if (!climbing && !isDead)
        {
            if (ID.playerID == 0)
            {
                playermovement = new Vector3(Input.GetAxis("TankHorizontal"), 0, Input.GetAxis("TankVertical"));
                //Vector3 relpos = playermovement - transform.position;
                if (playermovement != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(playermovement);
                    transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
                }
            }

            if (ID.playerID == 1)
            {
                playermovement = new Vector3(Input.GetAxis("HealerHorizontal"), 0, Input.GetAxis("HealerVertical"));
                //Vector3 relpos = playermovement - transform.position;
                if (playermovement != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(playermovement);
                    transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
                }
            }

            if (ID.playerID == 2)
            {
                playermovement = new Vector3(Input.GetAxis("MeleeHorizontal"), 0, Input.GetAxis("MeleeVertical"));
                //Vector3 relpos = playermovement - transform.position;
                if (playermovement != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(playermovement);
                    transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
                }
            }

            if (ID.playerID == 3)
            {
                playermovement = new Vector3(Input.GetAxis("RangedHorizontal"), 0, Input.GetAxis("RangedVertical"));
                //Vector3 relpos = playermovement - transform.position;
                if (playermovement != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(playermovement);
                    transform.Translate(playermovement * walkspeed * Time.deltaTime, Space.World);
                }
            }

        }
        if (climbing)
        {
            playermovement = new Vector3(0, Input.GetAxis("Vertical") / 10, 0);
            transform.Translate(playermovement);

        }

        if (isDead)
        {
            playermovement = new Vector3(0, 0, 0);
            controller.DeathCount(1,0);
        }


        // playermovement.y -= gravity * Time.deltaTime;
        /*if (Input.GetButton("Jump"))
        {
            PlayerJump(jumpDir);

            //if (isGrounded || isWalled)
            //{
            //    PlayerJump(jumpDir);
            //}
        }*/

    }

    private void FixedUpdate()
    {
        //J U M P I N G
        if (ID.playerID == 0 && Input.GetButton("TankJump") && isGrounded)
        {
            playerbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        if (ID.playerID == 1 && Input.GetButton("HealerJump") && isGrounded)
        {
            playerbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        if (ID.playerID == 2 && Input.GetButton("MeleeJump") && isGrounded)
        {
            playerbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        if (ID.playerID == 3 && Input.GetButton("RangedJump") && isGrounded)
        {
            playerbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Wall" && jumpcount < 1 && Input.GetButton("MeleeJump"))
        {
            isWalled = true;

            //hey maybe this lets you wall jump in an inputted direction
            playerbody.AddForce(Input.GetAxis("MeleeHorizontal") * wallJumpForce, 10, Input.GetAxis("MeleeVertical") * wallJumpForce, ForceMode.Impulse);

            // controller.CastRay(gameObject, other.transform.position - transform.position, 0, 1, "Jump");
            //controller.CastRay(gameObject, other.transform.position - transform.position, 0, 1, "Jump");

        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Climbable")

        {
            climbing = true;
            playerbody.useGravity = false;
        }
        if (other.tag == "Ground")
        {
            isGrounded = true;
            jumpcount = 0;
            //controller.CastRay(gameObject, transform.up * -10, 0, 1, "Jump");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Climbable")
        {
            climbing = false;
            playerbody.useGravity = true;
        }
        if (other.tag == "Ground")
        {
            isGrounded = false;
            jumpDir = Vector3.up;
        }
        if (other.tag == "Wall")
        {
            isWalled = false;
            //jumpcount++;
            jumpDir = Vector3.up;
        }
    }
    /*public void PlayerJump(Vector3 jumpDirection)
    {


        if (isGrounded)
        {
            SetDirection();
            playerbody.AddForce(jumpDirection.normalized * jumpspeed, ForceMode.Impulse);

        }

        if (isWalled)
        {
            jumpDirection.y = 1f;
            playerbody.AddForce(jumpDirection.normalized * jumpspeed, ForceMode.Impulse);


        }
    }
    public void SetDirection()
    {
        print("SetDirection");
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.up*-10);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 incomingVec = hit.point - transform.position;
            Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);

            jumpDir = reflectVec;
        }
    }*/


}
