using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBalls : Collectable
{
    // Start is called before the first frame update
    [SerializeField] private int nums = 1;
    void Start()
    {

    }

    // Update is called once per frame


    protected override void Effect()
    {
        for(int i = 0; i < nums; i++)
        {
            BallManager.Instance.MultipleBall();
        }
    }
}
