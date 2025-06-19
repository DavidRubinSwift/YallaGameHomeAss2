using UnityEngine;

public class CreditsWindow : MonoBehaviour
{
    public GameObject creditsPanel;      // Панель с авторами
    public GameObject settingsPanel;     // Панель настроек

    // Открыть окно с авторами
    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    // Вернуться в настройки
    public void BackToSettings()
    {
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}
