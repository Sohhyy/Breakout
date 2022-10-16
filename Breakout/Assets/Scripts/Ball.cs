using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    [SerializeField] private float speed = 5f;
    private GameObject paddle;
    private float y_Offset = 0.35f;
    private Vector2 offset;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

        paddle = GameObject.FindGameObjectWithTag("Paddle");
        offset = new Vector2(0, y_Offset);

    }

    // Update is called once per frame
    void Update()
    {
        if (!BallManager.Instance.GetLaunched())
        {
            gameObject.transform.position = (Vector2) paddle.transform.position + offset;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !BallManager.Instance.GetLaunched() && !GameManager.Instance.GetGameStatus())
        {
            BallManager.Instance.SetLaunched(true);
            rb2d.velocity = Vector2.up * speed;

        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LowerWall")
        {
            Destroy(gameObject);
            BallManager.Instance.DecreaseBallNum();
        }
    }

    public void SetRandomSpeed()
    {
        rb2d.velocity = Random.insideUnitCircle.normalized * speed;
    }
}
