using UnityEngine;
using System;

public class PointManager : MonoBehaviour
{
    public static PointManager Instance { get; private set; }

    public GameObject coinPrefab;
    private int points = 0;

    private int maxPoints = 99;

    public void Awake()
    {
        if (Instance) Destroy(Instance.gameObject);
        Instance = this;
    }

    public void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var instance = Instantiate(coinPrefab);
            instance.transform.position = new Vector3(i, 0.5f, 5);
        }
    }

    public void AddPoints(int amount)
    {
        points = (int)Mathf.Min(maxPoints, points + amount);
        Debug.Log("Points: " + points);
    }

    public int GetPoints()
    {
        return points;
    }

}
