using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] public static BallManager Instance = null;
    private List<GameObject> balls = new List<GameObject>();
    [SerializeField] private GameObject ballPrefeb;
    private int ballNums;
    private bool islaunched = false;

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

    public void ResetBall()
    {
        foreach (GameObject i in balls)
        {
            Destroy(i);
        }
        balls.Clear();
        SetLaunched(false);
        GameObject ball = Instantiate(ballPrefeb);
        balls.Add(ball);
        ballNums = balls.Count;
    }

    public int GetBallNums()
    {
        return ballNums;
    }

    public void DecreaseBallNum(int num = 1)
    {
        ballNums=ballNums-num;
        if (ballNums <= 0)
        {
            GameManager.Instance.DecreaseLife();
        }
    }

    public void MultipleBall()
    {
        List<GameObject> temp = new List<GameObject>(balls);
        foreach(GameObject ball in temp)
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
}
