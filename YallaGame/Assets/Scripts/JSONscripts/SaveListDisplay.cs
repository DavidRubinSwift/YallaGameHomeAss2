using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SaveListDisplay : MonoBehaviour
{
    public GameObject saveButtonPrefab;       
    public Transform contentParent;           
    private string saveDirectory;

    void Start()
    {
        saveDirectory = Application.persistentDataPath;
        PopulateSaveList();
    }

    void PopulateSaveList()
    {
        // Remove old buttons if they already exist
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Get all .json files
        string[] saveFiles = Directory.GetFiles(saveDirectory, "*.json");

        foreach (string path in saveFiles)
        {
            string fileName = Path.GetFileName(path);

            // Create a UI element (e.g., TMP_Text or a button)
            GameObject buttonGO = Instantiate(saveButtonPrefab, contentParent);
            TMP_Text text = buttonGO.GetComponentInChildren<TMP_Text>();
            if (text != null)
            {
                text.text = fileName;
            }

            // Optionally, you can add click handling here later
        }

        if (saveFiles.Length == 0)
        {
            Debug.Log("No save files found.");
        }
    }
}