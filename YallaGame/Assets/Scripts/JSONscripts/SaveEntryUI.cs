using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SaveEntryUI : MonoBehaviour
{
    [Header("UI Elements")]
    public RawImage screenshotImage;     // ссылка на UI-изображение скриншота
    public TMP_Text dateText;            // ссылка на TMP-объект даты
    public TMP_Text scoreText;           // ссылка на TMP-объект счёта
    public TMP_Text playTimeText;        // ссылка на TMP-объект времени игры

    public void Setup(SaveData data)
    {
        if (dateText != null)
            dateText.text = data.saveTime;

        if (scoreText != null)
            scoreText.text = $"Score: {data.playerScore}";

        if (playTimeText != null)
            playTimeText.text = FormatTime(data.elapsedTime);

        if (screenshotImage != null && File.Exists(data.screenshotPath))
        {
            byte[] bytes = File.ReadAllBytes(data.screenshotPath);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(bytes);
            screenshotImage.texture = tex;
        }
    }

    private string FormatTime(float seconds)
    {
        int mins = Mathf.FloorToInt(seconds / 60);
        int secs = Mathf.FloorToInt(seconds % 60);
        return $"{mins:D2}:{secs:D2}";
    }
}