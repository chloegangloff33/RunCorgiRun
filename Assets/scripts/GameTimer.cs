using System;
using System.Collections;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private int timeRemaining;
    private bool isStopped;
    public GameParameters GameParameters;
    
    private Action methodToCallWhenTimeIsOver;
    
    public void StartTimer(int GameDurationInSeconds, 
        Action methodToCallWhenTimeIsOver)
    {
        this.methodToCallWhenTimeIsOver = methodToCallWhenTimeIsOver;
        isStopped = false;
        timeRemaining = GameDurationInSeconds;
        StartCoroutine(TickOneSecond());
    }

    public void StopTimer()
    {
        timeRemaining = 0;
        isStopped = true;
        methodToCallWhenTimeIsOver.Invoke();
    }

    public string GetTimeAsString()
    {
        int minutes = timeRemaining / 60;
        int seconds = timeRemaining - (minutes * 60);
        string minutesAsString = String.Format("{0:00}", minutes);
        string secondsAsString = String.Format("{0:00}", seconds);
        
        return minutesAsString + ":" + secondsAsString;
    }

    public bool IsRunning()
    {
        return !isStopped;
    }

    IEnumerator TickOneSecond()
    {
        yield return new WaitForSeconds(1);

        if (!isStopped)
        {
            timeRemaining = timeRemaining - 1;
            if (timeRemaining > 0)
            {
                StartCoroutine(TickOneSecond());
            }
            else
            {
                StopTimer();
            }
        }
    }
}
