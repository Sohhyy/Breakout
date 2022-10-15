using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update      
    [Header("Game Configs")]
    [SerializeField] private int max_life = 3;
    [SerializeField] public static GameManager Instance = null;

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
        Assert.IsNotNull(ball);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore(int score)
    {
        total_score = total_score+score;
        UIManager.Instance.UpdateScoreUI();

    }

    public void DecreaseLife()
    {
        current_life--;
        UIManager.Instance.UpdateLifeUI();
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
        UIManager.Instance.UpdateScoreUI();
    }

    private void ResetLife()
    {
        current_life = max_life;
        UIManager.Instance.UpdateLifeUI();
    }

    

    public void StartGame()
    {
        UIManager.Instance.HideGameOverUI();
        UIManager.Instance.HideStartUI();
        UIManager.Instance.HideYouWinUI();

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
        UIManager.Instance.ShowGameOverUI();
    }

    public void YouWin()
    {
        ball.ResetBall();
        gameOver = true;
        UIManager.Instance.ShowYouWinUI();
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
