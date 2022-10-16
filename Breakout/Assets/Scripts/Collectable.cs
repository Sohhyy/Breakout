using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField]
    private float fallingSpeed = 5f; // Falling Speed
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * fallingSpeed); //Falling Down
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
