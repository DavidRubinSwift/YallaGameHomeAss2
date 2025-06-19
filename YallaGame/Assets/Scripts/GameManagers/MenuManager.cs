
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    // Вызывается при нажатии кнопки "Start Game"
    public void StartGame()
    {
        SceneManager.LoadScene("NewPlayZone");
    }

    // Вызывается при нажатии кнопки "Load"
    public void LoadGame()
    {
        // Пока ничего не происходит
        Debug.Log("Load Game — функция пока не реализована");
    }

    // Вызывается при нажатии кнопки "Settings"
    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsMenu"); // Загружаем сцену настроек
    }

    // Вызывается при нажатии кнопки "Exit"
    public void ExitGame()
    {
        Debug.Log("Игра закрывается...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // выход из Play Mode
#else
    Application.Quit(); // Закрываем приложение (работает только в сборке)
#endif
    }

}




/*

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene"); 
    }
    {
        public void StartGame()
        {
            SceneManager.LoadScene("PlayScene"); 
        }
        
        public void LoadMikeScene()
        {
            SceneManager.LoadScene("Mike"); 
        }
    
       
        public void LoadDavidScene()
        {
            SceneManager.LoadScene("David"); 
        }
    
        // Выход из игры или Play Mode
        public void ExitGame()
        {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // выход из Play Mode
    #else
            Application.Quit(); // выход из билда
    #endif
        }asd
    }
    public void LoadMikeScene()
    {
        SceneManager.LoadScene("Mike"); 
    }

   
    public void LoadDavidScene()
    {
        SceneManager.LoadScene("David"); 
    }

    // Выход из игры или Play Mode
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // выход из Play Mode
#else
        Application.Quit(); // выход из билда
#endif
    }
}
*/

