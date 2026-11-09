
using UnityEngine;

public class MoonshinePlacer : TimedObjectPlacer
{
    public Sounds Sounds;
    
    public void Start()
        {
            minimumSecondsToWait = GameParameters.MoonshineMinimumSecondsToWait;
            maximumSecondsToWait = GameParameters.MoonshineMaximumSecondsToWait;
        }

    protected override void Place()
    {
        Instantiate(TimedObjectPrefab, position:SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
        Sounds.PlayFallingSound();
    }
}
