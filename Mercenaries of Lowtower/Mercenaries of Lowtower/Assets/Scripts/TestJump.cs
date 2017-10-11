using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump : MonoBehaviour {

    public GameObject player;
    Rigidbody playerRb;
    public float jumpForce;
    //MovementRigidbody playerMoveScript;

	// Use this for initialization
	void Start () {
        player = this.gameObject;
        playerRb = GetComponent<Rigidbody>();
        //playerMoveScript = GetComponent<MovementRigidbody>();


    }

    // AddForce jump can be added to movement script
    void FixedUpdate() {

        if (Input.GetButton ("Jump")&&player.GetComponent<MovementRigidbody>().isGrounded)
        {
            //player.GetComponent<MovementRigidbody>().isGrounded = false;
            playerRb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
	}
}
