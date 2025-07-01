using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneAsync(string NewPlayZone)
    {
        StartCoroutine(LoadSceneCoroutine(NewPlayZone));
    }

    private IEnumerator LoadSceneCoroutine(string NewPlayZone)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NewPlayZone);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}