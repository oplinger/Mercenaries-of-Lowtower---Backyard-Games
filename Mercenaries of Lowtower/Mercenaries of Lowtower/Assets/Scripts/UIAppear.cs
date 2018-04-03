using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    [SerializeField] private Text customText;
    public GameObject arrow;
    public Transform arrowLocation;
    public GameObject arrowClone;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customText.enabled = true;
           arrowClone = Instantiate(arrow, arrowLocation);
        }
    }



        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                customText.enabled = false;
                Destroy(arrowClone);
            }
        }
}
