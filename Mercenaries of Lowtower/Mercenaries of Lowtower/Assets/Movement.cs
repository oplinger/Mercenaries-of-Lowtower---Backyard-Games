using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float speed;
    public float dashSpeed;
    public float jumpSpeed;
    public float gravity;
    private Vector3 moveDirection = Vector3.zero;
    Vector3 dashVector = Vector3.zero;

    public bool isDashing=false;
    public float dashLength;
    public float tempDashLength;

    private void Start()
    {
        
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;


            if (Input.GetButton("Jump") && controller.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
        }

        if (Input.GetAxis("Dash") == 1 && !isDashing)
        {
            isDashing = true;

            if (Input.GetAxis("Horizontal") > 0)
            {
                dashVector.x=dashSpeed;
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                dashVector.x = dashSpeed*-1;
            }

            if (Input.GetAxis("Vertical") > 0)
            {
                dashVector.z = dashSpeed;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                dashVector.z = dashSpeed * -1;
            }

            tempDashLength = dashLength;
        }

        if (isDashing)
        {
            tempDashLength--;

            if (tempDashLength <= 0)
            {
                isDashing = false;
                dashVector = Vector3.zero;
            }
        }

        Debug.Log("" + Input.GetAxis("Vertical"));
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move((moveDirection + dashVector) * Time.deltaTime);
    }
}
