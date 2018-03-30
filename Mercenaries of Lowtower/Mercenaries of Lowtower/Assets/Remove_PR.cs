
 using UnityEngine;
 using System.Collections;
 
 public class Remove_PR : MonoBehaviour
{
    public float time = 2; //Seconds to read the text

    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}


