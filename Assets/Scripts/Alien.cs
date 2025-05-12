using UnityEngine;

public class Alien : MonoBehaviour
{
    public Sprite sprite; 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.Dot(transform, Vector2.down))
            {
                Flatten();
            }

        }
    }

    private void Flatten()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = sprite;
        Destroy(gameObject, 0.5f);
    }
}
