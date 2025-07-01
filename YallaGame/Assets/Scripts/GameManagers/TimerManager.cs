using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public PauseMenuMobile _PauseMenuMobile;
    public UIManager _UIManager;

    public float elapsedTime = 0f; // now we count the ELAPSED time

    void Update()
    {
        if (_PauseMenuMobile == null || _UIManager == null)
            return;

        if (!_PauseMenuMobile.gamePaused)
        {
            // Just increment the time each frame
            elapsedTime += Time.deltaTime;
        }

        // Pass the rounded time to the UI
        _UIManager.UpdateUITimer(Mathf.FloorToInt(elapsedTime));
    }
}