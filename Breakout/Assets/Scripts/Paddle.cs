using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Paddle class to control the movement of the paddle
/// </summary>
public class Paddle : MonoBehaviour
{

    [Header("Paddle Configs")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float leftScreenEdge = -6.7f;
    [SerializeField] private float rightScreenEdge = 6.7f;

    private float moveHorizontal = 0f;
    void Start()
    {
        Assert.IsTrue(speed > 0, "Paddle speed is less than 0");
        Assert.IsTrue(rightScreenEdge > leftScreenEdge, "Wrong Screen Edge Setting");
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        //move paddle horizontally when game not over
        if (!GameManager.Instance.GetGameOverStatus())
        {
            transform.Translate(new Vector2(moveHorizontal * speed * Time.deltaTime, 0));
        }
        //left boundary check
        if (transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
        //right boundary check
        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }

    }

}
