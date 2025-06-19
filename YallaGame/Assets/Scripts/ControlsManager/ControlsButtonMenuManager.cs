using System;
using UnityEngine;
using UnityEngine.UI;

public class ControlsButtonMenuManager : MonoBehaviour
{
    public Button chooseControlsButton;
    public Button giroControlsButton;
    public Button buttonsControlsButton;

    private const string CONTROL_KEY = "ControlType";

    private void Start()
    {
        giroControlsButton.gameObject.SetActive(false);
        buttonsControlsButton.gameObject.SetActive(false);
    }

    public void ActivateChoice()
    {
        chooseControlsButton.gameObject.SetActive(false);
        giroControlsButton.gameObject.SetActive(true);
        buttonsControlsButton.gameObject.SetActive(true);
    }
    
    public void GiroControls()
    {
        chooseControlsButton.gameObject.SetActive(true);
        giroControlsButton.gameObject.SetActive(false);
        buttonsControlsButton.gameObject.SetActive(false);
        Debug.Log("Gyro selected");
        PlayerPrefs.SetString(CONTROL_KEY, "Gyro");
    }
    
    public void ButtonsControls()
    {
        chooseControlsButton.gameObject.SetActive(true);
        giroControlsButton.gameObject.SetActive(false);
        buttonsControlsButton.gameObject.SetActive(false);
        Debug.Log("Buttons selected");
        PlayerPrefs.SetString(CONTROL_KEY, "Buttons");
    }
    
}
