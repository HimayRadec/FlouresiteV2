using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Made by Himay
// This script pretty much controls the enemy actions and animations.
public class Enemy : MonoBehaviour
{
    [Header("References")]
    public NavMeshAgent agent;
    public GameObject player;
    public Animator anim;

    [Header("Enemy Stats")]
    public float health;
    public float movementSpeed;

    public float damage;
    public float attackCooldown;
    [HideInInspector]
    public float timeSinceLastAttack;
    [HideInInspector]
    public bool canAttack;

    public float stoppingDistance;
    [HideInInspector]
    public float distanceToPlayer;

    #region - Awake / Start -
    void Awake()
    {
        agent.speed = movementSpeed;
        agent.stoppingDistance = stoppingDistance;
        timeSinceLastAttack = Time.time;
        canAttack = true;
    }

    void Update()
    {
        DistanceToPlayer();
        UpdateMovement();
    }
    #endregion

    #region - Movement -
    public void UpdateMovement()
    {
        // PROB ADD A CAN MOVE CUZ OF ATTACKING
        
        // if the enemy is close enough to the player it will stop and attack
        if (distanceToPlayer < agent.stoppingDistance)
        {
            agent.isStopped = true;
            Attack();
        }
        else
        // if it is not close enough it will keep chasing them
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
            

        }
        
        RunningAnimation();
    }


    public void DistanceToPlayer()
    {
        distanceToPlayer = Vector3.Distance(agent.transform.position, player.transform.position);
    }
    #endregion

    #region - Animation -

    public void RunningAnimation()
    {
        // pretty much sets the value of 'IsRunning' to the correct one
        anim.SetBool("IsRunning", !agent.isStopped);
    }

    public void AttackAnimationBite()
    {
        anim.SetTrigger("AttackBite");
    }

    public void DeathAnimationCollapse()
    {
        anim.SetBool("DeathCollapse", true);
    }

    #endregion

    #region - Attacking -
    public void Attack()
    {
        ResetAttackCooldown();
        if (canAttack)
        {
            AttackAnimationBite();
            timeSinceLastAttack = Time.time;
            canAttack = false;

        }

    }

    // Checks if you can attack
    public void ResetAttackCooldown()
    {
        if (Time.time - timeSinceLastAttack >= attackCooldown)
        {
            canAttack = true;
        }
    }
    #endregion

    #region - Death -
    public void TakeDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    #endregion





}
