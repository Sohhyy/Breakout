using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Brick class which will be destroyed when hitted by ball
/// Add score when hitted by ball
/// Spawn a powerup if this brick is set to contain powerups
/// </summary>
public class Brick : MonoBehaviour
{
    [Header("Brick Configs")]
    [SerializeField] private int score = 1;

    private bool containPowerup = false; // if this brick contains powerups
    private bool hitted = false; // if this brick is hitted by the ball

    private void Start()
    {
        Assert.IsTrue(score >= 0, "Score is less than 0");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball" && !hitted)
        {
            hitted = true;
            Destroy(gameObject);
            //Spawn a powerup if containPowerup is true
            if (containPowerup)
            {
                CollectableManager.Instance.CreateCollectable(transform.position);
            }
            // Increase Score
            GameManager.Instance.IncreaseScore(score);
            // Check if all bricks are destoryed, if so, go to next level
            BrickManager.Instance.DecreaseNumberOfBricks();
            
        }
    }

    public void SetToPowerUp()
    {
        containPowerup = true;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }
}
