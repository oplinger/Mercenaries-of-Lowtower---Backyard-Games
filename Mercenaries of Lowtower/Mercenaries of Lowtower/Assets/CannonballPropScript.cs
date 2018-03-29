using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballPropScript : MonoBehaviour {

    //public GameObject phaseController;
    //PhaseControllerScript phaseControllerScript;
    //Transform originalPosition;

    Rigidbody rb;
    public GameObject cannonTarget;
    public BossControlScriptV2 bossScript;

    private void Awake()
    {
        cannonTarget = GameObject.Find("Cannon Target");
        bossScript = GameObject.Find("Boss Manager").GetComponent<BossControlScriptV2>();
    }

    void Start () {

        rb=GetComponent<Rigidbody>();
        //phaseControllerScript = phaseController.GetComponent<PhaseControllerScript>();
        //originalPosition.position = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        transform.position = Vector3.MoveTowards(transform.position, cannonTarget.transform.position,Time.deltaTime*50);
        //rb.AddForce(-3, 2, 3, ForceMode.Impulse);

        //if (phaseControllerScript.cannonFired)
        //{
        //    this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(5, 0, 5));
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss")
        {
            bossScript.cannonballHits++;
            bossScript.cannonFired = true;
            print("ball hit the boss");
            Destroy(gameObject);
            //transform.position = originalPosition.position;
        }
    }
}
