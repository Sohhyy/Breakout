using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BrickManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject brickPrefeb;
    public int row = 3;
    public int column = 3;
    public float verticalOffset = 1;
    public float horizontalOffest = 1;

    void Start()
    {
        Assert.IsNotNull(brickPrefeb);
        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < column; j++)
            {
                Vector2 pos = new Vector2(i * horizontalOffest, -j * verticalOffset) + (Vector2)this.transform.position;
                GameObject brick = Instantiate(brickPrefeb);
                brick.transform.position = pos;
                brick.transform.SetParent(this.transform);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
