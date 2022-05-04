using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaveSystem
{
    public static int numberOfPlayers;
    public static int currentRound;


    // These Are Per Round
    public static int killedEnemies; // unused
    public static int currentSpawnedEnemies;
    public static int totalSpawnedEnemies;


    public static int enemiesInRound;
    public static int enemiesLeftInRound;


    [Header("Spawning Settings")]
    public static int MinimumNumberOfEnemies = 6;
    public static int MaxNumberOfActiveEnemies = 24;

    public static void CalculateNumberOfEnemiesSpawned(int currentRound)
    {
        enemiesInRound = numberOfPlayers * (MinimumNumberOfEnemies * currentRound);
        enemiesLeftInRound = enemiesInRound;
    }

    public static void RoundEnd()
    {
        currentRound++;

        currentSpawnedEnemies = 0;
        totalSpawnedEnemies = 0;

    }

    public static bool CanSpawnEnemies()
    {
        if (totalSpawnedEnemies == enemiesInRound || currentSpawnedEnemies == MaxNumberOfActiveEnemies)
        {
            return false;
        } else
        {
            return true;
        }
    }


    static void Start()
    {
        currentRound = 1;
        CalculateNumberOfEnemiesSpawned(currentRound);
    }


    static void Update()
    {
        if (enemiesLeftInRound == 0)
        {
            RoundEnd();
            CalculateNumberOfEnemiesSpawned(currentRound);
        }
    }

}

