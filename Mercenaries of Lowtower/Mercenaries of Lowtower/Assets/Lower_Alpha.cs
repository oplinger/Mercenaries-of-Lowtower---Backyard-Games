using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Lower_Alpha : MonoBehaviour
{
    public float fadeTime;
    public Image removeBlack;

    void Start()
    {
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0.0f;
        Color c = removeBlack.color;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeTime);
            removeBlack.color = c;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0.0f;
        Color c = removeBlack.color;
        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            c.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
            removeBlack.color = c;
            yield return null;
        }
    }
}
