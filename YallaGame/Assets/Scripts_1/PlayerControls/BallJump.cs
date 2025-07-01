using UnityEngine;

public class BallJump : MonoBehaviour
{
    public float jumpForce = 3f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private bool jumpRequest = false;
    private Vector2 swipeStart;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody не найден на объекте!");
        }
    }

    protected  void Update()
    {
        HandleJumpInput();
        HandleSwipeJump();
    }

    private void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequest = true;
        }
    }

    private void HandleSwipeJump()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                swipeStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipeEnd = touch.position;
                Vector2 swipeDelta = swipeEnd - swipeStart;

                if (swipeDelta.y > 100f && Mathf.Abs(swipeDelta.y) > Mathf.Abs(swipeDelta.x) && isGrounded)
                {
                    jumpRequest = true;
                }
            }
        }
    }

    // 🔘 Метод для прыжка с кнопки на канвасе
    public void JumpFromButton()
    {
        if (isGrounded)
        {
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            jumpRequest = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }
}
