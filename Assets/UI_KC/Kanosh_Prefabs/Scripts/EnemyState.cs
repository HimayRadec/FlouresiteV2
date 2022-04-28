using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : CharacterStats
{
    private float scoreAddAmount = 10;

    GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        maxHealth = 100;
        currentHealth = maxHealth;

        maxStamina = 100;
        currentStamina = maxStamina;
    }

    private void Update()
    {
        CheckHealth();
    }

    public override void Die()
    {
        // base.Die();
        gameController.AddScore(scoreAddAmount);
        Destroy(gameObject);
    }
}
