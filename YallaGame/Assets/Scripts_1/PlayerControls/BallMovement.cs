using System;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public PlayerSettings _PlayerSettings;

    public PlayerAnimatorController _PlayerAnimator;
    //public GameObject graficRotation;

    public float moveSpeed;
    private float sideSpeed;

    private float minX = -1.4f;
    private float maxX = 1.4f;

    private float acceleration = 4f;
    private float maxSpeed = 12f;
    private float minSpeed = 2f;

    private Gyroscope gyro;
    private bool gyroAvailable;

        private void Start()
    {
        moveSpeed = _PlayerSettings.playerMoveSpeed;
        sideSpeed = _PlayerSettings.playerSideSpeed;

        // Включаем гироскоп
        gyroAvailable = SystemInfo.supportsGyroscope;
        if (gyroAvailable)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

        protected virtual void Update()
    {
        HandleMovement();
        //Debug.Log(moveSpeed);
    }

        private void HandleMovement()
    {
    
    _PlayerAnimator.WalkAnimationStatus(true);
    
    float vertical = Input.GetAxis("Vertical");
    moveSpeed += vertical * acceleration * Time.deltaTime;
    moveSpeed = Mathf.Clamp(moveSpeed, minSpeed, maxSpeed);

    // Вперёд
    Vector3 forwardMove = Vector3.forward * moveSpeed * Time.deltaTime;

    // Горизонталь с клавиш и гироскопа
    float horizontal = Input.GetAxis("Horizontal");

    if (gyroAvailable)
    {
        float tilt = gyro.rotationRateUnbiased.y;
        horizontal += tilt * 0.5f;
    }

    Vector3 sideMove = Vector3.right * horizontal * sideSpeed * Time.deltaTime;

    // Объединяем движение
    Vector3 move = forwardMove + sideMove;
    Vector3 newPosition = transform.position + move;

    // Ограничение по X
    newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
    transform.position = newPosition;

    // ===== ЧЁТКОЕ ВРАЩЕНИЕ ПО НАПРАВЛЕНИЮ ДВИЖЕНИЯ =====
      if (move != Vector3.zero)
     {
     Vector3 rotationAxis = Vector3.Cross(move.normalized, Vector3.up);
     
     float distance = move.magnitude;
     float radius = transform.localScale.x * 0.5f;

     float angle = -((distance / (2 * Mathf.PI * radius)) * 360f) * 0.5f;
     
      }
    }
}

