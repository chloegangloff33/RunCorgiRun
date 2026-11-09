
using System.Collections;
using UnityEngine;

public class BonePlacer : TimedObjectPlacer
{
    public Sounds Sounds;

    public void Start()
    {
        minimumSecondsToWait = GameParameters.BoneMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.BoneMaximumSecondsToWait; 
    }
}
