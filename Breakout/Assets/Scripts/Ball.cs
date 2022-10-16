using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Ball Class which control the launch, movement and destory of the ball.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{

    [Header("Ball Configs")]
    [SerializeField] private float speed = 5f;

    private GameObject initialPoint; //Inital Point(child gameobject of the paddle) when the ball is not launched
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Assert.IsTrue(speed > 0, "Ball speed less than 0");
        //get initial point from the ball mamager
        initialPoint = BallManager.Instance.GetInitialPoint();
    }

    void Update()
    {
        //if not launched, the position of the ball should always be the same as initial point
        if (!BallManager.Instance.GetLaunched())
        {
            gameObject.transform.position = initialPoint.transform.position;
        }
        //if not lunched and not game over, press Space to launch the ball
        if (Input.GetKeyDown(KeyCode.Space) && !BallManager.Instance.GetLaunched() && !GameManager.Instance.GetGameStatus())
        {
            BallManager.Instance.SetLaunched(true);
            rb2d.velocity = Vector2.up * speed;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destory the ball when hit the lower bondary.
        if (collision.gameObject.tag == "LowerWall")
        {
            Destroy(gameObject);
            //Descrease the number of the balls in ball mamager
            BallManager.Instance.DecreaseBallNum();
        }
    }

    /// <summary>
    /// Set a randon dirction for the ball
    /// </summary>
    public void SetRandomDirctionSpeed()
    {
        rb2d.velocity = Random.insideUnitCircle.normalized * speed;
    }
}
