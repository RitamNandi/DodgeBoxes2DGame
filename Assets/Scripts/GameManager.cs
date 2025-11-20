using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI message;
    public float timeToWin = 10f;
    public static bool gameOver = false;

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameOver = false;
        }

        if (!gameOver)
        {
            timeToWin -= Time.deltaTime;
            if (timeToWin <= 0)
            {
                Win();
            }
        }
    }

    public void Win()
    {
        message.text = "You win!\nPress R to Restart";
        gameOver = true;
    }

    public void Lose()
    {
        message.text = "You lost!\nPress R to Restart";
        gameOver = true;
    }
}
