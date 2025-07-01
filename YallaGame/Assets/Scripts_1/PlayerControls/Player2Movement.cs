using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    
    public PlayerSettings _PlayerSettings;
    public PlayerAnimatorController _PlayerAnimator;
    
      [Header("Movement Settings")]
    public float sideSpeed;
    public float smoothing = 4f;
    public float minX = -1.4f;
    public float maxX = 1.4f;

    [Header("Forward Movement Settings")]
    public float moveSpeed;
    public float acceleration = 4f;
    public float minSpeed = 2f;
    public float maxSpeed = 7f;
    
    private Vector3 targetSidePosition;
    private bool movingLeft = false;
    private bool movingRight = false;

    private void Start()
    {
        targetSidePosition = transform.position;
        moveSpeed = _PlayerSettings.playerMoveSpeed;
        sideSpeed = _PlayerSettings.playerSideSpeed;
        _PlayerAnimator.WalkAnimationStatus(true);
    }

    private void Update()
    {
        // === Обновляем скорость вперёд ===
        float vertical = Input.GetAxis("Vertical"); // опционально: клавиши W/S
        moveSpeed += vertical * acceleration * Time.deltaTime;
        moveSpeed = Mathf.Clamp(moveSpeed, minSpeed, maxSpeed);

        // === Плавное боковое движение ===
        if (movingLeft) MoveLeft();
        if (movingRight) MoveRight();

        Vector3 currentPos = transform.position;
        Vector3 sideTarget = new Vector3(targetSidePosition.x, currentPos.y, currentPos.z);
        Vector3 sideMove = Vector3.Lerp(currentPos, sideTarget, Time.deltaTime * smoothing);
    
        // === Движение вперёд ===
        Vector3 forwardMove = Vector3.forward * moveSpeed * Time.deltaTime;

        // === Итоговая позиция ===
        Vector3 newPosition = sideMove + forwardMove;
        transform.position = newPosition;

        // === Вращение графики ===
        if (forwardMove != Vector3.zero)
        {
            float distance = forwardMove.magnitude;
            float radius = transform.localScale.x * 0.5f;
            float angle = -((distance / (2 * Mathf.PI * radius)) * 360f) * 0.5f;
            Vector3 rotationAxis = Vector3.Cross(forwardMove.normalized, Vector3.up);
        }
    }


    public void MoveLeft()
    {
        targetSidePosition += Vector3.left * sideSpeed * Time.deltaTime;
        targetSidePosition.x = Mathf.Clamp(targetSidePosition.x, minX, maxX);
    }

    public void MoveRight()
    {
        targetSidePosition += Vector3.right * sideSpeed * Time.deltaTime;
        targetSidePosition.x = Mathf.Clamp(targetSidePosition.x, minX, maxX);
    }

    // Для кнопок на Canvas
    public void OnLeftButtonDown() => movingLeft = true;
    public void OnLeftButtonUp() => movingLeft = false;
    public void OnRightButtonDown() => movingRight = true;
    public void OnRightButtonUp() => movingRight = false;
}
