using System.Collections;
using UnityEngine;

public class Poop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //start death clock
        StartCoroutine(CountdownUntilDeath());
        
        //countdown and then go away
        IEnumerator CountdownUntilDeath()
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
    
}
