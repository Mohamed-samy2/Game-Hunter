using UnityEngine;
using UnityEngine.UI;
public class Zombie : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public int enemyHealth= 100;
    public Animator animator;
    public Slider zombieHealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zombieHealthBar.value = enemyHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if(target != null)
        {
            Physics2D.IgnoreCollision(target.GetComponent<Collider2D>(),GetComponent<Collider2D>()); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(0.35f, 0.35f);
        }
        else
        {
            transform.localScale = new Vector2(-0.35f, 0.35f);
        }

    }

    public void TakeDamage(int damageAmount)
    {
        enemyHealth-= damageAmount;
        zombieHealthBar.value = enemyHealth;
 
        if (enemyHealth > 0)
        {
            animator.SetTrigger("Damage");

        }
        else
        {
            animator.SetTrigger("Death");
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
            Destroy(gameObject, 2f);
        }

    }

    public void PlayerDamage()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null && !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>().isInvisible)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>().TakeDamage();
        }
    }
}
