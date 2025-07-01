using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Called when the "Start Game" button is pressed
    public void StartGame()
    {
        SceneManager.LoadScene("NewPlayZone");
    }

    // Called when the "Load" button is pressed
    public void LoadGame()
    {
        // Not implemented yet
        Debug.Log("Load Game — function not implemented yet");
    }

    // Called when the "Settings" button is pressed
    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsMenu"); // Load the settings scene
    }

    // Called when the "Exit" button is pressed
    public void ExitGame()
    {
        Debug.Log("Game is closing...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // exit Play Mode
#else
        Application.Quit(); // Quit the application (works only in build)
#endif
    }
}