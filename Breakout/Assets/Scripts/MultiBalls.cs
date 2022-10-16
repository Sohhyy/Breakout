using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Multiball powerups
/// All balls currently in the game will by multiply by multiplier
/// </summary>
public class MultiBalls : Collectable
{
    [Header("MultiBall Configs")]
    [SerializeField] [Range(1, 10)] private int multiplier = 1;

    protected override void Effect()
    {
        //Multiply all the balls by multiplier
        BallManager.Instance.MultipleBall(multiplier);

    }
}
