using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    // Gun Stats
    public string weaponName;
    public float damage;
    public float timeBetweenShots;
    public float reloadTime;
    public float range = 100f;

    [SerializeField]
    public int clipSize;
    public int ammoLeftInClip, maxAmmo;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public RaycastHit rayHit;
    public ParticleSystem muzzleFlash;

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
            readyToShoot = false;
            // plays muzzle flash
            muzzleFlash.Play();

            // decreases ammo;
            ammoLeftInClip--;
            Debug.Log(ammoLeftInClip + "bullets left in the clip");

            // shoots bullets
            Vector3 direction = fpsCam.transform.forward + new Vector3(0, 0, 0);
            if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
            {
                // if it hits an enemy they will take damage
                // Enemies to be tagged under the layer and tag "Enemy"
                if (rayHit.collider.CompareTag("Enemy"))
                {
                    rayHit.collider.GetComponent<Enemy>().TakeDamage(damage);
                    Debug.Log("ENEMY HIT");
                }
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
        if (!reloading)
        {
            if (maxAmmo > 0)
            {

                // if you don't have enough ammo for a full clip
                if (maxAmmo < clipSize)
                {

                    // reload animation
                    // once reload animation is complete
                    // readyToShoot = true
                    // this should update after the gun is reloaded 

                    ammoLeftInClip = maxAmmo;
                    maxAmmo = 0;
                }
                else if (maxAmmo == 0)
                {
                    // play empty clip sound
                }
                else
                // if you have enough ammo for a full clip
                {
                    // reload animation

                    ammoLeftInClip = clipSize;
                    maxAmmo = maxAmmo - clipSize;


                }
            }
        }
        
        
    }

    public void reloadFinished()
    {
        readyToShoot = true;
    }
}
