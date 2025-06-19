using UnityEngine;

public class LoadMenuSwitcher : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject loadMenuPanel;

    // Показывает панель загрузки и скрывает главное меню
    public void OpenLoadMenu()
    {
        mainMenuPanel.SetActive(false);
        loadMenuPanel.SetActive(true);
    }

    // Возвращает в главное меню из панели загрузки
    public void BackToMainMenu()
    {
        loadMenuPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
