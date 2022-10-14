using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Movement speed of paddle, should be larger than 0")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float leftEdge = 5f;
    [SerializeField] private float rightEdge = 5f;
    //private Rigidbody2D rb2d;
    private float moveHorizontal;
    void Start()
    {
        //rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (!GameManager.Instance.GetGameStatus())
        {
            transform.Translate(new Vector2(moveHorizontal* speed*Time.deltaTime, 0));
        }

        if (transform.position.x < leftEdge)
        {
            transform.position = new Vector2(leftEdge, transform.position.y);
        }
        if (transform.position.x > rightEdge)
        {
            transform.position = new Vector2(rightEdge, transform.position.y);
        }

    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.GetGameStatus())
        {
            //rb2d.velocity = new Vector2(moveHorizontal * speed, 0);
        }
        else
        {
            //rb2d.velocity = Vector2.zero;
        }
        
    }
}