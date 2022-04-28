using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSysem : MonoBehaviour
{
    // Gun Stats
    public int damage;
    public float timeBetweenShooting, timeBetweenShots;
    public float reloadTime;

    [SerializeField]
    int clipSize;
    int ammoLeftInClip, maxAmmo;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public RaycastHit rayHit;

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
            Vector3 direction = fpsCam.transform.forward + new Vector3(0, 0, 0);
            if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, whatIsEnemy))
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
