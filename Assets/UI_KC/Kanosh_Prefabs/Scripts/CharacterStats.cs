using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script isn't attached to anything rather acts as a Prefab script
/// that ties in and passes info to update like health, stamina, damage,
/// and if deid?
/// </summary>

public class CharacterStats : MonoBehaviour
{
    public float currHealth;
    public float maxHealth;

    public float currStamina;
    public float maxStamina;

    public bool isDead = false;

    public virtual void CheckHealth()
    {
        if (currHealth >= maxHealth)
        {
            currHealth = maxHealth;
        }
        if (currHealth <= 0)
        {
            currHealth = 0;
            isDead = true;
            // Die();
        }
    }

    public virtual void CheckStamina()
    {
        if (currStamina >= maxStamina)
        {
            currStamina = maxStamina;
        }
        if (currStamina <= 0)
        {
            currStamina = 0;
        }
    }

    public virtual void Die()
    {
        // override later
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
    }
}
