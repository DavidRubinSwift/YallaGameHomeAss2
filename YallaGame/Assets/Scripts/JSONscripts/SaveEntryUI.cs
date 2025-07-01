using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SaveEntryUI : MonoBehaviour
{
    [Header("UI Elements")]
    public RawImage screenshotImage;     // Display for the save screenshot
    public TMP_Text dateText;            // Display for the save date/time
    public TMP_Text scoreText;           // Display for the player’s score
    public TMP_Text playTimeText;        // Display for the playtime duration

    // Sets up the UI elements using the provided SaveData
    public void Setup(SaveData data)
    {
        if (dateText != null)
            dateText.text = data.saveTime;

        if (scoreText != null)
            scoreText.text = $"Score: {data.playerScore}";

        if (playTimeText != null)
            playTimeText.text = FormatTime(data.elapsedTime);

        // Load and display the screenshot if it exists
        if (screenshotImage != null && File.Exists(data.screenshotPath))
        {
            byte[] bytes = File.ReadAllBytes(data.screenshotPath);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(bytes);
            screenshotImage.texture = tex;
        }
    }

    // Formats elapsed time in seconds as MM:SS
    private string FormatTime(float seconds)
    {
        int mins = Mathf.FloorToInt(seconds / 60);
        int secs = Mathf.FloorToInt(seconds % 60);
        return $"{mins:D2}:{secs:D2}";
    }
}