using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Rigidbody2D rb2d;
    private float moveHorizontal;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
        
        rb2d.velocity = new Vector2(moveHorizontal * speed, 0);
    }
}
