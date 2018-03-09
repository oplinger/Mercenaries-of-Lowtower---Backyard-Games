using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbscript : MonoBehaviour {
    GameObject Origin;
    public GameObject Target;
    float healAmount;
    float orbSpeed;
    public float trackingDistance;
    int ID;
    public Collider[] cols;
    public LayerMask PlayerMask;
    float closestDistance;    
    float[] distances;

	// Use this for initialization
	void Start () {
        distances = new float[4];
        closestDistance = 100f;

        //IDamageable damage = (IDamageable)GetComponent(typeof(IDamageable));
        Origin.GetComponent<HealerClass>().currentHealth += healAmount;
       // cols = Physics.OverlapSphere(transform.position, trackingDistance, PlayerMask, QueryTriggerInteraction.Ignore);
        Destroy(gameObject, 20);
    }
	
	// Update is called once per frame
	void Update () {



        //Physics.OverlapSphereNonAlloc(transform.position, trackingDistance, cols, PlayerMask, QueryTriggerInteraction.Ignore);
        
        cols = Physics.OverlapSphere(Origin.transform.position, trackingDistance, PlayerMask, QueryTriggerInteraction.Ignore);
        if (cols != null)
        {
           
            for (int i = 0; i < cols.Length; i++)
            {
                if (Vector3.Distance(Origin.transform.position, cols[i].transform.position) > 1)
                {
                    if (Vector3.Distance(Origin.transform.position, cols[i].transform.position) < closestDistance)
                    {
                        closestDistance = Vector3.Distance(Origin.transform.position, cols[i].transform.position);
                        if (cols[i].gameObject.name != "Healer Character(Clone)")
                        {
                            Target = cols[i].gameObject;
                        }
                    }
                }

            }
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, orbSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, Target.transform.position)<1)
            {
                Target.GetComponent<IDamageable<float>>().TakeDamage(-healAmount);
                Destroy(gameObject);
            }
            closestDistance = 100f;
        }
        else
        {

            transform.Translate(Vector3.forward);

        }
        

        
    }

    public void OrbBehavior(GameObject origin, GameObject target, float healamount, float orbspeed, int playerID)
    {
         Origin=origin;
         //Target=target;
         healAmount=healamount;
         orbSpeed=orbspeed;
         playerID=ID;

        //transform.position = Origin.transform.position;


    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == Target.name)
        //{
            //other.GetComponent<Health>().modifyHealth(-healAmount, ID);
            //other.GetComponent<IDamageable<float>>().TakeDamage(-healAmount);
            //print(Target.name + " healed for " + healAmount);
            //Destroy(gameObject);
       // }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    collision.collider.GetComponent<IDamageable<float>>().TakeDamage(-healAmount);
    //    print(Target.name + " healed for " + healAmount);
    //    Destroy(gameObject);
    //}
}
