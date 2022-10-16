using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public static CollectableManager Instance = null;
    [SerializeField] private GameObject[] powerUpPrefebs;
    private List<GameObject> collectables = new List<GameObject>();

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
        GameObject powerup = Instantiate(powerUpPrefebs[Random.Range(0, powerUpPrefebs.Length)]);
        powerup.transform.position = position;
        AddCollectable(powerup);
    }
}
