using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject zombiePrefab;
    public int roundCount;

    public Transform[] spawnPoints;

    public int zombieCount;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void NewRound()
    {
        roundCount++;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(zombiePrefab, transform.position, Quaternion.identity);
        }
        /*
        for (int i = 0; i < 5; i++)
        {
            Instantiate(zombiePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)], Quaternion.identity);
        }
        */
        for (int i = 0; i < zombieCount; i++)
        {
            zombieCount++;
        }
    }

}
