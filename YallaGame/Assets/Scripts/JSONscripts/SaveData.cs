using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int playerScore;
    public string playerName;
    public float volume;

    public string saveTime;        // date and time
    public float elapsedTime;         // second of gameplay
    public string screenshotPath;  // path to file
}