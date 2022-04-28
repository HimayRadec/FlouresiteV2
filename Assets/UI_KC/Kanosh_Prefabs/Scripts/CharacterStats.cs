using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public float currentStamina;
    public float maxStamina;

    public bool isDead = false;

    public virtual void CheckHealth()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            Die();
        }
    }

    public virtual void CheckStamina()
    {
        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }
        if (currentStamina <= 0)
        {
            currentStamina = 0;
        }
    }

    public virtual void Die()
    {
        // Override
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
