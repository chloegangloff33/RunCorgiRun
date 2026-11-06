using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject TimedObjectPrefab; //prefabs are always GameObjects
    
    public float minimumSecondsToWait = 1f;
    public float maximumSecondsToWait = 3f;

    private bool isOKtoCreate = true;
    private bool isActive = false;
    private Coroutine countdownCoroutine;
    
    void Update()
    {
        if (!isActive)
            return; 
        
        if (isOKtoCreate)
        {
            countdownCoroutine = StartCoroutine(routine:CountdownUntilCreation());
        }
    }
    

    public void StartPlacing()
    {
        isActive = true;
        isOKtoCreate = true;

        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        CleanupPlacedObjects();
    }

    private void CleanupPlacedObjects()
    {
        //find obejects on board
        List<GameObject> placedObjects = GameObject.FindGameObjectsWithTag(TimedObjectPrefab.tag).ToList();

        //destroy them
        for (int i = 0; i < placedObjects.Count; i++)
        {
            Destroy(placedObjects[i]);
        }
    }

    public void StopPlacing()
    {
        isActive = false;
        isOKtoCreate = false;
    }

    IEnumerator CountdownUntilCreation()
    {
        isOKtoCreate = false;
        float secondsToWait = Random.Range(minimumSecondsToWait, maximumSecondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        isOKtoCreate = true;
    }
    protected virtual void Place()
    {
        Instantiate(TimedObjectPrefab, position:SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
