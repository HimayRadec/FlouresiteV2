using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootTwo : MonoBehaviour
{
    // Drag & Drop the Main Camera into the FPS Cam:____, in the Inspector window

    // The damage is passed along to the TargetHit script
    public float damage = 20f;
    public float range = 100f;

    public Camera fpsCam;
    // This is the script for muzzle flash as well, need animation.

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // The objects hit would have to have Colliders.
            Debug.Log(hit.transform.name); // Named the layers to test debug.log.

            // TargetHit is referncing another script.
            TargetHit target = hit.transform.GetComponent<TargetHit>();
            if (target != null)
            {
                // Shoot five times and it's destroyed.
                target.TakeDamage(damage);
            }
        }
    }
}
