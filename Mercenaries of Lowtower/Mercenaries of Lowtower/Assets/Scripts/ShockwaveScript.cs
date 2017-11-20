using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveScript : MonoBehaviour {
    float shockwaveStrength;
    float shockwaveDamage;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update () {

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.position.y < transform.position.y + 5 && other.tag=="Player")
        {
            Collider[] col = Physics.OverlapSphere(other.transform.position, .02f, 1 << 8, QueryTriggerInteraction.Ignore);
            for (int i = 0; i < col.Length; i++)
            {
                col[i].GetComponent<Health>().modifyHealth(10, 9);
                print("10 DAMAGE DONE TO: " + col[i].gameObject.name);
                col[i].GetComponent<Rigidbody>().AddForce((col[i].transform.position - transform.position) * shockwaveStrength);
            }
        }
    }

   public void ShockwaveStats(float shockwavestrength, float shockwavedamage )
    {
        shockwaveDamage = shockwavedamage;
        shockwaveStrength = shockwavestrength;
    }
}
