using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject startScreenUI;
    public bool GameStarted { get; private set; } = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public TextMeshProUGUI message;
    private float initialWinTime;
    public float timeToWin = 10f;
    public static bool gameOver = false;
    private void Start()
    {
        initialWinTime = timeToWin;
        Time.timeScale = 0f;
        GameStarted = false;

        if (startScreenUI != null)
            startScreenUI.SetActive(true);
    }

    void Update()
    {

        if (!GameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
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

    public void StartGame()
    {
        GameStarted = true;

        if (startScreenUI != null)
            startScreenUI.SetActive(false);

        Time.timeScale = 1f;
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
    public void ResetGame()
    {
        gameOver = false;
        GameStarted = false;
        timeToWin = initialWinTime;

        message.text = "";
        startScreenUI.SetActive(true);

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var b in boxes)
        {
            Destroy(b);
        }

        Time.timeScale = 0f;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            player.transform.position = new Vector3(0, -3, 0);
    }
}
