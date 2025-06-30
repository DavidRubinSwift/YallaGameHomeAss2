using UnityEngine;

public class MilestoneCelebration : MonoBehaviour
{
    public ParticleSystem fireworks;
    public Transform playerTransform; // Сюда в инспекторе укажи игрока
    public Vector3 offsetAbovePlayer = new Vector3(0, 2f, 0); // Смещение фейерверка вверх

    private void OnEnable()
    {
        GameEvents.OnMilestoneReached += PlayFireworksAbovePlayer;
    }

    private void OnDisable()
    {
        GameEvents.OnMilestoneReached -= PlayFireworksAbovePlayer;
    }

    private void PlayFireworksAbovePlayer(int score)
    {
        if (fireworks != null && playerTransform != null)
        {
            fireworks.transform.position = playerTransform.position + offsetAbovePlayer;
            fireworks.Play();
        }
    }
}