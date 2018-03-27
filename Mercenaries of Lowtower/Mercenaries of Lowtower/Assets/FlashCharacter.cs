using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashCharacter : MonoBehaviour
{
    public Color flashColour = Color.red;
    public float flashTime = .5f;

    private Renderer m_renderer;

    // Use this for initialization
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown( KeyCode.LeftControl ) )
        {
            StartCoroutine(PumpColour(flashColour, flashTime));
        }
    }

    private IEnumerator PumpColour( Color target, float time )
    {
        float timer = 0;
        while( timer < time )
        {
            timer += Time.deltaTime;
            m_renderer.material.SetColor( "_Colour", Color.Lerp(Color.white, target, Mathf.Pow( (timer / time), 2 ) ) );
            yield return null;
        }

        timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            m_renderer.material.SetColor( "_Colour", Color.Lerp(target, Color.white, timer / time) );
            yield return null;
        }
    }
}
