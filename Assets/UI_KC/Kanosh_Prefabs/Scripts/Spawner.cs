using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int waveCount = 0;
    private int enemySpawnCount = 0;
    private int enemiesKilled = 0;

    public GameObject[] spawners;
    public GameObject enemy;

    private void Start()
    {
        spawners = new GameObject[5];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject; // GETCHILD check the unity doc
        }

        StartWave();
    }

    private void Update()
    {
        if (enemySpawnCount < 5)
        {
            SpawnEnemy();   

        }
            
    }

    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
        enemySpawnCount++;
    }

    private void StartWave()
    {
        waveCount = 1;
        enemySpawnCount = 2;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void NextWave()
    {
        waveCount++;
        enemySpawnCount += 2;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnCount; i++)
        {
            SpawnEnemy();
        }
    }
}
