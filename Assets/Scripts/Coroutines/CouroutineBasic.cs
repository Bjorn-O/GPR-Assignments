using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouroutineBasic : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float fadeTime;
    private bool isFading;
    private bool isFaded;

    // Start is called before the first frame update
    void Start()
    {
        isFaded = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFading)
        {
            switch (isFaded)
            {
                case true:
                StartCoroutine("FadeIn");
                break;

                case false:
                StartCoroutine("FadeOut");
                break;
            }
        }
    }

    IEnumerator FadeOut()
    {
        isFading = true;
        for (float ft = 1f; ft >= 0; ft -= 0.01f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = ft;
            GetComponent<Renderer>().material.color = c;
            Debug.Log("I'm fading out");
            yield return new WaitForSeconds(fadeTime/100);
        }
        Debug.Log("JOBS DONE");
        isFading = false;
        isFaded = true;
    }

    IEnumerator FadeIn()
    {
        isFading = true;
        for (float ft = 0f; ft <= 1; ft += 0.01f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = ft;
            GetComponent<Renderer>().material.color = c;
            Debug.Log("I'm fading in");
            yield return new WaitForSeconds(fadeTime/100);
        }
        Debug.Log("JOBS DONE");
        isFading = false;
        isFaded = false;
    }
}
