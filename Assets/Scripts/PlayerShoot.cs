using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls controls;

    public GameObject bullet;
    public Transform bulletHole;
    public float force = 200f;
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Shoot.performed += context => Fire();
    }

    void Fire()
    {
        if (bullet != null && bulletHole != null)
        {
            GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);
            if (GetComponent<PlayerMovement>().isFacingRight) {
                go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
            }
            else
            {

                go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
            }
            Destroy(go, 3f);
        }
    }
}
