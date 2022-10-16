using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MultiBalls : Collectable
{
    [Header("MultiBall Configs")]
    [SerializeField] [Range(1, 10)] private int multiplier = 1;

    protected override void Effect()
    {
        for(int i = 0; i < multiplier; i++)
        {
            BallManager.Instance.MultipleBall();
        }
    }
}
