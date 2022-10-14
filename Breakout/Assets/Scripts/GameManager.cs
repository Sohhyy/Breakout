using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("TextUI List")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text lifeText;   
    
    [Header("Game Configs")]
    [SerializeField] private int max_life = 3;
    [SerializeField] public static GameManager Instance = null;

    [Header("GameStart/Over UI")]
    [SerializeField] private GameObject GameStartUI;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject YouWinUI;

    private int total_score = 0;

    private int current_life = 3;
    private Ball ball;

    private bool gameOver = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        Assert.IsNotNull(scoreText);
        Assert.IsNotNull(lifeText);
        Assert.IsNotNull(ball);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore(int score)
    {
        total_score = total_score+score;
        scoreText.text = "Score: " + total_score;

    }

    public void DecreaseLife()
    {
        current_life--;
        lifeText.text = "Life: " + current_life;
        if (current_life == 0)
        {
            GameOver();
        }
        else
        {
            ball.ResetBall();
        }
    }

    public int getScore()
    {
        return total_score;
    }

    public int getCurrentLife()
    {
        return current_life;
    }

   

    private void ResetScore()
    {
        total_score = 0;
        scoreText.text = "Score: " + total_score;
    }

    private void ResetLife()
    {
        current_life = max_life;
        lifeText.text = "Life: " + current_life;
    }

    

    public void StartGame()
    {
        GameStartUI.SetActive(false);
        GameOverUI.SetActive(false);
        YouWinUI.SetActive(false);
        gameOver = false;
        ResetLife();
        ResetScore();

        BrickManager.Instance.ClearLevel();
        BrickManager.Instance.ResetLevel();
        BrickManager.Instance.CreateLevel();
        ball.ResetBall();
    }

    private void GameOver()
    {
        gameOver = true;
        GameOverUI.SetActive(true);
    }

    public void YouWin()
    {
        ball.ResetBall();
        gameOver = true;
        YouWinUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool GetGameStatus()
    {
        return gameOver;
    }
}
