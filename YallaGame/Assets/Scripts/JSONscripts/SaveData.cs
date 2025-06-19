using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int playerScore;
    public string playerName;
    public float volume;

    public string saveTime;        // дата и время сохранения
    public float elapsedTime;         // сколько секунд прошло в игре
    public string screenshotPath;  // путь до скриншота
}