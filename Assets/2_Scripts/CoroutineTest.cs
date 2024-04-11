using System.Collections;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{ 
    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        int counter = 0;
        while (true)
        {
            Debug.Log(counter); 
            counter++;
            yield return new WaitForSeconds(1);
        }
    }
}


