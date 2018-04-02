using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankArm : MonoBehaviour {

    public TankClass baseClass;
    public GameObject rayCaster;
    public GameObject[] armJoint;
    public GameObject target;
    public GameObject grabbedTentacle;
    public Vector3 offset;
    public Vector3[] defaultJointPosition;
    public LayerMask tankArmMask;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawRay(rayCaster.transform.position, rayCaster.transform.forward * 10);

        if (Input.GetKeyDown("joystick " + 1 + " button " + "1") && baseClass.abilityCooldowns.cooldowns["magnetCD"]<=0)
        {

            RaycastHit hit;
            Physics.Raycast(rayCaster.transform.position, rayCaster.transform.forward*10, out hit, 10, tankArmMask);

            for (int i = 0; i < armJoint.Length; i++)
            {
                defaultJointPosition[i] = armJoint[i].transform.localPosition;

            }

            if (hit.collider != null)
            {

                target = hit.collider.gameObject;
                if (target.GetComponent<TentacleSlamDamage>() != null)
                {
                    print("oihiu");

                    target.GetComponent<TentacleSlamDamage>().tentacle.GetComponent<BossTentacleScript>().tentacleGrabbed = true;
                }
                offset = armJoint[2].transform.position - armJoint[1].transform.position;
                armJoint[1].transform.position = hit.point;
                armJoint[2].transform.position = hit.point - transform.right * 3;
                armJoint[1].transform.localScale = new Vector3(1.5f,10,10);

                //armJoint[2].transform.localScale *= 10;
            } else
            {
                return;
            }
        }
        // Tags or names can be used to create different actions. Or call different functions. (functions would be more efficient). So the arm can grab minions, and pull them back to the tank. Replace target with an overlap sphere array
        // and you can grab multiple. 
        if (Input.GetKeyUp("joystick " + 1 + " button " + "1") && baseClass.abilityCooldowns.cooldowns["magnetCD"] <= 0)
        {
            //if(target!= null)
            //{
            //    if (target.tag == "Tentacle")
            //    {
            //        print("tentacle detected");
            //        grabbedTentacle = target.GetComponent<TentacleGrabScript>().dmgDetector;
            //        if (target.GetComponent<TentacleGrabScript>().dmgDetectorActivated == true)
            //        {
            //            grabbedTentacle.GetComponent<BossTentacleScript>().FreezeTentacle();
            //        }
            //    }
            //}
            
            if (target != null)
            {
                print("arm should let go");

                armJoint[1].transform.localScale = new Vector3(1,1,1);
                target.transform.parent = armJoint[2].transform;
                armJoint[1].transform.localPosition = defaultJointPosition[1];
                armJoint[2].transform.localPosition = defaultJointPosition[2];

                //armJoint[1].transform.position = defaultJointPosition[1]-new Vector3(1,0,1);
                //armJoint[1].transform.position = Vector3.MoveTowards(armJoint[1].transform.position, defaultJointPosition[1], 6);
                target.transform.parent = null;
                target = null;

                baseClass.abilityCooldowns.cooldowns["magnetCD"] = baseClass.abilityCooldowns.magnetCD;
            } else
            {
                baseClass.abilityCooldowns.cooldowns["magnetCD"] = .2f;

                
            }

        }
    }
}
