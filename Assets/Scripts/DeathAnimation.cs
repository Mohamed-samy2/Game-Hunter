using System.Collections;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite deadsprite;

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdateSprite();
        DisablePhysics();
        StartCoroutine(Animate());
        
    }

    private void UpdateSprite()
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sortingOrder = 10;

        if (deadsprite != null)
        {
        spriteRenderer.sprite = deadsprite;
        }

    }

    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();

        foreach(Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        GetComponent<Rigidbody2D>().isKinematic = true;

        HeroMovement heromovement =   GetComponent<HeroMovement>();
        EntityMovement entityMovement=   GetComponent<EntityMovement>();

        if (heromovement != null) {
            heromovement.enabled = false;
        }

        if (entityMovement != null) { 
            entityMovement.enabled = false; 
        }


    }

    private IEnumerator Animate()
    {
        float elapsed = 0f;
        float duration = 3f;
        while (elapsed < duration)
        {

            yield return null;
        }
    }

}
