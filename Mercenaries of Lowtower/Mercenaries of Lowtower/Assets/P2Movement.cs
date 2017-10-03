using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour {

    // Use this for initialization
    public float speedP2;
    public float dashSpeedP2;
    public float jumpSpeedP2;
    public float gravityP2;
    private Vector3 moveDirectionP2 = Vector3.zero;
    Vector3 dashVectorP2 = Vector3.zero;

    public bool isDashingP2 = false;
    public float dashLengthP2;
    public float tempDashLengthP2;


    private void Start()
    {

    }

    void Update()
    {
        CharacterController controllerP2 = GetComponent<CharacterController>();


        if (controllerP2.isGrounded)
        {
            moveDirectionP2 = new Vector3(Input.GetAxis("P2Horizontal"), 0, Input.GetAxis("P2Vertical"));
            moveDirectionP2 = transform.TransformDirection(moveDirectionP2);
            moveDirectionP2 *= speedP2;


            if (Input.GetButton("P2Jump") && controllerP2.isGrounded)
            {
                moveDirectionP2.y = jumpSpeedP2;
            }
        }

        if (Input.GetAxis("P2Dash") == 1 && !isDashingP2)
        {
            isDashingP2 = true;

            if (Input.GetAxis("P2Horizontal") > 0)
            {
                dashVectorP2.x = dashSpeedP2;
            }
            if (Input.GetAxis("P2Horizontal") < 0)
            {
                dashVectorP2.x = dashSpeedP2 * -1;
            }

            if (Input.GetAxis("P2Vertical") > 0)
            {
                dashVectorP2.z = dashSpeedP2;
            }
            if (Input.GetAxis("P2Vertical") < 0)
            {
                dashVectorP2.z = dashSpeedP2 * -1;
            }

            tempDashLengthP2 = dashLengthP2;
        }

        if (isDashingP2)
        {
            tempDashLengthP2--;

            if (tempDashLengthP2 <= 0)
            {
                isDashingP2 = false;
                dashVectorP2 = Vector3.zero;
            }
        }


        moveDirectionP2.y -= gravityP2 * Time.deltaTime;

        controllerP2.Move((moveDirectionP2 + dashVectorP2) * Time.deltaTime);

    }
}
