using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            //Destroy(collision.gameObject);
            Destroy(gameObject,2f);
        }

        if (collision.tag.Equals("Zombie"))
        {
            collision.GetComponent<Zombie>().TakeDamage(25);
        }
    }
}
