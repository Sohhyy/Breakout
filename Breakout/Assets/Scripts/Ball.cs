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
    [SerializeField] private GameObject initialPoint;
    private bool islaunched = false;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
        Assert.IsNotNull(initialPoint);
        //ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (!islaunched)
        {
            gameObject.transform.position = initialPoint.transform.position;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && !islaunched && !GameManager.Instance.GetGameStatus())
            {
                islaunched = true;
            rb2d.velocity = Vector2.up * speed;

            }
        
    }

    public void ResetBall()
    {
       
        rb2d.velocity = Vector2.zero;
        islaunched = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "LowerWall")
        {
            GameManager.Instance.DecreaseLife();
            ResetBall();
        }
    }
}
