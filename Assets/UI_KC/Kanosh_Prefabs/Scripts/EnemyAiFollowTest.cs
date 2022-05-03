using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiFollowTest : MonoBehaviour
{
    public NavMeshAgent zombie;
    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        zombie.SetDestination(Player.transform.position);
    }
}
