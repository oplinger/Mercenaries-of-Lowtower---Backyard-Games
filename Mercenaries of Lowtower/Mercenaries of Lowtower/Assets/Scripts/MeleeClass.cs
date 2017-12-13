using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeClass : MonoBehaviour, IJumpable<float> {
    public int grounded;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //grounded = JumpCheck();

        if (grounded > 0)
        {
            Jump(5);
        }
    }

    public void Jump(float jumpHeight)
    {
        GetComponent<Rigidbody>().AddForce(0, jumpHeight, 0, ForceMode.Impulse);

    }

}
