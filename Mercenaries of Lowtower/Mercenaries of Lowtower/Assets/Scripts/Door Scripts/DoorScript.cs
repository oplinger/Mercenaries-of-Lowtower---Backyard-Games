using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    private Animator _animator = null;

    private void Start()
    {
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        _animator.SetBool("isopen", true);
    }

    void OnTriggerExit(Collider collider)
    {
        _animator.SetBool("isopen", false);
    }
}
