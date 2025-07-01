using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public PauseMenuMobile _PauseMenuMobile;
    public UIManager _UIManager;

    public float elapsedTime = 0f; // теперь мы считаем ПРОШЕДШЕЕ время

    void Update()
    {
        if (_PauseMenuMobile == null || _UIManager == null)
            return;

        if (!_PauseMenuMobile.gamePaused)
        {
            // Просто наращиваем время каждый кадр
            elapsedTime += Time.deltaTime;
        }

        // Передаём округлённое время в UI
        _UIManager.UpdateUITimer(Mathf.FloorToInt(elapsedTime));
    }
}