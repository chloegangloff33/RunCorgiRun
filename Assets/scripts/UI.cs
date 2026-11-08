using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class UI : MonoBehaviour
{
   public static TMP_Text ScoreText;
   public static TMP_Text TimeText;
   public GameTimer GameTimer;
   public CanvasGroup StartScreenCanvasGroup;
   public CanvasGroup GameOverScreenCanvasGroup;
   public string Score { get; set; }


   public void ShowScore()
   {
      ScoreText.text = "Score: " + ScoreKeeper.GetScore();
   }
   public void ResetScore()
   {
      //ScoreText.text = Score = 0;
   }
   
   public void ShowTime()
   {
      TimeText.text = GameTimer.GetTimeAsString();
   }

   public void HideStartScreen()
   {
      CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
      //GameTimer.StartTimer(durationInSeconds: 10, OnTimerFinished);
   }
   
   public void ShowStartScreen()
   {
      CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
   }
   public void ShowGameOverScreen()
   {
      CanvasGroupDisplayer.Show(GameOverScreenCanvasGroup);
   }
   public void HideGameOverScreen()
   {
      CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
   }
   
   

   public void OnTimerFinished()
   {
      
   }
}
