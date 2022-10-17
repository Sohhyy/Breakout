using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

/// <summary>
/// UI Manager which manages all the UI function.
/// </summary>
public class UIManager : MonoBehaviour
{

    #region  Singleton
    public static UIManager Instance = null;
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

    [Header("Game Status UI")]
    [SerializeField] private GameObject gameStartUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject youWinUI;

    [Header("TextUI List")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text levelText;

    private void Start()
    {
        Assert.IsNotNull(gameStartUI);
        Assert.IsNotNull(gameOverUI);
        Assert.IsNotNull(youWinUI);
        Assert.IsNotNull(scoreText);
        Assert.IsNotNull(lifeText);
        Assert.IsNotNull(levelText);
    }

    public void ShowStartUI()
    {
        gameStartUI.SetActive(true);
    }
    public void HideStartUI()
    {
        gameStartUI.SetActive(false);
    }
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }
    public void HideGameOverUI()
    {
        gameOverUI.SetActive(false);
    }
    public void ShowYouWinUI()
    {
        youWinUI.SetActive(true);
    }
    public void HideYouWinUI()
    {
        youWinUI.SetActive(false);
    }
    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetScore();
    }
    public void UpdateLifeUI()
    {
        lifeText.text = "Life: " + GameManager.Instance.GetCurrentLife();
    }
    public void UpdateLevelUI()
    {
        levelText.text = "Level: " + BrickManager.Instance.GetCurrentLevel();
    }
}
