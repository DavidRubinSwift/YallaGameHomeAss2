using UnityEngine;

public class LoadMenuSwitcher : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject loadMenuPanel;

    // Show panels
    public void OpenLoadMenu()
    {
        mainMenuPanel.SetActive(false);
        loadMenuPanel.SetActive(true);
    }

    // return to main menu
    public void BackToMainMenu()
    {
        loadMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
