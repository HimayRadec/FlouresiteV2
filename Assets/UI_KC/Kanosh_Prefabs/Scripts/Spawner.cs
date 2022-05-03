using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // KC Added
    public GameObject enemy;
    public GameObject spawner;
    int spawnLimit = 0;
    public int addCanSpawnEnemies = 0;
    public Collider enemySphere;


    public float spawnCooldown = 2f;
    public bool isEnabled = false;

    private void Start()
    {
        enemySphere.isTrigger = false;
    }

    private void Update()
    {
        // If enemy is withing radius
        // enable object
        // if not disable object

        //GetComponent<Collider>().isTrigger = true;

        // I added this line: if the player triggers the spawns radius then set isEnabled to true.
        if (enemySphere.isTrigger == true)
        {
            isEnabled = true;
        }
        else
        {
            isEnabled = false;
        }

        if (isEnabled)
        {
            SpawnCooldownTimer();

            if (spawnCooldown <= 0 && spawnLimit != 5)
            {
                SpawnEnemy();
            }
            else
            {
                isEnabled = false;
            }
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, spawner.transform.position, Quaternion.identity);

        if (WaveSystem.CanSpawnEnemies() == true)
        {
            // Spawn an Enemy
            // create game object of the enemy at the current spawner location

            WaveSystem.currentSpawnedEnemies++;
            WaveSystem.totalSpawnedEnemies++;

            spawnCooldown = 5f;
        }
        addCanSpawnEnemies++;
        spawnLimit++;
    }

    private void SpawnCooldownTimer()
    {
        if (spawnCooldown > 0)
        {
            spawnCooldown = spawnCooldown - 1 * Time.deltaTime;
        }
        
    }
}
