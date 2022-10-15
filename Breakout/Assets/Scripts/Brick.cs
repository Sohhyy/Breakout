using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update

    private int score = 1;
    private bool containPowerup = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            GameManager.Instance.increaseScore(score);
            BrickManager.Instance.CheckNextLevel();
            if (containPowerup)
            {
                CollectableManager.Instance.CreateCollectable(transform.position);
            }
        }
    }

    public void SetToPowerUp()
    {
        containPowerup = true;
    }
}
