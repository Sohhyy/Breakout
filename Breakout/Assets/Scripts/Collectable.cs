using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Abstract Class for all collectable powerups
/// All collectable falling down in certain speed
/// Include a abstract function for the effect of powerup.
/// </summary>
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
        //Falling down
        transform.Translate(Vector2.down * Time.deltaTime * fallingSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destory gameobject when hit lower boundary
        if (collision.gameObject.tag == "LowerWall")
        {
            Destroy(gameObject);
        }
        //Destory gameobject and apply corresponding effect of this collectable powerup when hit paddle
        if (collision.gameObject.tag == "Paddle" && !GameManager.Instance.GetGameOverStatus())
        {
            Destroy(gameObject);
            Effect();
        }
    }

    //Effect of this collectable powerup, need to be implemented in child class
    protected abstract void Effect();
}
