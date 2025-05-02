using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    private new Camera camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private new Rigidbody2D rigidbody;
    public float MoveSpeed = 8.0f;
    private float inputAxis;
    private Vector2 velocity;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    private void Update()
    {
        HorizontalMovement();
    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        //velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * MoveSpeed, MoveSpeed * Time.deltaTime);  if we want deceleration 
        velocity.x = inputAxis * MoveSpeed;

    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += velocity * Time.fixedDeltaTime;

        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 1.6f, rightEdge.x -1.6f);

        rigidbody.MovePosition(position);
    }

}
