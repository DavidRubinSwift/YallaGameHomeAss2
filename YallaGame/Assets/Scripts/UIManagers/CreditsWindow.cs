using UnityEngine;

public class CreditsWindow : MonoBehaviour
{
    public GameObject creditsPanel;      
    public GameObject settingsPanel;     

    // open credits panel
    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    // return to settings
    public void BackToSettings()
    {
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
