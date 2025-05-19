using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static bool isGameWin;
    public GameObject gameWonScreen;
    private void Awake()
    {
        isGameOver = false;
        gameOverScreen.SetActive(false);
        isGameWin = false;
        gameWonScreen.SetActive(false);
    }

    private void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
        if (isGameWin)
        {
            gameWonScreen.SetActive(true);
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackHome()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}

