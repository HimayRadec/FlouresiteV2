using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    /// <summary>
    /// This Script getst the Zombie to follow the player at an
    /// appropriate distance then wait a few seconds and then
    /// attack the player.
    /// </summary>

    [SerializeField] float damage;
    float lastAttackTime = 0;
    float attackCoolDown = 2;

    [SerializeField] float stoppingDistance;
    NavMeshAgent Enemy;
    GameObject Player;

    public float moveSpeed = 3.0f;

    private void Start()
    {
        /*
        if (GameObject.FindWithTag("Player") != null)
        {
            Player = GameObject.FindWithTag("Player").transform;
        }
        */
        Enemy = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        //Enemy.SetDestination(Player.position);
        if (distance < stoppingDistance)
        {
            StopEnemy();
            if (Time.time - lastAttackTime >= attackCoolDown)
            {
                lastAttackTime = Time.time;
                Player.GetComponent<CharacterStats>().TakeDamage(damage);
            }
        }
        else
        {
            GoToPlayer();
        }
    }

    private void GoToPlayer()
    {
        Enemy.isStopped = false;
        Enemy.SetDestination(Player.transform.position);
    }

    private void StopEnemy()
    {
        Enemy.isStopped = true;
    }

    private void Attack()
    {
        if (Time.time - lastAttackTime >= attackCoolDown)
        {
            lastAttackTime = Time.time;
            Player.GetComponent<CharacterStats>().TakeDamage(damage);
            Player.GetComponent<CharacterStats>().CheckHealth();
        }
    }
}
