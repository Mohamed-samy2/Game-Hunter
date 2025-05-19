using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls playerControls;
    float direction = 0f;
    public float speed = 150f;
    public bool isFacingRight = true;
    private new Camera camera;

    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    int noOfJumps = 0;
    public float jumpForce = 5f;
    public Rigidbody2D playerRB;
    public Animator animator;
    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();

        playerControls.Land.Move.performed += context =>
        {
            direction = context.ReadValue<float>();
        };

        playerControls.Land.Jump.performed += context => Jump();
        camera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f,groundLayer );
        animator.SetBool("isGrounded", isGrounded);
        playerRB.linearVelocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.linearVelocityY);
        animator.SetFloat("Speed", Mathf.Abs(direction));

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0) {
            Flip();
        }

        Vector2 position = playerRB.position;
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.8f, rightEdge.x - 0.8f);
        playerRB.position = position;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1 ,transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded && playerRB != null)
        {
            noOfJumps = 0;
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocityX, jumpForce);
            noOfJumps++;
            AudioManager.instance.Play("FirstJump");
        }
        else
        {
            if (noOfJumps == 1 && playerRB != null)
            {
                playerRB.linearVelocity = new Vector2(playerRB.linearVelocityX, jumpForce);
                noOfJumps++;
                AudioManager.instance.Play("SecondJump");
            }
        }
    }
}
