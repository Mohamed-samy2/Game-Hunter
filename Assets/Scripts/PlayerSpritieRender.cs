using UnityEngine;

public class PlayerSpritieRender : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private HeroMovement movement;
    public Sprite idle;
    public AnimatedSprite walking;
    public AnimatedSprite jump;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<HeroMovement>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }
    private void OnDisable()
    {
        spriteRenderer.enabled=false;
    }
    private void LateUpdate()
    {
        jump.enabled = movement.jumping;
        walking.enabled = movement.walking;

        if (!movement.walking) {
            spriteRenderer.sprite = idle;
        }
    }
}
