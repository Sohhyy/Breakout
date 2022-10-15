using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;



public class BrickManager : MonoBehaviour
{
    [SerializeField] public static BrickManager Instance = null;
    [Serializable]
    public struct LevelStats
    {
        public int row;
        public int column;
        public float verticalOffset;
        public float horizontalOffest;
        [Range(0, 100)]
        public int PowerUpPossibility;
    }
    [SerializeField] private GameObject brickPrefeb;
    [SerializeField]
    private LevelStats[] stats;
    // Start is called before the first frame update
    
    




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
        List<int> powerupIndex = GetRandomNumberList(0, brickNum-1, Mathf.CeilToInt(brickNum*stats[current_level].PowerUpPossibility)/100);
        //List<int> powerupIndex = GetRandomNumberList(0, 20, );
        foreach (int i in powerupIndex)
        {
            bricks[i].GetComponent<Brick>().SetToPowerUp();
        }

        UIManager.Instance.UpdateLevelUI();
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
        return current_level +1;
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
                ClearLevel();
                CollectableManager.Instance.ClearCollectable();
                CreateLevel();
            }
            else
            {
                GameManager.Instance.YouWin();
            }
        }

    }

    

    private List<int> GetRandomNumberList(int beginNum, int endNum, int getCount)
    {
        if (beginNum >= endNum)
        {
            Debug.Log("EndNum < beginNum");
            return null;
        }
        if (getCount > (endNum - beginNum +1))
        {
            Debug.Log("wrong size");
            return null;
        }
        List<int> resultArray = new List<int>();
        List<int> originalArray = new List<int>();
        for (int i = beginNum; i <= endNum; i++)
        {
            originalArray.Add(i);
        }
        int randomCount = originalArray.Count;
        int randomIndex = 0, count = randomCount, temp = 0;
        for (int i = 0; i < getCount; i++)
        {
           
            randomIndex = UnityEngine.Random.Range(0, count);
            resultArray.Add(originalArray[randomIndex]);           
            temp = originalArray[randomIndex];
            originalArray[randomIndex] = originalArray[count - 1];
            originalArray[count - 1] = temp;
            count--;
        }
        return resultArray;
    }



}
