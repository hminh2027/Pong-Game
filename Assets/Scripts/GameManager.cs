using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle player;
    public Paddle computer;
    
    public Text playerScoreText;
    public Text computerScoreText;
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    private string playerName;
    private int playerScore = 0;
    private int computerScore = 0;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameIsPaused) Resume();
            else Pause();
        }

        IsVictory();
        IsGameOver();  
    }

    private void IsVictory ()
    {
        if (playerScore == 5 && !GameIsPaused)
        {
            FindObjectOfType<AudioManager>().Play("Victory");
            GameIsPaused = true;
            Time.timeScale = 0f;
            winCanvas.SetActive(true);
        }
    }

    private void IsGameOver ()
    {
        if (computerScore == 5 && !GameIsPaused)
        {
            FindObjectOfType<AudioManager>().Play("Gameover");
            GameIsPaused = true;
            Time.timeScale = 0f;
            loseCanvas.SetActive(true);
        }
    }

    public void PlayerScores()
    {
        FindObjectOfType<AudioManager>().Play("Scored");
        playerScore++;
        playerScoreText.text = playerScore.ToString();
        ResetPositions();
        ball.AddRandomForce();
    }

    public void ComputerScores()
    {
        FindObjectOfType<AudioManager>().Play("Scored");
        computerScore++;
        computerScoreText.text = computerScore.ToString();
        ResetPositions();
        ball.AddRandomForce();
    }

    private void ResetPositions()
    {
        player.ResetPosition();
        computer.ResetPosition();
        ball.ResetPosition();
    }

    private void ResetScores()
    {
        playerScore = 0;
        computerScore = 0;
        playerScoreText.text = playerScore.ToString();
        computerScoreText.text = computerScore.ToString();
    }

    public bool CheckPlayerCollided (Ball ball)
    {
        if (ball.GetVelocityX() < 0f) return true;
        return false;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        GameIsPaused = false;
    }

    private void Pause()
    {
        FindObjectOfType<AudioManager>().Play("Pause");
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        GameIsPaused = true;
    }

    public void Replay()
    {
        SaveScore();
        ResetScores();
        Resume();
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        SaveScore();
        ResetScores();
        Resume();
        SceneManager.LoadScene("MainMenuScene");
    }

    private void SaveScore()
    {
        if (PlayerPrefs.GetInt("score") < playerScore)
        {
            PlayerPrefs.SetInt("score", playerScore);
            PlayerPrefs.SetString("name", PlayerPrefs.GetString("curPlayer"));
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
