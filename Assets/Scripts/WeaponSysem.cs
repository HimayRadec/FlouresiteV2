using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSysem : MonoBehaviour
{
    // Gun Stats
    public int damage;
    public float timeBetweenShooting, timeBetweenShots;
    public float reloadTime;

    int ammoLeftInClip, clipSize, maxAmmo;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public RaycastHit rayHit;

    // Start is called before the first frame update
    void Awake()
    {
        readyToShoot = true;
        maxAmmo = clipSize * 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (readyToShoot)
        {
            readyToShoot = false;
            // Shoots bullets
            ammoLeftInClip--;
            // Resets the bullet shot
            // Checks if you need to reload
            if (ammoLeftInClip == 0)
            {
                Reload();
            } 
            else
            {
                Invoke("ResetShot", timeBetweenShots);
            }
        }
        
    }

    public void ResetShot()
    {
        readyToShoot = true;
    }

    public void Reload()
    {
        if (maxAmmo > 0)
        {
            if (maxAmmo < clipSize)
            {
                ammoLeftInClip = maxAmmo;
                maxAmmo = 0;
            } else
            {
                ammoLeftInClip = clipSize;
                maxAmmo = maxAmmo - clipSize;
            }
        }
        
    }

    public void reloadFinished()
    {

    }
}
