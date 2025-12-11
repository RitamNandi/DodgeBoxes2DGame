using UnityEngine;
using TMPro;

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
    public float timeToWin = 30f;
    public static bool gameOver = false;
    public int score = 0;
    public int highScore = 0;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;
    public TextMeshProUGUI shieldUI;
    public static bool hasShield;
    public void AddScore(int amount)
    {
        score += amount;
        if (scoreUI != null)
        {
            scoreUI.text = "Score: " + score.ToString();
        }
    }
    private void UpdateHighScoreUI()
    {
        if (highScoreUI != null)
            highScoreUI.text = "High Score: " + highScore.ToString();
    }
    private void Start()
    {
        hasShield = false;
        initialWinTime = timeToWin;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreUI();
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
        checkHighScore();
        message.text = "You survived!\nPress R to Restart\n Score: " + score.ToString();
        gameOver = true;
    }

    public void Lose()
    {
        checkHighScore();
        message.text = "You lost!\nPress R to Restart\nScore: " + score.ToString();
        gameOver = true;
    }
    void checkHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreUI();
        }
    }
    public void ResetGame()
    {
        gameOver = false;
        GameStarted = false;
        timeToWin = initialWinTime;
        score = 0;
        hasShield = false;
        shieldUI.text = "";
        if (scoreUI != null)
        {
            scoreUI.text = "Score: " + score.ToString();
        }

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
    public float GetElapsedTime()
    {
        return initialWinTime - timeToWin;
    }
}
