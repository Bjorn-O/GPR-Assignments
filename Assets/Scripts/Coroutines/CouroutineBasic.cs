using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouroutineBasic : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float fadeTime;
    [Range(0.0f, 10.0f)]
    public float speed;

    private bool isFading;
    private bool isFaded;

    private bool isMoving;

    public Transform destination;
    private Vector3 tempDestination;

    // Start is called before the first frame update
    void Start()
    {
        isFaded = false;
        isMoving = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isFading)
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
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            StartCoroutine("MoveOut");
        }
    }

    IEnumerator MoveOut()
    {
        isMoving = true;
        tempDestination = this.transform.position;
        Debug.Log("Test");
        while (Vector3.Distance(transform.position, destination.position) > 0.001f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
            yield return null;
        }
        Debug.Log(tempDestination);
        destination.position = tempDestination;
        isMoving = false;
        yield return null;
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
