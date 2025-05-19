using UnityEngine;

public class Health : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // collision.GetComponent<PlayerCollision>().UpdateHealth();
            AudioManager.instance.Play("HealthCollect");

            Debug.Log("health when trigger occurs");
            Debug.Log(HealthManager.health);

            if (HealthManager.health < 4)
            {
                HealthManager.health++;
            }
            
         Destroy(gameObject);
        }
    }
}
