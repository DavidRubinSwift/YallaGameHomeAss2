using UnityEngine;

public class MainMenuSwitcher : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsMenuPanel;

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsMenuPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        settingsMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
