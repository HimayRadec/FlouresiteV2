using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiFollowTest : MonoBehaviour
{
    public NavMeshAgent zombie;
    public GameObject Player;

    // KC Added
    [SerializeField] float stoppingDistance;
    float damage = 10;
    float lastAttackTime = 0;
    float attackCoolDown = 2;

    void Start()
    {
        zombie = GetComponent<NavMeshAgent>();
        // Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //zombie.SetDestination(Player.transform.position);
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        if (distanceToPlayer < stoppingDistance)
        {
            // StopEnemy();
            // Attack();
        }
        else
        {
            GoToTarget();
        }
    }

    private void GoToTarget()
    {
        zombie.isStopped = false;
        zombie.SetDestination(Player.transform.position);
    }

    private void StopEnemy()
    {
        zombie.isStopped = true;
    }

    private void Attack()
    {
        if (Time.time - lastAttackTime >= attackCoolDown)
        {
            lastAttackTime = Time.time;
            //Player.GetComponent<HealthController>().TakeDamage(damage);
        }
    }
}
