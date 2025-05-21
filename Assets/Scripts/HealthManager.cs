using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public static int health = 4;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        health = 4;
    }
    // Update is called once per frame
    void Update()
    {
        if (health > 4)
        {
                health = 4;
        }
        //Debug.Log("health before update"+health);

        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < health; i++)
        {  
            //Debug.Log("health at ");
            //Debug.Log(i);
            //Debug.Log("health before update");
            //Debug.Log(health);
            hearts[i].sprite = fullHeart;
        }
    }

}
