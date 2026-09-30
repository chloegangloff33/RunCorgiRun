using System.Collections;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    public float secondsOnScreen = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        //start death clock
        StartCoroutine(CountdownUntilDeath());
        
        //countdown and then go away
        IEnumerator CountdownUntilDeath()
        {
            yield return new WaitForSeconds(GameParameters.PoopSecondsOnScreen);
            Destroy(gameObject);
        }
    }
}
