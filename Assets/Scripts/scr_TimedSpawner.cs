using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TimedSpawner : MonoBehaviour
{
    public GameObject viperwolf;
    public bool canSpawn;

    private void Awake()
    {
        canSpawn = true;
    }

    private void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnDelay());
        }
    }
    IEnumerator SpawnDelay()
    {
        // create the object
        canSpawn = false;
        Instantiate(viperwolf, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5);
        canSpawn = true;
    }
}
