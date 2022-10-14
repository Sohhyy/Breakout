using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    public float speed = 5f;
    public GameObject initialPoint;
    private bool islaunched = false;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (!islaunched)
        {
            gameObject.transform.position = initialPoint.transform.position;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && !islaunched)
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
            ResetBall();
        }
    }
}
