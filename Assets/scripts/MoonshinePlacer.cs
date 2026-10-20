
using UnityEngine;

public class MoonshinePlacer : TimedObjectPlacer
{
    public void Start()
        {
            minimumSecondsToWait = GameParameters.MoonshineMinimumSecondsToWait;
            maximumSecondsToWait = GameParameters.MoonshineMaximumSecondsToWait;
        }

    protected override void Place()
    {
        Instantiate(TimedObjectPrefab, position:SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
    }
}
