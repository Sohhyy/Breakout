/*
Collectable.cs
Script for abstract class of all collectable powerups.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Collectable : MonoBehaviour
{
    [Header("Collectable Configs")]
    [SerializeField] private float fallingSpeed = 5f;

    private void Start()
    {
        Assert.IsTrue(fallingSpeed > 0, "Collectable speed is less than 0");
    }
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * fallingSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LowerWall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Paddle" && !GameManager.Instance.GetGameStatus())
        {
            Destroy(gameObject);
            Effect();
        }
    }

    protected abstract void Effect();
}
