using UnityEngine;

public class BeerPlacer : MonoBehaviour
{ 
    public GameObject BeerPrefab; //prefabs are always GameObjects

    public void Update()
    {
        StartCoroutine(routine:CountdownUntilCreation());
    }

    IEnumerator CountdownUntilCreation()
    {
        yield return new WaitForSeconds(5f);
        Place();
    }
   public void Place()
   {
     Instantiate(BeerPrefab, position:SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
   }
    
}
