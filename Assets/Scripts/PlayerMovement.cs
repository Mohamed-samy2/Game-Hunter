using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls playerControls;
    float direction = 0f;
    public float speed = 150f;
    bool isFacingRight = true;

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
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1 ,transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            noOfJumps = 0;
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocityX, jumpForce);
            noOfJumps++;
        }
        else
        {
            if (noOfJumps == 1)
            {
                playerRB.linearVelocity = new Vector2(playerRB.linearVelocityX, jumpForce);
                noOfJumps++;
            }
        }
    }
}
