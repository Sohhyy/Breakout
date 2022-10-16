using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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
    [SerializeField] private GameObject initialPoint;

    private int ballNums;
    private bool islaunched = false;
    private List<GameObject> balls = new List<GameObject>();

    private void Start()
    {
        Assert.IsNotNull(ballPrefeb, "Missing ball Prefeb");
        Assert.IsNotNull(initialPoint, "Initial Spawn Point");
    }

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

    public int GetBallNums()
    {
        return ballNums;
    }

    public void DecreaseBallNum(int num = 1)
    {
        ballNums -= num;
        if (ballNums <= 0)
        {
            GameManager.Instance.DecreaseLife();
        }
    }

    public void MultipleBall()
    {
        List<GameObject> temp = new List<GameObject>(balls);
        foreach (GameObject ball in temp)
        {
            if (ball != null)
            {
                GameObject newBall = CreateNewBall(ball.transform.position);
                newBall.GetComponent<Ball>().SetRandomSpeed();

            }

        }
    }

    private GameObject CreateNewBall(Vector3 position)
    {
        GameObject newBall = Instantiate(ballPrefeb, position, Quaternion.identity);
        newBall.transform.SetParent(this.transform);
        ballNums++;
        balls.Add(newBall);
        return newBall;
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
