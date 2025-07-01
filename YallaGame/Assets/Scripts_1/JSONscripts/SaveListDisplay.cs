using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SaveListDisplay : MonoBehaviour
{
    public GameObject saveButtonPrefab;       // Префаб кнопки или текста
    public Transform contentParent;           // Контейнер для списка
    private string saveDirectory;

    void Start()
    {
        saveDirectory = Application.persistentDataPath;
        PopulateSaveList();
    }

    void PopulateSaveList()
    {
        // Удаляем старые кнопки, если уже были
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Получаем все .json файлы
        string[] saveFiles = Directory.GetFiles(saveDirectory, "*.json");

        foreach (string path in saveFiles)
        {
            string fileName = Path.GetFileName(path);

            // Создаём UI элемент (например, TMP_Text или кнопку)
            GameObject buttonGO = Instantiate(saveButtonPrefab, contentParent);
            TMP_Text text = buttonGO.GetComponentInChildren<TMP_Text>();
            if (text != null)
            {
                text.text = fileName;
            }

            // При желании можно позже добавить сюда обработку кликов
        }

        if (saveFiles.Length == 0)
        {
            Debug.Log("No save files found.");
        }
    }
}