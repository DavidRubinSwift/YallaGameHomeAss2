using UnityEngine;

public delegate void OnControlsChange(bool a);
public class ControlModeManager : MonoBehaviour
{
    public event OnControlsChange ControlsChenged;
    
    [Header("References")]
    public GameObject player; // Перетащи сюда объект игрока

    [Header("Gyro Control Scripts (Group 1)")]
    private MonoBehaviour[] gyroScripts;

    [Header("Buttons Control Scripts (Group 2)")]
    private MonoBehaviour[] buttonsScripts;

    private const string CONTROL_KEY = "ControlType";

    private void Awake()
    {
        // === Автоматически находим и назначаем скрипты ===

        if (player != null)
        {
            // Группа 1
            gyroScripts = new MonoBehaviour[2];
            gyroScripts[0] = player.GetComponent<BallMovement>();
            gyroScripts[1] = player.GetComponent<BallMovementWithJump>();

            // Группа 2
            buttonsScripts = new MonoBehaviour[2];
            buttonsScripts[0] = player.GetComponent<Player2Movement>();
            buttonsScripts[1] = player.GetComponent<BallJump>();
        }
        else
        {
            Debug.LogError("Player reference not assigned in ControlModeManager!");
        }
    }

    private void Start()
    {
        string controlType = PlayerPrefs.GetString(CONTROL_KEY, "Buttons");
        Debug.Log("ControlModeManager: Loaded control type = " + controlType);

        if (controlType == "Gyro")
        {
            EnableScripts(gyroScripts, true);
            EnableScripts(buttonsScripts, false);
            ControlsChenged?.Invoke(false);
        }
        else if (controlType == "Buttons")
        {
            EnableScripts(gyroScripts, false);
            EnableScripts(buttonsScripts, true);
            ControlsChenged?.Invoke(true);
        }
        else
        {
            Debug.LogWarning("Unknown control type, fallback to Buttons mode.");
            EnableScripts(gyroScripts, false);
            EnableScripts(buttonsScripts, true);
        }
    }

    private void EnableScripts(MonoBehaviour[] scripts, bool enable)
    {
        foreach (MonoBehaviour script in scripts)
        {
            if (script != null)
                script.enabled = enable;
        }
    }
}
