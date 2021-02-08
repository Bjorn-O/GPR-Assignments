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
        for (float ft = 10; ft > 0; ft--)
        {
            Debug.Log("I'm Updating the Coroutine!");
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("I'm ending the Coroutine!");
    }
}
