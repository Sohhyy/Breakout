using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private GameObject[] powerUpPrefebs;
    
    private List<GameObject> collectables = new List<GameObject>();
    public void ClearCollectable()
    {
        foreach (GameObject i in collectables)
        {
            Destroy(i);
        }
        collectables.Clear();
    }

    public void AddCollectable(GameObject gameObject)
    {
        collectables.Add(gameObject);
    }

    public void CreateCollectable(Vector3 position)
    {
        if (powerUpPrefebs.Length > 0)
        {
            GameObject powerup = Instantiate(powerUpPrefebs[Random.Range(0, powerUpPrefebs.Length)]);
            powerup.transform.position = position;
            AddCollectable(powerup);
        }
        
    }
}
