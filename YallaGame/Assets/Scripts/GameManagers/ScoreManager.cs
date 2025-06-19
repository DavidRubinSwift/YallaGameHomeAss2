using System;
using UnityEngine;

public delegate void OnScoreChanging (float x);
public class ScoreManager : MonoBehaviour
{
    public event OnScoreChanging ScoreChanging;
    
    public UIManager _UIManager;
    public BallMovement _ballMovement;
    public PauseMenuMobile _PauseMenuMobile;
    
    public float playerScore = 0;
    public float regularScore = 100;

    private void Update()
    {
        if (!_PauseMenuMobile.gamePaused)
        {
            float increaseFactor = FCounter();
            playerScore += (regularScore + Mathf.Round(increaseFactor * Time.deltaTime))/100;

        }
        ScoreChanging?.Invoke(playerScore);
        
    }

    private float FCounter()
    {
        return Mathf.Pow(_ballMovement.moveSpeed, 1.2f) / 3f;
            
    }
    
}
