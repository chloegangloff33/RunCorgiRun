using UnityEngine;

public class WaterBowlPlacer : TimedObjectPlacer
{
    public void Start()
    {
        minimumSecondsToWait = GameParameters.WaterBowlMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.WaterBowlMaximumSecondsToWait;
    }
}
