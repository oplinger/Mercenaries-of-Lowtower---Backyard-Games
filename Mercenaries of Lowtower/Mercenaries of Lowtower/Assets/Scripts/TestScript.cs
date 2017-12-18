using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour {
    private void Awake()
    {
        gameObject.AddComponent<MeleeClass>();
    }
}
