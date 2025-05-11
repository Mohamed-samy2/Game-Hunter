using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    private new Camera camera;
    private new Rigidbody2D rigidbody;
    public float MoveSpeed = 8.0f;
    private float inputAxis;
    private Vector2 velocity;

    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f),2);

    public bool grounded { get; private set; } 
    public bool jumping{ get; private set; } 
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>(); 
        camera = Camera.main;
    }

    private void Update()
    {
        HorizontalMovement();

        grounded = rigidbody.RayCast(Vector2.down);
        if (grounded)
        {
            GroundedMovement();
        }
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        bool falling = velocity.y < 0 || !Input.GetButton("Jump");
        float multiplier = falling ? 20f : 5f;
        velocity.y += gravity * multiplier * Time.deltaTime;

        velocity.y = Mathf.Max(velocity.y, gravity/2f);
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        //velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * MoveSpeed, MoveSpeed * Time.deltaTime);  if we want deceleration 
        velocity.x = inputAxis * MoveSpeed;

    }

    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0f;
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            jumping = true;
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rigidbody.MovePosition(position);
    }

}
