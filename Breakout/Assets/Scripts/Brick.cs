using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    private int score = 1;
    private bool containPowerup = false;
    bool hitted = false;

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
