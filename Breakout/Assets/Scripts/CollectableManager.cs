using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Collectable Manager which controls the spawn of collectable powerups and the clear of powerups
/// </summary>
public class CollectableManager : MonoBehaviour
{

    #region  Singleton
    public static CollectableManager Instance = null;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion
    [Header("Power Up Collections")]
    [SerializeField] private GameObject[] powerUpPrefebs; //The array contains all types of powerups prefeb

    private List<GameObject> collectables = new List<GameObject>();  // List to store all collectable powerups created in the game

    /// <summary>
    /// Destory and Clear all the collectable powerups
    /// </summary>
    public void ClearCollectable()
    {
        foreach (GameObject i in collectables)
        {
            Destroy(i);
        }
        collectables.Clear();
    }

    /// <summary>
    /// Add a new powerup to the collectables list
    /// </summary>
    /// <param name="gameObject">A collectable powerup gameobject </param>
    public void AddCollectable(GameObject gameObject)
    {
        Assert.IsNotNull(gameObject.GetComponent<Collectable>());
        collectables.Add(gameObject);
    }

    /// <summary>
    /// Create a new collectable powerup at certain position
    /// </summary>
    /// <param name="position"></param>
    public void CreateCollectable(Vector3 position)
    {
        if (powerUpPrefebs.Length > 0)
        {
            //Randomly pick one collectable powerup from powerups array
            GameObject powerup = Instantiate(powerUpPrefebs[Random.Range(0, powerUpPrefebs.Length)]);
            powerup.transform.position = position;
            AddCollectable(powerup);
        }

    }
}
