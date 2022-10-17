using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Ball manager which controls the spawn, reset, clear of all the balls in the game
/// </summary>
public class BallManager : MonoBehaviour
{

    #region  Singleton
    public static BallManager Instance = null;
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

    [Header("Ball Prefeb")]
    [SerializeField] private GameObject ballPrefeb;

    [Header("Ball Initial Spawn Point")]
    [SerializeField] private GameObject initialPoint; //Inital Point(child gameobject of the paddle) when the ball is not launched

    private int ballNums; //the number of balls currenly in the game
    private bool islaunched = false; // if the ball is launched
    private List<GameObject> balls = new List<GameObject>(); // list to store all the balls 

    private void Start()
    {
        Assert.IsNotNull(ballPrefeb, "Missing ball Prefeb");
        Assert.IsNotNull(initialPoint, "Initial Spawn Point");
    }

    /// <summary>
    /// Create a new ball at certain position and update the ballNums
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    private GameObject CreateNewBall(Vector3 position)
    {
        GameObject newBall = Instantiate(ballPrefeb, position, Quaternion.identity);
        newBall.transform.SetParent(this.transform);
        ballNums++;
        balls.Add(newBall);
        return newBall;
    }

    /// <summary>
    /// Destory all the balls in the game and create a new ball at initial point
    /// </summary>
    public void ResetBall()
    {
        foreach (GameObject i in balls)
        {
            Destroy(i);
        }
        balls.Clear();
        ballNums = 0;
        SetLaunched(false);
        CreateNewBall(initialPoint.transform.position);
    }

    /// <summary>
    /// Function for powerups "Multiballs"
    /// All balls currently in the game will by multiply by multiplier
    /// </summary>
    /// <param name="multiplier"></param>
    public void MultipleBall(int multiplier)
    {
        // temp list to store all the balls currently in the game
        // Create a new temp list to prevent exception since the size of balls list will keep changing when create new balls
        List<GameObject> temp = new List<GameObject>(balls);
        for (int i = 0; i < multiplier; i++)
        {
            foreach (GameObject ball in temp)
            {
                if (ball != null) //Check if the ball exsiting
                {
                    // create a new ball at the position of the original ball
                    GameObject newBall = CreateNewBall(ball.transform.position);
                    // set the new ball a random dirction speed
                    newBall.GetComponent<Ball>().SetRandomDirctionSpeed();
                }

            }
        }

    }



    public int GetBallNums()
    {
        return ballNums;
    }

    public void DecreaseBallNum(int num = 1)
    {
        ballNums -= num;
        //if no ball exists, decrese life
        if (ballNums <= 0)
        {
            GameManager.Instance.DecreaseLife();
        }
    }
    public bool GetLaunched()
    {
        return islaunched;
    }

    public void SetLaunched(bool status)
    {
        islaunched = status;
    }

    public GameObject GetInitialPoint()
    {
        return initialPoint;
    }
}
