using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Game Manager which control the game flow, score and life
/// </summary>
public class GameManager : MonoBehaviour
{
    #region  Singleton

    public static GameManager Instance = null;
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
    #endregion

    [Header("Game Configs")]
    [SerializeField] private int maxLife = 3;

    private int currentScore = 0;
    private int currentLife;
    private bool gameOver = true;


    void Start()
    {
        Assert.IsTrue(maxLife > 0, "Max life less than 0");
        currentLife = maxLife;
    }

    #region  ScoreFunction
    public void IncreaseScore(int score)
    {
        currentScore = currentScore + score;
        UIManager.Instance.UpdateScoreUI();

    }

    public int GetScore()
    {
        return currentScore;
    }

    private void ResetScore()
    {
        currentScore = 0;
        UIManager.Instance.UpdateScoreUI();
    }

    #endregion


    #region  LifeFunction
    public void DecreaseLife(int num = 1)
    {
        currentLife -= num;
        UIManager.Instance.UpdateLifeUI();
        if (currentLife <= 0)
        {
            // if life<=0, then game over
            GameOver();
        }
        else
        {
            //otherwise, reset the ball, clear all collectables and continue the game
            BallManager.Instance.ResetBall();
            CollectableManager.Instance.ClearCollectable();
        }
    }
    public void IncreaseLife(int num)
    {
        currentLife += num;
    }

    public int GetCurrentLife()
    {
        return currentLife;
    }

    private void ResetLife()
    {
        currentLife = maxLife;
        UIManager.Instance.UpdateLifeUI();
    }
    #endregion


    #region  GameStatusFunction
    public void StartGame()
    {
        //Hide all game status UI
        UIManager.Instance.HideGameOverUI();
        UIManager.Instance.HideStartUI();
        UIManager.Instance.HideYouWinUI();

        //Reset score, life and gameover status
        gameOver = false;
        ResetLife();
        ResetScore();

        //Clear and recreate all the bricks and reset ball
        BrickManager.Instance.ClearLevel();
        BrickManager.Instance.ResetLevel();
        BrickManager.Instance.CreateLevel();
        BallManager.Instance.ResetBall();
    }

    private void GameOver()
    {
        gameOver = true;
        UIManager.Instance.ShowGameOverUI();
    }

    public void YouWin()
    {
        BallManager.Instance.ResetBall();
        gameOver = true;
        UIManager.Instance.ShowYouWinUI();
    }

    /// <summary>
    /// return if current game is over
    /// when game over, the user can not move the paddle or launch the ball
    /// </summary>
    /// <returns></returns>
    public bool GetGameStatus()
    {
        return gameOver;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion







}
