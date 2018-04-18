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
    public GameObject propCamera;

    private void Awake()
    {
        cannonTarget = GameObject.Find("Cannon Target");
        bossScript = GameObject.Find("Boss Manager").GetComponent<BossControlScriptV2>();


        //propCamera = GetComponentInChildren<Camera>().gameObject;

    }

    void Start () {

        rb=GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, cannonTarget.transform.position, Time.deltaTime * 50);

        if (bossScript.cannonballHits == 2)
        {
            GetComponentInChildren<Camera>().enabled = true;

            //propCamera.SetActive(true);

        }
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
