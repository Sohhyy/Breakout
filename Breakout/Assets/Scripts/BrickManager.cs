using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BrickManager : MonoBehaviour
{
    #region  Singleton
    public static BrickManager Instance = null;
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

    [Serializable]
    public struct LevelStats
    {
        [Range(1, 10)]
        public int row;
        [Range(1, 10)]
        public int column;
        [Range(0, 10f)]
        public float verticalOffset;
        [Range(0, 10f)]
        public float horizontalOffest;
        [Range(0, 100)]
        public int powerUpPossibility;
    }
    [SerializeField] private GameObject brickPrefeb;
    [SerializeField] private LevelStats[] stats;

    private List<GameObject> bricks = new List<GameObject>();
    private int currentLevel = 0;
    private int totalLevel;
    private int brickNum;


    void Start()
    {
        Assert.IsNotNull(brickPrefeb, "Missing brick prefeb");
        Assert.IsTrue(stats.Length > 0, "Missing level settings");
        totalLevel = stats.Length;

    }


    public void CreateLevel()
    {
        for (int i = 0; i < stats[currentLevel].row; i++)
        {
            for (int j = 0; j < stats[currentLevel].column; j++)
            {
                Vector2 pos = new Vector2(i * stats[currentLevel].horizontalOffest, -j * stats[currentLevel].verticalOffset) + (Vector2)this.transform.position;
                GameObject brick = Instantiate(brickPrefeb);
                brick.transform.position = pos;
                brick.transform.SetParent(this.transform);
                bricks.Add(brick);
            }

        }
        brickNum = bricks.Count;
        List<int> powerupIndex = GetRandomNumberList(0, brickNum - 1, Mathf.CeilToInt(brickNum * stats[currentLevel].powerUpPossibility) / 100);
        foreach (int i in powerupIndex)
        {
            bricks[i].GetComponent<Brick>().SetToPowerUp();
        }

        UIManager.Instance.UpdateLevelUI();
    }

    public void ClearLevel()
    {
        foreach (GameObject i in bricks)
        {
            Destroy(i);
        }
        bricks.Clear();

    }

    public int GetCurrentLevel()
    {
        return currentLevel + 1;
    }

    public void ResetLevel(int level = 0)
    {
        Assert.IsTrue(totalLevel - level > 0);
        if (level < totalLevel)
        {
            currentLevel = level;
        }

    }

    public void CheckNextLevel()
    {

        brickNum--;
        if (brickNum == 0)
        {
            currentLevel++;
            if (currentLevel < totalLevel)
            {
                BallManager.Instance.ResetBall();
                CollectableManager.Instance.ClearCollectable();
                ClearLevel();
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
        Assert.IsTrue(endNum > beginNum);
        Assert.IsTrue(getCount <= (endNum - beginNum + 1));
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
