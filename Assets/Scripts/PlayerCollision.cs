using UnityEngine;
using System.Collections;
public class PlayerCollision : MonoBehaviour
{
    public bool isInvisible = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Enemy"))
        {

            TakeDamage();
        }
        if (collision.transform.tag.Equals("Door"))
        {

             PlayerManager.isGameWin = true;
             gameObject.SetActive(false);
            //  Destroy(gameObject);
        }
       
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(3, 7);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        isInvisible = true;
        yield return new WaitForSeconds(2);
        isInvisible = false;
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(3, 7, false);

    }

    public void TakeDamage()
    {
        HealthManager.health--;
        if (HealthManager.health <= 0)
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(GetHurt());
        }
    }
    public void UpdateHealth()
    {
        
        if (HealthManager.health < 4)
        {
            HealthManager.health++;
        }
    }
}
