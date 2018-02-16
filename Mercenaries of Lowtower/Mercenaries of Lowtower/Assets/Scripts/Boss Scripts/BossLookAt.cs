using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAt : MonoBehaviour {

    public List<Transform> PlayerList = new List<Transform>();
    public Transform target;
    public float speed;
    public bool isCharging;


	// Use this for initialization
	void Start () {
        isCharging = true;
        target = PlayerList[Random.Range(0, 3)].GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(isCharging == true)
        {
            //Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            //transform.LookAt(targetPosition);

            Vector3 direction = target.position - transform.position;
            direction.y = 0;

            Quaternion toRotation = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.LookRotation(transform.rotation, toRotation);

            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * speed);
            Debug.DrawLine(transform.position, target.position, Color.red);
        }
        else
        {

        }
	}

    public void TargetPlayer()
    {
        target = PlayerList[Random.Range(0, 3)].GetComponent<Transform>();
    }
}
