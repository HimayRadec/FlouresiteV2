using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float spawnCooldown = 5f;
    public bool isEnabled = false;

    private void Update()
    {
        // If enemy is withing radius
        // enable object
        // if not disable object
        if (isEnabled)
        {
            SpawnCooldownTimer();

            if (spawnCooldown == 0)
            {
                SpawnEnemy();

            }
        }

    }

    private void SpawnEnemy()
    {
        if (WaveSystem.CanSpawnEnemies())
        {
            // Spawn an Enemy
            // create game object of the enemy at the current spawner location

            WaveSystem.currentSpawnedEnemies++;
            WaveSystem.totalSpawnedEnemies++;

            spawnCooldown = 5f;
        }
    }

    private void SpawnCooldownTimer()
    {
        if (spawnCooldown > 0)
        {
            spawnCooldown = spawnCooldown - 1 * Time.deltaTime;
        }
        
    }
}
