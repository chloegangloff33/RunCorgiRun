using UnityEngine;

public class Game : MonoBehaviour
{
    public GameTimer GameTimer;
    public UI UI;
    public Corgi Corgi;
public BeerPlacer BeerPlacer;
public BonePlacer BonePlacer;
public PillPlacer PillPlacer;
public MoonshinePlacer MoonshinePlacer;
public bool IsPlaying;

   
    private bool isGameRunning = false;
    
    public void Start()
    {
        UI.HideGameOverScreen();
        UI.ShowStartScreen();
        OnPlayButtonClicked();
    }

    private void OnPlayButtonClicked()
    {
        UI.HideStartScreen();
        InitializeGame();
    }

    private void InitializeGame()
    {
        isGameRunning = true;
        GameTimer.StartTimer(10, OnTimerDone);
        StartPlacers();
        ScoreKeeper.ResetScore();
        UI.ResetScore();
        Corgi.Reset();
    }

    private void StartPlacers()
    {
        BeerPlacer.StartPlacing();
        BonePlacer.StartPlacing();
        PillPlacer.StartPlacing();
        MoonshinePlacer.StartPlacing();
        
    }

    private void OnTimerDone()
    {
        isGameRunning = false;
        UI.ShowGameOverScreen();
        StopPlacers();
    }

    private void StopPlacers()
    {
        BeerPlacer.StopPlacing();
        BonePlacer.StopPlacing();
        PillPlacer.StopPlacing();
        MoonshinePlacer.StopPlacing();
        
    }
    
    public void Update()
    {
        if (isGameRunning)
        {
            UI.ShowTime();
        }
    }
    
    }
    public void IsPlaying()
    {
        return isGameRunning;
    }
    
    public void OnPlayAgainButtonClicked()
    {
        UI.HideGameOverScreen();
        InitializeGame();
    }


    
}
