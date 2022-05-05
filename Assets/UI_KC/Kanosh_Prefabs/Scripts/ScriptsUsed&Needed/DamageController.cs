using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float damage = 10.0f;

    [SerializeField] private GameObject viperWolf = null;

    [SerializeField] private HealthController healthController = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            viperWolf.SetActive(true);
            healthController.currentPlayerHealth -= damage;
            healthController.TakeDamage();
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }
}
