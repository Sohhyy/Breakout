using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update      
    [Header("Game Configs")]
    [SerializeField] private int maxLife = 3;
    [SerializeField] public static GameManager Instance = null;

    private int currentScore = 0;

    private int currentLife;


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
        currentLife = maxLife;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseScore(int score)
    {
        currentScore = currentScore + score;
        UIManager.Instance.UpdateScoreUI();

    }

    public void DecreaseLife()
    {
        currentLife--;
        UIManager.Instance.UpdateLifeUI();
        if (currentLife <= 0)
        {
            GameOver();
        }
        else
        {
            BallManager.Instance.ResetBall();
            CollectableManager.Instance.ClearCollectable();
        }
    }



    public int GetScore()
    {
        return currentScore;
    }

    public int GetCurrentLife()
    {
        return currentLife;
    }



    private void ResetScore()
    {
        currentScore = 0;
        UIManager.Instance.UpdateScoreUI();
    }

    private void ResetLife()
    {
        currentLife = maxLife;
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool GetGameStatus()
    {
        return gameOver;
    }
}
