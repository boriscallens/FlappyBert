using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject gameOver;
    public GameObject playButton;
    public TextMeshProUGUI scoreText;

    public int Score { get; private set; } = 0;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        playButton.SetActive(false);
        gameOver.SetActive(false);
        
        Score = 0;
        scoreText.text = Score.ToString();

        var pipes = FindObjectsOfType<Pipes>();
        foreach (var pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }

        player.Reset();
        
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        Score++;
        scoreText.text = Score.ToString();
    }
}