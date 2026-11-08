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
    private bool isPlaying;

   
    private bool isOKtoCreate = false;
    
    public void Start()
    {
        UI.HideGameOverScreen();
        UI.ShowStartScreen();
        OnPlayButtonClicked();
    }

    public bool IsPlaying()
    {
        return isOKtoCreate;
    }

    private void OnPlayButtonClicked()
    {
        UI.HideStartScreen();
        InitializeGame();
    }

    private void InitializeGame()
    {
        isOKtoCreate = true;
        GameTimer.StartTimer(10, OnTimerDone);
        StartPlacers();
        ScoreKeeper.ResetScore();
        UI.ResetScore();
        Corgi.Reset();
    }

    private void StartPlacers()
    {
        isPlaying = true;
        isOKtoCreate = true;
        BeerPlacer.StartPlacing();
        BonePlacer.StartPlacing();
        PillPlacer.StartPlacing();
        MoonshinePlacer.StartPlacing();
    }

    private void OnTimerDone()
    {
        isOKtoCreate = false;
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
        if (!isPlaying)
            return;
        
        if (isOKtoCreate)
        {
            UI.ShowTime();
        }
    }
    
}
