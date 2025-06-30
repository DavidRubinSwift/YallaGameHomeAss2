using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static event Action<int> OnMilestoneReached;

    public static void MilestoneReached(int score)
    {
        OnMilestoneReached?.Invoke(score);
    }
}