using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    private int life = 3;
    public Text scoreText;
    public Text lifeText;
    private Ball ball;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore()
    {
        score++;
        scoreText.text = "Score: " + score;

    }

    public void DecreaseLife()
    {
        life--;
        lifeText.text = "Life: " + life;
        if (life == 0)
        {
            
        }
        else
        {
            ball.ResetBall();
        }
    }

    public int getScore()
    {
        return score;
    }

    public int getLife()
    {
        return life;
    }
}
