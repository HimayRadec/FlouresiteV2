using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiFollowTest : MonoBehaviour
{
    public NavMeshAgent zombie;
    public Transform Player;

    void Update()
    {
        zombie.SetDestination(Player.position);
    }
}
