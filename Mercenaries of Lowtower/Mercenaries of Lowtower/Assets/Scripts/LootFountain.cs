using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootFountain : MonoBehaviour {
    public GameObject[] Loot;
    //public List<GameObject> Lootfountain;
    public float lootAmount;
    public float timer;
    public float timer1;
    public int lootCount;

	// Use this for initialization
	void Start () {
        Loot = new GameObject[4];
        Loot[0] = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Loot[0].AddComponent<Rigidbody>();
        Loot[1] = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Loot[1].AddComponent<Rigidbody>();

        Loot[2] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Loot[2].AddComponent<Rigidbody>();

        Loot[3] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        Loot[3].AddComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        timer1 += Time.deltaTime;
        if (timer1 < 20)
        {
            if (timer > .001f)
            {
                StartCoroutine(_LootFountain());
                timer = 0;
                print(lootCount);
            }
        }
    }
    IEnumerator _LootFountain()
    {
        GameObject clone;
        clone = Instantiate(Loot[Random.Range(0, 4)], transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(Random.Range(-1, 1), Random.Range(25, 150), Random.Range(-1, 1), ForceMode.Impulse);
        lootCount++;

        GameObject clone2;
        clone2 = Instantiate(Loot[Random.Range(0, 4)], transform.position, Quaternion.identity);
        clone2.GetComponent<Rigidbody>().AddForce(Random.Range(-1, 1), Random.Range(25, 150), Random.Range(-1, 1), ForceMode.Impulse);
        lootCount++;

        GameObject clone3;
        clone3 = Instantiate(Loot[Random.Range(0, 4)], transform.position, Quaternion.identity);
        clone3.GetComponent<Rigidbody>().AddForce(Random.Range(-1, 1), Random.Range(25, 150), Random.Range(-1, 1), ForceMode.Impulse);
        lootCount++;

        GameObject clone4;
        clone4 = Instantiate(Loot[Random.Range(0, 4)], transform.position, Quaternion.identity);
        clone4.GetComponent<Rigidbody>().AddForce(Random.Range(-1, 1), Random.Range(25, 150), Random.Range(-1, 1), ForceMode.Impulse);
        lootCount++;
        //for (int i = 0; i<lootAmount; i++)
        //{

        //}

        yield return new WaitForSeconds(0);

    }
}
