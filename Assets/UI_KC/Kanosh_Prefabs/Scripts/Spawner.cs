using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //private int waveNumber = 0;
    //private int enemySpawnAmount = 0;
    //private int enemiesKilled = 0;

    public GameObject[] spawners;
    public GameObject enemy;

    int addEnemies = 1;

    private void Start()
    {
        spawners = new GameObject[24 + addEnemies];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        // if something, maybe trigger > SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        int spawnID = Random.Range(0, spawners.Length);
        Instantiate(enemy, spawners[spawnID].transform.position, spawners[spawnID].transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            SpawnEnemy();
        }
    }
}
