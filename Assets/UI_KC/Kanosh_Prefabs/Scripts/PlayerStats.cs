using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    PlayerUI playerUI;

    void Start()
    {
        playerUI = GetComponent<PlayerUI>();

        maxHealth = 100;
        currentHealth = maxHealth;

        maxStamina = 100;
        currentStamina = maxStamina;

        SetStats();
    }

    public override void Die()
    {
        Debug.Log("You Died!");
    }

    void SetStats()
    {
        playerUI.healthAmount.text = currentHealth.ToString("0");
        playerUI.staminaAmount.text = currentHealth.ToString("0");
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        SetStats();
    }

    public override void CheckStamina()
    {
        base.CheckStamina();
        SetStats();
    }
}
