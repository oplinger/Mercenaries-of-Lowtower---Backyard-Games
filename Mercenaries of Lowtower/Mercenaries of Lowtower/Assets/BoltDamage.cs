using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDamage : MonoBehaviour {
    public Health health;
    public GameObject controller;
    Renderer targetRenderer;
    public GameObject hitMarker;
    // Use this for initialization
    void Start () {
        controller = GameObject.Find("Controller Thing");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss")
        {
            Color colorflash = new Color(.047f, .756f, .066f);
            other.GetComponent<BossClass>().PlayerColorFlash(colorflash);
            other.GetComponent<IDamageable<float>>().TakeDamage(3);
            Instantiate(hitMarker, transform.position, Quaternion.identity);
        }

        if (other.tag == "Enemy")
        {
            other.GetComponent<AIControllerNavMesh>().PlayerColorFlash2();
            other.GetComponent<IDamageable<float>>().TakeDamage(3);
            Instantiate(hitMarker, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


        if (other.tag == "Tentacle" || other.tag == "TRTarget")
        {
            other.GetComponent<IDamageable<float>>().TakeDamage(3);
            Instantiate(hitMarker, transform.position, Quaternion.identity);

            if (other.tag == "Tentacle")
            {
                Color colorflash = new Color(.047f, .756f, .066f);
                other.GetComponent<TentacleSlamDamage>().PlayerColorFlash(colorflash);
                Instantiate(hitMarker, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);

           
        }

    }
   }
 
