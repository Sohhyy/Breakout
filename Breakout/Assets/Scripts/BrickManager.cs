using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;



public class BrickManager : MonoBehaviour
{
    [Serializable]
    public struct LevelStats
    {
        public int row;
        public int column;
        public float verticalOffset;
        public float horizontalOffest;
    }
    [SerializeField]
    private LevelStats[] stats;
    // Start is called before the first frame update
    [SerializeField] private GameObject brickPrefeb;
    [SerializeField] private Text levelText;
    [SerializeField] public static BrickManager Instance = null;



    private List<GameObject> bricks = new List<GameObject>();

    private int current_level = 0;
    private int total_level;
    private Ball ball;
    private int brickNum;

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
        Assert.IsNotNull(brickPrefeb);
        total_level = stats.Length;
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLevel()
    {
        for (int i = 0; i <stats[current_level].row; i++)
        {
            for (int j = 0; j < stats[current_level].column; j++)
            {
                Vector2 pos = new Vector2(i * stats[current_level].horizontalOffest, -j * stats[current_level].verticalOffset) + (Vector2)this.transform.position;
                GameObject brick = Instantiate(brickPrefeb);
                brick.transform.position = pos;
                brick.transform.SetParent(this.transform);
                bricks.Add(brick);
            }

        }
        brickNum = bricks.Count;
        levelText.text = "Level: " + (current_level+1);
    }

    public void ClearLevel()
    {
        foreach(GameObject i in bricks)
        {
            Destroy(i);
        }
        bricks.Clear();
    }

    public int GetCurrentLevel()
    {
        return current_level;
    }

    public void ResetLevel(int level = 0)
    {
        Assert.IsTrue(total_level - level > 0);
        if (level < total_level)
        {
            current_level = level;
        }
        
    }

    

    public void CheckNextLevel()
    {
        
        brickNum--;
        if (brickNum == 0)
        {
            current_level++;
            if (current_level < total_level)
            {
                ball.ResetBall();
                bricks.Clear();
                CreateLevel();
            }
            else
            {
                GameManager.Instance.YouWin();
            }
        }

    }



}
