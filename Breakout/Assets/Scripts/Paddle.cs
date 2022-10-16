using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Paddle : MonoBehaviour
{

    [Header("Paddle Configs")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float leftScreenEdge = -6.7f;
    [SerializeField] private float rightScreenEdge = 6.7f;

    private float moveHorizontal;
    void Start()
    {
        Assert.IsTrue(speed > 0, "Paddle speed is less than 0");
        Assert.IsTrue(rightScreenEdge > leftScreenEdge, "Wrong Screen Edge Setting");
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (!GameManager.Instance.GetGameStatus())
        {
            transform.Translate(new Vector2(moveHorizontal * speed * Time.deltaTime, 0));
        }
        if (transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
        if (transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }

    }

}
