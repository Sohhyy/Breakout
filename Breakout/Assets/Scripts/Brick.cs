using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Brick : MonoBehaviour
{
    [Header("Brick Configs")]
    [SerializeField] private int score = 1;

    private bool containPowerup = false;
    private bool hitted = false;

    private void Start()
    {
        Assert.IsTrue(score > 0, "Score is less than 0");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" && !hitted)
        {
            hitted = true;
            Destroy(gameObject);
            if (containPowerup)
            {
                CollectableManager.Instance.CreateCollectable(transform.position);
            }
            GameManager.Instance.IncreaseScore(score);
            BrickManager.Instance.CheckNextLevel();
            
        }
    }

    public void SetToPowerUp()
    {
        containPowerup = true;
    }
}
