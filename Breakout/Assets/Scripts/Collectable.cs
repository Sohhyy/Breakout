using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 5f;
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
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
