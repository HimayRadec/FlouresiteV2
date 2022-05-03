using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //private int waveNumber = 0;
    //private int enemySpawnAmount = 0;
    //private int enemiesKilled = 0;

    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;

    private bool stopSpawn;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (stopSpawn == false)
        {
            float xSpawnPos = Mathf.Round(Random.Range(-9.0f, 9.0f) * 10) / 10;
            Vector3 enemySpawnPos = new Vector3(xSpawnPos, 6.5f, 0f);

            GameObject zEnemy = Instantiate(enemyPrefab, enemySpawnPos, Quaternion.identity);
            zEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void PlayerDead()
    {
        stopSpawn = true;
    }
}
