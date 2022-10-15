using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public static UIManager Instance = null;


    [Header("GameStart/Over UI")]
    [SerializeField] private GameObject GameStartUI;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject YouWinUI;

    [Header("TextUI List")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text levelText;
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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowStartUI()
    {
        GameStartUI.SetActive(true);
    }
    public void HideStartUI()
    {
        GameStartUI.SetActive(false);
    }
    public void ShowGameOverUI()
    {
        GameOverUI.SetActive(true);
    }
    public void HideGameOverUI()
    {
        GameOverUI.SetActive(false);
    }
    public void ShowYouWinUI()
    {
        YouWinUI.SetActive(true);
    }
    public void HideYouWinUI()
    {
        YouWinUI.SetActive(false);
    }
    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + GameManager.Instance.getScore();
    }
    public void UpdateLifeUI()
    {
        lifeText.text = "Life: " + GameManager.Instance.getCurrentLife();
    }
    public void UpdateLevelUI()
    {
        levelText.text = "Level: " + BrickManager.Instance.GetCurrentLevel();
    }
}
