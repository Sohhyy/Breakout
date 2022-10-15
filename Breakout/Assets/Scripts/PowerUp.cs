using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LowerWall")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Paddle" && !GameManager.Instance.GetGameStatus())
        {
            Destroy(gameObject);
        }
    }
}
