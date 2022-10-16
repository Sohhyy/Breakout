using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Brick Manager which controls creating and destorying levels
/// </summary>
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

    //Struct for the settint of each level
    [Serializable]
    public struct LevelStats
    {
        [Range(1, 10)]
        public int row; //The number of rows of bricks
        [Range(1, 10)]
        public int column;//The number of column of bricks
        [Range(0, 10f)]
        public float verticalOffset; // The offset between each row
        [Range(0, 10f)]
        public float horizontalOffest; // The offset between each column
        [Range(0, 100)]
        public int powerUpPossibility; // How many percent of bricks will contains powerups
    }
    [SerializeField] private GameObject brickPrefeb;
    [SerializeField] private LevelStats[] levels; // array to store level status for each leve

    private List<GameObject> bricks = new List<GameObject>(); //list store all bricks in current level
    private int currentLevel = 0; // initial current level is set to 0 for the convience of creating levels
    private int totalLevels;
    private int brickNum; //the number of bricks in current level


    void Start()
    {
        Assert.IsNotNull(brickPrefeb, "Missing brick prefeb");
        Assert.IsTrue(levels.Length > 0, "Missing level settings");
        totalLevels = levels.Length;

    }

    /// <summary>
    /// Create a new level based on current level stats
    /// </summary>
    public void CreateLevel()
    {
        for (int i = 0; i < levels[currentLevel].row; i++)
        {
            for (int j = 0; j < levels[currentLevel].column; j++)
            {
                // Calculate brick position based on the horizontal and vertical offset
                // All the bricks will be created on the right or below the position of the brickmanager.
                Vector2 pos = new Vector2(i * levels[currentLevel].horizontalOffest, -j * levels[currentLevel].verticalOffset) + (Vector2)this.transform.position;
                GameObject brick = Instantiate(brickPrefeb);
                brick.transform.position = pos;
                brick.transform.SetParent(this.transform);
                bricks.Add(brick);
            }

        }
        brickNum = bricks.Count;  //Reset brickNum
        // Get Random number to see which bricks contain powerups
        List<int> powerupIndex = GetRandomNumberList(0, brickNum - 1, Mathf.CeilToInt(brickNum * levels[currentLevel].powerUpPossibility) / 100);
        foreach (int i in powerupIndex)
        {
            bricks[i].GetComponent<Brick>().SetToPowerUp(); //set corresponding to contain powerups
        }


    }

    /// <summary>
    /// Destory all bricks in current level and reset brickNum
    /// </summary>
    public void ClearLevel()
    {
        foreach (GameObject i in bricks)
        {
            Destroy(i);
        }
        bricks.Clear();
        brickNum = 0;

    }

    public int GetCurrentLevel()
    {
        // initial current level is set to 0 for the convience of creating levels, add 1 for the UI displaying in the real game
        return currentLevel + 1;
    }

    public void ResetLevel(int level = 0)
    {
        Assert.IsTrue(totalLevels - level > 0);
        if (level < totalLevels)
        {
            currentLevel = level;
            UIManager.Instance.UpdateLevelUI();
        }

    }
    public void DecreaseNumberOfBricks(int num = 1)
    {
        brickNum -= num;
        CheckNextLevel();
    }

    /// <summary>
    /// Check if all the bricks are destoryed in current level
    /// if yes, move to next level
    /// if finish all levels, show Win UI
    /// </summary>
    public void CheckNextLevel()
    {
        if (brickNum <= 0)
        {
            currentLevel++;
            if (currentLevel < totalLevels)
            {
                UIManager.Instance.UpdateLevelUI();
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
    #region  HelperFunction
    /// <summary>
    /// Function to get certain number of random number without duplication from range beginNum to endNum
    /// </summary>
    /// <param name="beginNum"></param>
    /// <param name="endNum"></param>
    /// <param name="randomNumCount"> How many numbers of random number withou duplication do you want to get</param>
    /// <returns></returns>
    private List<int> GetRandomNumberList(int beginNum, int endNum, int randomNumCount)
    {
        Assert.IsTrue(endNum > beginNum);
        Assert.IsTrue(randomNumCount <= (endNum - beginNum + 1));

        List<int> resultArray = new List<int>();
        List<int> originalArray = new List<int>();
        for (int i = beginNum; i <= endNum; i++)
        {
            originalArray.Add(i); // Set original to contain the number from beginNum to endNum
        }
        int randomIndex = 0;
        int count = originalArray.Count;
        int temp = 0;
        for (int i = 0; i < randomNumCount; i++)
        {
            // get a random index from 0 to count
            randomIndex = UnityEngine.Random.Range(0, count);
            // Add corresponding items in original array to result array
            resultArray.Add(originalArray[randomIndex]);
            //switch the current chosen one with the last one in original array
            temp = originalArray[randomIndex];
            originalArray[randomIndex] = originalArray[count - 1];
            originalArray[count - 1] = temp;
            // Decrease count by 1 to prevent duplication random number
            count--;
        }
        return resultArray;
    }
    #endregion
}
