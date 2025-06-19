using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string filePath;

    void Awake()
    {
        filePath = Application.persistentDataPath + "/save.json";
    }

    public void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Game saved at: " + filePath);
    }

    public SaveData LoadGame()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return null;
        }
    }
}
