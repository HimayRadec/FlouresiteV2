using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    /// <summary>
    /// This script is intended for the damage of the Player; thier Health.
    /// It also effects another script HealthController.cs, the UI part.
    /// 
    /// Attach this script to the Enemy Object. Drag & Drop that empty gameobject
    /// you created called Health Controller into the section of the this
    /// script called Health Controller:__ .
    /// </summary>


    // What amount of damage the player will recieve if they are hit by enemy.
    [SerializeField] private float enemyDamage = 10.0f;

    // Used to drag & drop the Health Controller to this section in the Inspetor of
    // this script.
    [SerializeField] private HealthController _healthController = null;


    // When the player collides with the enemy this happens
    private void OnTriggerEnter(Collider other)
    {
        // if the enemy collides with Player then deal damage.
        if (other.CompareTag("Player"))
        {
            _healthController.currentPlayerHealth -= enemyDamage;
            // ref another script HealthController.cs - line 62.
            _healthController.TakeDamage();
        }
    }
}
