using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    [SerializeField] private Text customText;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customText.enabled = true;
        }
    }



        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                customText.enabled = false;
            }
        }
}
