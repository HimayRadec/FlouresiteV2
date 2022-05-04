using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float damage = 10.0f;

    [SerializeField] private HealthController healthController = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthController.currentPlayerHealth -= damage;
            healthController.TakeDamage();
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
