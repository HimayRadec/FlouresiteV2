using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSysem : MonoBehaviour
{
    // Gun Stats
    public int damage;
    public float timeBetweenShooting, timeBetweenShots;
    public float reloadTime;
    public float range = 100f;

    [SerializeField]
    public int clipSize;
    public int ammoLeftInClip, maxAmmo;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public RaycastHit rayHit;
    public ParticleSystem muzzleFlash;

    public HealthBar UI;

    public LayerMask whatIsEnemy;

    // Start is called before the first frame update
    void Awake()
    {
        readyToShoot = true;
        maxAmmo = clipSize * 6;
        ammoLeftInClip = clipSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (readyToShoot)
        {
            muzzleFlash.Play();

            Vector3 direction = fpsCam.transform.forward + new Vector3(0, 0, 0);
            if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
            {
                if (rayHit.collider.CompareTag("Enemy"))
                    rayHit.collider.GetComponent<TargetHit>().TakeDamage(damage);

                Debug.Log("Gun Fired");
                readyToShoot = false;
                ammoLeftInClip--;
                Debug.Log(ammoLeftInClip + "bullets left in the clip");
            }
           
            if (ammoLeftInClip <= 0)
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
