using System.Collections;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject TimedObjectPrefab; //prefabs are always GameObjects
    
    private bool isOKtoCreate = true;
    
    public float minimumSecondsToWait = 1f;
    public float maximumSecondsToWait = 3f;

    public void Update()
    {
        if (isOKtoCreate)
        {
            StartCoroutine(routine:CountdownUntilCreation());
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        isOKtoCreate = false;
        float secondsToWait = Random.Range(minimumSecondsToWait, maximumSecondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        isOKtoCreate = true;
    }
    public void Place()
    {
        Instantiate(TimedObjectPrefab, position:SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
