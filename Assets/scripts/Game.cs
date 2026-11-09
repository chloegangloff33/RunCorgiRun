using UnityEngine;

public class Game : MonoBehaviour
{
    //static can't inherit from things
    public GameTimer GameTimer;
    public UI UI;
    public Corgi Corgi;
    public BeerPlacer BeerPlacer;
    public BonePlacer BonePlacer;
    public PillPlacer PillPlacer;
    public MoonshinePlacer MoonshinePlacer;
    private bool isPlaying;
    private bool isOKtoCreate = false;

    public Music Music;
    public Sounds Sounds;
    
    
    public void Start()
    {
        UI.ShowStartScreen();
        UI.HideGameOverScreen();
        Music.PlayMenuMusic();
    }

    public bool IsPlaying()
    {
        return isOKtoCreate;
    }

    public void OnPlayButtonClicked()
    {
        UI.HideStartScreen();
        Sounds.PlayPoopSound();
        InitializeGame();
    }

    private void InitializeGame()
    {
        isOKtoCreate = true;
        GameTimer.StartTimer(60, OnTimerDone);
        StartPlacers();
        ScoreKeeper.ResetScore();
        UI.ResetScore();
        Corgi.Reset();
        Music.PlayGameMusic();
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
        Music.PlayMenuMusic();
    }

    private void StopPlacers()
    {
        BeerPlacer.StopPlacing();
        BonePlacer.StopPlacing();
        PillPlacer.StopPlacing();
        MoonshinePlacer.StopPlacing();
        
    }

    public void OnPlayAgainButtonClicked()
    {
        UI.HideGameOverScreen();
        Sounds.PlayPoopSound();
        InitializeGame();
    }
    
    public void Update()
    {
        if (isOKtoCreate)
        {
            UI.ShowTime();
        }
        if (!isPlaying)
            return;
    }
    
}
