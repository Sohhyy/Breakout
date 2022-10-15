using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public static CollectableManager Instance = null;
    [SerializeField] private GameObject[] PowerUpPrefebs;
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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        GameObject powerup = Instantiate(PowerUpPrefebs[Random.Range(0, PowerUpPrefebs.Length)]);
        powerup.transform.position = position;
        AddCollectable(powerup);
    }
}
