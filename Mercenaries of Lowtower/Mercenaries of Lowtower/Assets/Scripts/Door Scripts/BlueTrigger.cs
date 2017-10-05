using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTrigger : MonoBehaviour {

    public GameObject door;
    bool trigger = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && trigger == true)
        {
            door.transform.position += new Vector3(0, 1, 0);
            trigger = false;
            //door moves up
        }
    }
}

