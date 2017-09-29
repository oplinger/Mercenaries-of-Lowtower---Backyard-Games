using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody : MonoBehaviour {

    Rigidbody playerRigidbody;
    public GameObject player;
    Vector3 moveDirection = Vector3.zero;
    public float speed;

	// Use this for initialization
	void Start () {

        player = this.gameObject;
        playerRigidbody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

        moveDirection = new Vector3(Input.GetAxis("Horizontal")*speed*Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        moveDirection *= speed;

        playerRigidbody.velocity = moveDirection;
        //controller.Move((moveDirection + dashVector) * Time.deltaTime);


    }

    public void Jump(Vector3 jumpDirection)
    {



    }
}
