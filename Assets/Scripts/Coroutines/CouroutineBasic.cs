using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouroutineBasic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Routine");
    }

    IEnumerator Routine()
    {
        Debug.Log("I'm starting the Coroutine!");
        yield return new WaitForSeconds(.5f);
        Debug.Log("I'm updating the Coroutine!");
        yield return new WaitForSeconds(.5f);
        Debug.Log("I'm ending the Coroutine!");
    }
}
