using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    // Attach Script to Enemy Obj

    // As long as the objects have a collider and this script is attached
    // to each enemy.

    // Starting out health for enemy.
    public float health = 60f; // Was 50f and the damage Was 10f

    // The GunShoot script calls this method to descrease the health. Passing the damage = 10f from that script.
    public void TakeDamage(float amount)
    {
        // if hit take damage
        health -= amount;
        if (health <= 0f)
        {
            // if the health reaches 0 then die (execute Die method below)
            Die();
        }
    }

    void Die()
    {
        // Add Animation & then delete later...


        // when the enemies health reaches 0 then destroy the object.
        Destroy(gameObject);
    }
}
