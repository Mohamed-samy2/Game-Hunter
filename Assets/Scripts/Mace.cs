using UnityEngine;

public class Mace : MonoBehaviour
{

    public float speed = 1f;
    public float range = 3f;
    float startY;
    int direction = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startY = transform.position.y;
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime * direction);
        if(transform.position.y < startY || transform.position.y > startY + range)
        {
            direction *= -1;
        }
    }
}
