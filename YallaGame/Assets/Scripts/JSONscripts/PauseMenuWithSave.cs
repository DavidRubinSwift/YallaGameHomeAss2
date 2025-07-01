using UnityEngine;

public class PauseMenuWithSave : MonoBehaviour
{
    public GameObject pausePanel;
    public SaveManager saveManager;

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.playerName = "David";
        data.playerScore = 456; 
        data.volume = AudioListener.volume;

        saveManager.SaveGame(data);
    }
}
