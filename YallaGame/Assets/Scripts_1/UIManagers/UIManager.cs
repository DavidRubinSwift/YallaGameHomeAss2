using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerHealth _PlayerHealth;
    public ScoreManager _ScoreManager;
    public ControlModeManager _ControlModeManager;
    
    public TextMeshProUGUI hpTextField;
    public TextMeshProUGUI scoreTextField;
    public TextMeshProUGUI timerTextField;


    public GameObject controlButtons;

    private void Start()
    {
        _ScoreManager.ScoreChanging += UpdateUIScore;
        _ControlModeManager.ControlsChenged += ActivateControllsButtons;
        UpdateUIScore(0);
        UpdateUIHP();
    }
    
    public void UpdateUITimer(int secondsLeft)
    {
       //Debug.Log("Timer updated: " + secondsLeft);
        timerTextField.text = secondsLeft.ToString();
    }

    
    public void UpdateUIHP()
    {
        hpTextField.text = _PlayerHealth.currentHealth.ToString();
    }
    
    public void UpdateUIScore(float score)
    {
        scoreTextField.text = score.ToString();
    }

    public void ActivateControllsButtons(bool status)
    {
       controlButtons.gameObject.SetActive(status); 
    }
    
}
