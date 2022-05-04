using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float attackCooldown;
    public float speed;
    public float damage;

    public bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        WaveSystem.totalSpawnedEnemies++;
        // if (canAttack)
        // attacks when enemy is within range
        // activates attack animation

        // activates attack cooldown

        // once animation is complete attack cooldown is reset

    }

    public void ResetAttackCooldown()
    {

    }

    public void Walk()
    {
        // activates walking animation
    }

    public void Death()
    {
        WaveSystem.currentSpawnedEnemies--;
        WaveSystem.enemiesLeftInRound--;

    }
}
